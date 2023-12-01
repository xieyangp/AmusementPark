using Xunit;
using Shouldly;
using PractiseForJohnny.Message.Enum;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.IntegarationTests.Servises;

public partial class UserQuestionFixture
{
    [Fact]
    public async Task CanGetUserQuestionsForReview()
    {
        await _userQuestionUtil.AddUserQuestionsAsync(1, 1, UserQuestionStatusEnum.Annoying);
        await _userQuestionUtil.AddUserQuestionsAsync(2, 1, UserQuestionStatusEnum.Pending);
        await _userQuestionUtil.AddUserQuestionsAsync(3, 1, UserQuestionStatusEnum.Comeback);
        await _userQuestionUtil.AddUserQuestionsAsync(4, 1, UserQuestionStatusEnum.Noise);
        await _userQuestionUtil.AddUserQuestionsAsync(5, 1, UserQuestionStatusEnum.Pending);
        await _userQuestionUtil.AddUserQuestionsAsync(6, 1, UserQuestionStatusEnum.Comeback);
        await _userQuestionUtil.AddUserQuestionsAsync(7, 1, UserQuestionStatusEnum.Pending);
        
        var request = new GetUserQuestionsForReviewRequest
        {
            skip = 0,
            take = 10,
            correct_qid = 1,
            sortField = "Id",
            sortDirection = "desc",
            status = UserQuestionStatusEnum.Comeback
        };

        var reponses = await _userQuestionUtil.GetUserQuestionsForReviewAsync(request);
        
        reponses.Data.RowCount.ShouldBe(2); 
        reponses.Data.QuestionsForReview[0].Id.ShouldBe(6);
        reponses.Data.QuestionsForReview[0].CorrectQid.ShouldBe(1);
        reponses.Data.QuestionsForReview[0].Status.ShouldBe(UserQuestionStatusEnum.Comeback);
        
        reponses.Data.QuestionsForReview[1].Id.ShouldBe(3);
        reponses.Data.QuestionsForReview[1].CorrectQid.ShouldBe(1);
        reponses.Data.QuestionsForReview[1].Status.ShouldBe(UserQuestionStatusEnum.Comeback);
    }
}