using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services.SmartFaq;
using PractiseForJohnny.Message.Commands.UserQuestion;

namespace PractiseForJohnny.Core.Handler.CommandHandlers.UserQuestion;

public class UpdateUserQuestionCommandHandler : ICommandHandler<UpdateUserQuestionsCommand, UpdateUserQuestionsResponse>
{
    private readonly ISmartFaqService _smartFaqService;

    public UpdateUserQuestionCommandHandler(ISmartFaqService smartFaqService)
    {
        _smartFaqService = smartFaqService;
    }

    public async Task<UpdateUserQuestionsResponse> Handle(IReceiveContext<UpdateUserQuestionsCommand> context, CancellationToken cancellationToken)
    {
       var updateUserQuestionsEvent = await _smartFaqService.UpdateUserQuestionsAsync(context.Message, cancellationToken).ConfigureAwait(false);

       await context.PublishAsync(updateUserQuestionsEvent).ConfigureAwait(false);
       
       return new UpdateUserQuestionsResponse
       {
           Data = updateUserQuestionsEvent.UserQuestions
       };
    }
}