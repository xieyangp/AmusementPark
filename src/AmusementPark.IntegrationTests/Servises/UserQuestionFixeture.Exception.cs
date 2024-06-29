using Xunit;
using Shouldly;
using AmusementPark.Core.Data;
using Microsoft.EntityFrameworkCore;
using AmusementPark.Core.Domain;
using AmusementPark.Message.DTO;
using AmusementPark.Message.Enum;

namespace PractiseForJohnny.IntegarationTests.Servises;

public partial class UserQuestionFixture
{
    [Fact]
    public async Task CanUpdateUserQuestions()
    {
        await _userQuestionUtil.AddUserQuestionsAsync(8, 1, UserQuestionStatusEnum.Annoying, "before update correctqid 1 status annoying");
        await _userQuestionUtil.AddUserQuestionsAsync(9, 1, UserQuestionStatusEnum.Comeback, "before update correctqid 1 status comeback");
        await _userQuestionUtil.AddUserQuestionsAsync(10, 1, UserQuestionStatusEnum.Noise, "before update correctqid 1 status noise");
        await _userQuestionUtil.AddUserQuestionsAsync(11, 1, UserQuestionStatusEnum.Pending, "before update correctqid 1 status pending");
        await _userQuestionUtil.AddUserQuestionsAsync(12, 1, UserQuestionStatusEnum.ReadyToTrain, "before update correctqid 1 status readyToTrain");

        var updatedUserQuestions = new List<UpdateUserQuestionDto>()
        {
            new()
            {
               Id = 8,
               CorrectQid = 2,
               Status = UserQuestionStatusEnum.Comeback,
               Remark = "updated correcdQid 2 status comeback"
            },
            new()
            {
                Id = 9,
                CorrectQid = 3,
                Status = UserQuestionStatusEnum.Noise,
                Remark = "updated correcdQid 3 status noise"
            },
            new()
            {
            Id = 10,
            CorrectQid = 4,
            Status = UserQuestionStatusEnum.Pending,
            Remark = "updated correcdQid 4 status pending"
            },
            new()
            {
                Id = 11,
                CorrectQid = 5,
                Status = UserQuestionStatusEnum.ReadyToTrain,
                Remark = "updated correcdQid 5 status readyToTrain"
            },
            new()
            {
                Id = 12,
                CorrectQid = 6,
                Status = UserQuestionStatusEnum.Annoying,
                Remark = "updated correcdQid 6 status annoying"
            }
        };

        var userQuestionId = updatedUserQuestions.Select(i => i.Id).ToList();

        var beforeUserQuestions = await Run<IRepository, List<UserQuestion>>(async repository =>
        {
            return await repository.Query<UserQuestion>(i => userQuestionId.Contains(i.Id)).ToListAsync().ConfigureAwait(false);
        });
        
        beforeUserQuestions[0].Id.ShouldBe(8);
        beforeUserQuestions[0].CorrectQid.ShouldBe(1);
        beforeUserQuestions[0].Status.ShouldBe(UserQuestionStatusEnum.Annoying);
        beforeUserQuestions[0].Remark.ShouldBe("before update correctqid 1 status annoying");
        
        beforeUserQuestions[1].Id.ShouldBe(9);
        beforeUserQuestions[1].CorrectQid.ShouldBe(1);
        beforeUserQuestions[1].Status.ShouldBe(UserQuestionStatusEnum.Comeback);
        beforeUserQuestions[1].Remark.ShouldBe("before update correctqid 1 status comeback");
        
        beforeUserQuestions[2].Id.ShouldBe(10);
        beforeUserQuestions[2].CorrectQid.ShouldBe(1);
        beforeUserQuestions[2].Status.ShouldBe(UserQuestionStatusEnum.Noise);
        beforeUserQuestions[2].Remark.ShouldBe("before update correctqid 1 status noise");
        
        beforeUserQuestions[3].Id.ShouldBe(11);
        beforeUserQuestions[3].CorrectQid.ShouldBe(1);
        beforeUserQuestions[3].Status.ShouldBe(UserQuestionStatusEnum.Pending);
        beforeUserQuestions[3].Remark.ShouldBe("before update correctqid 1 status pending");
        
        beforeUserQuestions[4].Id.ShouldBe(12);
        beforeUserQuestions[4].CorrectQid.ShouldBe(1);
        beforeUserQuestions[4].Status.ShouldBe(UserQuestionStatusEnum.ReadyToTrain);
        beforeUserQuestions[4].Remark.ShouldBe("before update correctqid 1 status readyToTrain");
        
        var userQuestionsUpdate = await _userQuestionUtil.UpdateUserQuestionsAsync(updatedUserQuestions);
        
        userQuestionsUpdate.Data[0].Id.ShouldBe(8);
        userQuestionsUpdate.Data[0].CorrectQid.ShouldBe(2);
        userQuestionsUpdate.Data[0].Status.ShouldBe(UserQuestionStatusEnum.Comeback);
        userQuestionsUpdate.Data[0].Remark.ShouldBe("updated correcdQid 2 status comeback");
        
        userQuestionsUpdate.Data[1].Id.ShouldBe(9);
        userQuestionsUpdate.Data[1].CorrectQid.ShouldBe(3);
        userQuestionsUpdate.Data[1].Status.ShouldBe(UserQuestionStatusEnum.Noise);
        userQuestionsUpdate.Data[1].Remark.ShouldBe("updated correcdQid 3 status noise");
        
        userQuestionsUpdate.Data[2].Id.ShouldBe(10);
        userQuestionsUpdate.Data[2].CorrectQid.ShouldBe(4);
        userQuestionsUpdate.Data[2].Status.ShouldBe(UserQuestionStatusEnum.Pending);
        userQuestionsUpdate.Data[2].Remark.ShouldBe("updated correcdQid 4 status pending");
        
        userQuestionsUpdate.Data[3].Id.ShouldBe(11);
        userQuestionsUpdate.Data[3].CorrectQid.ShouldBe(5);
        userQuestionsUpdate.Data[3].Status.ShouldBe(UserQuestionStatusEnum.ReadyToTrain);
        userQuestionsUpdate.Data[3].Remark.ShouldBe("updated correcdQid 5 status readyToTrain");
        
        userQuestionsUpdate.Data[4].Id.ShouldBe(12);
        userQuestionsUpdate.Data[4].CorrectQid.ShouldBe(6);
        userQuestionsUpdate.Data[4].Status.ShouldBe(UserQuestionStatusEnum.Annoying);
        userQuestionsUpdate.Data[4].Remark.ShouldBe("updated correcdQid 6 status annoying");
    }
}