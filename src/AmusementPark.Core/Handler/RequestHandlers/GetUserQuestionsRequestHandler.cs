using AmusementPark.Core.Services.SmartFaq;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using AmusementPark.Message.Requests;

namespace AmusementPark.Core.Handler.RequestHandlers;

public class GetUserQuestionsRequestHandler : IRequestHandler<GetUserQuestionsForReviewRequest, GetUserQuestionsForReviewResponse>
{
    private readonly ISmartFaqService _smartFaqService;

    public GetUserQuestionsRequestHandler(ISmartFaqService smartFaqService)
    {
        _smartFaqService = smartFaqService;
    }

    public async Task<GetUserQuestionsForReviewResponse> Handle(IReceiveContext<GetUserQuestionsForReviewRequest> context, CancellationToken cancellationToken)
    {
        return await _smartFaqService.GetUserQuestionsForReviewAsync(context.Message, cancellationToken).ConfigureAwait(false);
    }
}