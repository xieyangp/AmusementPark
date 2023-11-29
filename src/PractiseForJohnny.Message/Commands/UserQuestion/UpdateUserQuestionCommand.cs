using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Responses;

namespace PractiseForJohnny.Message.Commands.UserQuestion;

public class UpdateUserQuestionCommand : ICommand
{
    public List<UpdateUserQuestionDto> UpdatedQuestions { get; set; }
}

public class UpdateUserQuestionResponse : CommonResponse
{
    public List<UserQuestionDto> Data { get; set; }
}