using AmusementPark.Message.Commands.UserQuestion;
using AmusementPark.Message.Events.UserQuestion;
using AmusementPark.Message.Requests;

namespace AmusementPark.Core.Services.SmartFaq;

public interface ISmartFaqService : IService
{
    Task<GetUserQuestionsForReviewResponse> GetUserQuestionsForReviewAsync(GetUserQuestionsForReviewRequest request, CancellationToken cancellationToken);
    
    Task<UserQuestionUpdateEvent> UpdateUserQuestionsAsync(UpdateUserQuestionsCommand command, CancellationToken cancellationToken);
}