using Autofac;
using Mediator.Net;
using AmusementPark.Core.Data;
using AmusementPark.Core.Domain;
using AmusementPark.Message.DTO;
using AmusementPark.Message.Enum;
using AmusementPark.Message.Requests;
using AmusementPark.Message.Commands.UserQuestion;

namespace PractiseForJohnny.IntegarationTests.Utills;

public class UserQuestionUtil : TestUtil
{
    public UserQuestionUtil(ILifetimeScope scope) : base(scope)
    {
    }

    public async Task AddUserQuestionsAsync(int id, int correctQid, UserQuestionStatusEnum status,string? remark = null,
        string? question = null, int? rasaPredictedQid = null, float? rasaConfidence = null, string? askBy = null,
        int? anygPredictedQid = null, float? model3Confidence = null)
    {
        await RunWithUnitOfWork<IRepository>(async repository =>
        {
            await repository.InsertAsync<UserQuestion>(new UserQuestion
            {
                Id = id,
                CorrectQid = correctQid,
                Status = status,
                Question = "Test Question",
                RasaPredictedQid = rasaPredictedQid ?? 1,
                RasaConfidence = rasaConfidence ?? 1,
                AnyqPredictedQid = anygPredictedQid ?? 1,
                Model3Confidence = model3Confidence ?? 1,
                Remark = remark == null ? "Test Add" : remark,
                AskBy = "Test"
            });
        });
    }

    public async Task<GetUserQuestionsForReviewResponse> GetUserQuestionsForReviewAsync(GetUserQuestionsForReviewRequest userQuestionsForReview)
    {
        return await Run<IMediator, GetUserQuestionsForReviewResponse>(async mediator =>
        {
            return await mediator.RequestAsync<GetUserQuestionsForReviewRequest, GetUserQuestionsForReviewResponse>(new GetUserQuestionsForReviewRequest
            {
                skip = userQuestionsForReview.skip,
                take = userQuestionsForReview.take,
                status = userQuestionsForReview.status,
                sortField = userQuestionsForReview.sortField,
                correct_qid = userQuestionsForReview.correct_qid,
                sortDirection = userQuestionsForReview.sortDirection
            });
        });
    }

    public async Task<UpdateUserQuestionsResponse> UpdateUserQuestionsAsync(List<UpdateUserQuestionDto> UpdatedQuestions)
    {
        return await Run<IMediator, UpdateUserQuestionsResponse>(async mediator =>
        {
            return await mediator.SendAsync<UpdateUserQuestionsCommand, UpdateUserQuestionsResponse>(new UpdateUserQuestionsCommand
            {
                UpdatedQuestions = UpdatedQuestions
            });
        });
    }
}