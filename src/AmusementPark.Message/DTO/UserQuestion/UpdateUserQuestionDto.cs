using AmusementPark.Message.Enum;

namespace AmusementPark.Message.DTO;

public class UpdateUserQuestionDto
{
    public int Id { get; set; }

    public int CorrectQid { get; set; }

    public UserQuestionStatusEnum Status { get; set; }

    public string Remark { get; set; }
}