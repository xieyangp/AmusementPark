using PractiseForJohnny.Message.Commands.UserQuestion;
using PractiseForJohnny.Message.Events.UserQuestion;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Services.SmartFaq;

public interface ISmartFaqService : IService
{
    Task<GetUserQuestionsForReviewResponse> GetUserQuestionsForReviewAsync(GetUserQuestionsForReviewRequest request, CancellationToken cancellationToken);
    
    Task<UserQuestionUpdateEvent> UpdateUserQuestionsAsync(UpdateUserQuestionsCommand command, CancellationToken cancellationToken);
}