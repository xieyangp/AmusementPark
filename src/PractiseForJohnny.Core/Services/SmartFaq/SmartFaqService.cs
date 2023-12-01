using AutoMapper;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Requests;
using PractiseForJohnny.Message.Commands.UserQuestion;
using PractiseForJohnny.Message.Events.UserQuestion;

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

    public async Task<GetUserQuestionsForReviewResponse> GetUserQuestionsForReviewAsync(
        GetUserQuestionsForReviewRequest request, CancellationToken cancellationToken)
    {
        var (count, userQuestions) = await _smartFaqDataProvider.GetUserQuestionsAsync(request, cancellationToken).ConfigureAwait(false);

        return new GetUserQuestionsForReviewResponse
        {
            Data = new GetUserQuestionForReviewData
            {
                RowCount = count,
                QuestionsForReview = userQuestions
            }
        };
    }

    public async Task<UserQuestionUpdateEvent> UpdateUserQuestionsAsync(UpdateUserQuestionsCommand command,
        CancellationToken cancellationToken)
    {
        if (!command.UpdatedQuestions.Any()) return new UserQuestionUpdateEvent();
        
        var userQuestionIds = command.UpdatedQuestions.Select(i => i.Id).ToList();

        var userQuestions = await _smartFaqDataProvider.GetUserQuestionsByIdsAsync(userQuestionIds, cancellationToken).ConfigureAwait(false);

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