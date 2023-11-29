using Microsoft.EntityFrameworkCore;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Enum;
using Shouldly;
using Xunit;

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

        var updatedQuestions = new List<UpdateUserQuestionDto>()
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

        var userQuestionId = updatedQuestions.Select(i => i.Id).ToList();

        var beforeUserQuestions = await Run<IRepository, List<UserQuestion>>(async repository =>
        {
            return await repository.Query<UserQuestion>(i => userQuestionId.Contains(i.Id)).ToListAsync();
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
        
        var userQuestionUpdate = await _userQuestionUtil.UpdateUserQuestionsAsync(updatedQuestions);
        
        userQuestionUpdate.Data[0].Id.ShouldBe(8);
        userQuestionUpdate.Data[0].CorrectQid.ShouldBe(2);
        userQuestionUpdate.Data[0].Status.ShouldBe(UserQuestionStatusEnum.Comeback);
        userQuestionUpdate.Data[0].Remark.ShouldBe("updated correcdQid 2 status comeback");
        
        userQuestionUpdate.Data[1].Id.ShouldBe(9);
        userQuestionUpdate.Data[1].CorrectQid.ShouldBe(3);
        userQuestionUpdate.Data[1].Status.ShouldBe(UserQuestionStatusEnum.Noise);
        userQuestionUpdate.Data[1].Remark.ShouldBe("updated correcdQid 3 status noise");
        
        userQuestionUpdate.Data[2].Id.ShouldBe(10);
        userQuestionUpdate.Data[2].CorrectQid.ShouldBe(4);
        userQuestionUpdate.Data[2].Status.ShouldBe(UserQuestionStatusEnum.Pending);
        userQuestionUpdate.Data[2].Remark.ShouldBe("updated correcdQid 4 status pending");
        
        userQuestionUpdate.Data[3].Id.ShouldBe(11);
        userQuestionUpdate.Data[3].CorrectQid.ShouldBe(5);
        userQuestionUpdate.Data[3].Status.ShouldBe(UserQuestionStatusEnum.ReadyToTrain);
        userQuestionUpdate.Data[3].Remark.ShouldBe("updated correcdQid 5 status readyToTrain");
        
        userQuestionUpdate.Data[4].Id.ShouldBe(12);
        userQuestionUpdate.Data[4].CorrectQid.ShouldBe(6);
        userQuestionUpdate.Data[4].Status.ShouldBe(UserQuestionStatusEnum.Annoying);
        userQuestionUpdate.Data[4].Remark.ShouldBe("updated correcdQid 6 status annoying");
    }
}