using PractiseForJohnny.Message.Enum;

namespace PractiseForJohnny.Message.DTO;

public class UserQuestionDto
{
    public int Id { get; set; }

    public int CreatedAt { get; set; }

    public string Question { get; set; }

    public int RasaPredictedQid { get; set; }

    public float? RasaConfidence { get; set; }
    
    public int AnyQPredictedQid { get; set; }
    
    public float? AnyQConfidence { get; set; }

    public int Model3PredictedQid { get; set; }

    public float? Model3Confidence { get; set; }

    public UserQuestionStatusEnum Status { get; set; }

    public string Remark { get; set; }
    
    public int CorrectQid { get; set; }

    public string AskBy { get; set; }
}