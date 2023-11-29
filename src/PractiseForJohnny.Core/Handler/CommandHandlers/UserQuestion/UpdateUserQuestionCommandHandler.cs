using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services.SmartFaq;
using PractiseForJohnny.Message.Commands.UserQuestion;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Core.Handler.CommandHandlers.UserQuestion;

public class UpdateUserQuestionCommandHandler : ICommandHandler<UpdateUserQuestionCommand, UpdateUserQuestionResponse>
{
    private readonly ISmartFaqService _smartFaqService;

    public UpdateUserQuestionCommandHandler(ISmartFaqService smartFaqService)
    {
        _smartFaqService = smartFaqService;
    }

    public async Task<UpdateUserQuestionResponse> Handle(IReceiveContext<UpdateUserQuestionCommand> context, CancellationToken cancellationToken)
    {
       var updateUserQuestionsEvent = await _smartFaqService.UpdateUserQuestionsAsync(context.Message, cancellationToken).ConfigureAwait(false);

       await context.PublishAsync(updateUserQuestionsEvent).ConfigureAwait(false);
       
       return new UpdateUserQuestionResponse
       {
           Data = updateUserQuestionsEvent.UserQuestions
       };
    }
}