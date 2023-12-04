using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Commands;

public class ScheduleUpdateFoodCommand : ICommand
{
    public UpdateFoodDto Food { get; set; }
}