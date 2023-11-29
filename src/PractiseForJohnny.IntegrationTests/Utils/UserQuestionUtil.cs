using Autofac;
using Mediator.Net;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.Commands.UserQuestion;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Enum;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.IntegarationTests.Utills;

public class UserQuestionUtil : TestUtil
{
    public UserQuestionUtil(ILifetimeScope scope) : base(scope)
    {
    }

    public async Task AddUserQuestionsAsync(int id, int correctQid, UserQuestionStatusEnum status, string? remark = null,
        string? question = null, int? rasaPredictedQid = null, float? rasaConfidence = null, int? anygPredictedQid = null, 
        float? model3Confidence = null, string? askBy = null)
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

    public async Task<GetUserQuestionsForReviewResponse> GetUserQuestionsForReviewAsync(GetUserQuestionsRequest userQuestions)
    {
        return  await Run<IMediator, GetUserQuestionsForReviewResponse>(async mediator =>
        {
            return await mediator.RequestAsync<GetUserQuestionsRequest, GetUserQuestionsForReviewResponse>(new GetUserQuestionsRequest
            {
                skip = userQuestions.skip,
                take = userQuestions.take,
                sortField = userQuestions.sortField,
                sortDirection = userQuestions.sortDirection,
                status = userQuestions.status,
                correct_qid = userQuestions.correct_qid
            });
        });
    }

    public async Task<UpdateUserQuestionResponse> UpdateUserQuestionsAsync(List<UpdateUserQuestionDto> UpdatedQuestions)
    {
        return await Run<IMediator, UpdateUserQuestionResponse>(async mediator =>
        {
            return await mediator.SendAsync<UpdateUserQuestionCommand, UpdateUserQuestionResponse>(new UpdateUserQuestionCommand
            {
                UpdatedQuestions = UpdatedQuestions
            });
        });
    }
}