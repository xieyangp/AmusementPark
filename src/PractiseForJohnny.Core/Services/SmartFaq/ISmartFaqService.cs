using PractiseForJohnny.Message.Commands.UserQuestion;
using PractiseForJohnny.Message.Events.UserQuestion;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Services.SmartFaq;

public interface ISmartFaqService : IService
{
    Task<GetUserQuestionsForReviewResponse> GetUserQuestionsForReviewAsync(GetUserQuestionsRequest command, CancellationToken cancellationToken);
    
    Task<UserQuestionUpdateEvent> UpdateUserQuestionsAsync(UpdateUserQuestionCommand command, CancellationToken cancellationToken);
}