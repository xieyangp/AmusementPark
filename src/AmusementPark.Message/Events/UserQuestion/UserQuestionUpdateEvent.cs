using AmusementPark.Message.DTO;
using Mediator.Net.Contracts;

namespace AmusementPark.Message.Events.UserQuestion;

public class UserQuestionUpdateEvent : IEvent
{
    public List<UserQuestionDto> UserQuestions { get; set; }
}