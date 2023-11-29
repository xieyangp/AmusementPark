using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.Commands.UserQuestion;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Services.SmartFaq;

public interface ISmartFaqDataProvider : IService
{
    Task<(int Count, List<UserQuestionDto> UserQuestions)> GetUserQuestionsAsync(GetUserQuestionsForReviewRequest command, CancellationToken cancellationToken);

    Task UpdateUserQuestionsAsync(List<UserQuestion> userQuestions, CancellationToken cancellationToken);

    Task<List<UserQuestion>> GetUserQuestionsByIdsAsync(List<int> userQuestionIds, CancellationToken cancellationToken);
}