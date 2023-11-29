using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Enum;
using PractiseForJohnny.Message.Responses;

namespace PractiseForJohnny.Message.Requests;

public class GetUserQuestionsForReviewRequest : IRequest
{
    public int skip { get; set; }

    public int take { get; set; } = 25;

    public string sortField { get; set; } = "id";

    public string sortDirection { get; set; } = "desc";

    public UserQuestionStatusEnum status { get; set; } = UserQuestionStatusEnum.Pending;
    
    public int? correct_qid { get; set; }
}

public class GetUserQuestionsForReviewResponse : CommonResponse<GetUserQuestionForReviewData>
{
}

public class GetUserQuestionForReviewData
{
    public List<UserQuestionDto> QuestionsForReview { get; set; }

    public Dictionary<string, string> SortColumns { get; set; }

    public int RowCount { get; set; }
}

