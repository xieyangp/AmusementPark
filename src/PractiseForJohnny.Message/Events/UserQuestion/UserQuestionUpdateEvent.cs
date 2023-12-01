using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Events.UserQuestion;

public class UserQuestionUpdateEvent : IEvent
{
    public List<UserQuestionDto> UserQuestions { get; set; }
}