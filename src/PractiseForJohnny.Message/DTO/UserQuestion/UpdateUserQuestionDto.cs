using PractiseForJohnny.Message.Enum;

namespace PractiseForJohnny.Message.DTO;

public class UpdateUserQuestionDto
{
    public int Id { get; set; }

    public int CorrectQid { get; set; }

    public UserQuestionStatusEnum Status { get; set; }

    public string Remark { get; set; }
}