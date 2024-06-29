using AmusementPark.Message.DTO;
using AmusementPark.Message.Responses;
using Mediator.Net.Contracts;

namespace AmusementPark.Message.Commands.UserQuestion;

public class UpdateUserQuestionsCommand : ICommand
{
    public List<UpdateUserQuestionDto> UpdatedQuestions { get; set; }
}

public class UpdateUserQuestionsResponse : CommonResponse
{
    public List<UserQuestionDto> Data { get; set; }
}