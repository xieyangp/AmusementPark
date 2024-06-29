using AmusementPark.Core.Domain;
using AmusementPark.Message.Commands.UserQuestion;
using AmusementPark.Message.DTO;
using AmusementPark.Message.Requests;

namespace AmusementPark.Core.Services.SmartFaq;

public interface ISmartFaqDataProvider : IService
{
    Task<(int Count, List<UserQuestionDto> UserQuestions)> GetUserQuestionsAsync(GetUserQuestionsForReviewRequest request, CancellationToken cancellationToken);

    Task UpdateUserQuestionsAsync(List<UserQuestion> userQuestions, CancellationToken cancellationToken);

    Task<List<UserQuestion>> GetUserQuestionsByIdsAsync(List<int> userQuestionIds, CancellationToken cancellationToken);
}