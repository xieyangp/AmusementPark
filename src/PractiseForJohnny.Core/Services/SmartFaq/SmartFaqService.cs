using AutoMapper;
using PractiseForJohnny.Message.Commands.UserQuestion;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Events.UserQuestion;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Services.SmartFaq;

public class SmartFaqService : ISmartFaqService
{
    private readonly IMapper _mapper;
    private readonly ISmartFaqDataProvider _smartFaqDataProvider;

    public SmartFaqService(IMapper mapper, ISmartFaqDataProvider smartFaqDataProvider)
    {
        _mapper = mapper;
        _smartFaqDataProvider = smartFaqDataProvider;
    }

    public async Task<GetUserQuestionsForReviewResponse> GetUserQuestionsForReviewAsync(GetUserQuestionsRequest command, CancellationToken cancellationToken)
    {
        var (count, userQuestions) = await _smartFaqDataProvider.GetQuestions(command, cancellationToken);

        return new GetUserQuestionsForReviewResponse
        {
            Data = new GetUserQuestionForReviewData
            {
                RowCount = count,
                QuestionsForReview = userQuestions
            }
        };
    }
    
    public async Task<UserQuestionUpdateEvent> UpdateUserQuestionsAsync(UpdateUserQuestionCommand command, CancellationToken cancellationToken)
    {
        var userQuestionIds = command.UpdatedQuestions.Select(i => i.Id).ToList();

        var userQuestions = await _smartFaqDataProvider.GetUserQuestionsAsync(userQuestionIds, cancellationToken);

        foreach (var userQuestion in userQuestions)
        {
            var UpdateUserQuestion = command.UpdatedQuestions.FirstOrDefault(i => i.Id == userQuestion.Id);
            
            if(UpdateUserQuestion == null) continue;

            _mapper.Map(UpdateUserQuestion, userQuestion);
        }

        await _smartFaqDataProvider.UpdateUserQuestionsAsync(userQuestions, cancellationToken).ConfigureAwait(false);
        
        return new UserQuestionUpdateEvent{ UserQuestions = _mapper.Map<List<UserQuestionDto>>(userQuestions)} ;
    }
}