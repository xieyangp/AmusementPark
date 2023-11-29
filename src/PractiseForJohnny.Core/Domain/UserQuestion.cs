using PractiseForJohnny.Message.Enum;
using PractiseForJohnny.Message.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiseForJohnny.Core.Domain;

[Table("user_question")]
public class UserQuestion : IEntity
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [SortColumn("Id", "id")]
    public int Id { get; set; }
    
    [Column("created_at")]
    [SortColumn("CreatedAt", "created_at")]
    public int CreatedAt { get; set; }

    [Column("question")]
    [SortColumn("Question", "question")]
    public string Question { get; set; }

    [Column("rasa_predicted_qid")]
    [SortColumn("RasaPredictedQid", "rasa_predicted_qid")]
    public int RasaPredictedQid { get; set; }

    [Column("rasa_confidence")]
    [SortColumn("RasaConfidence", "rasa_confidence")]
    public float RasaConfidence { get; set; }

    [Column("anyq_confidence")]
    [SortColumn("AnyqConfidence", "anyq_confidence")]
    public float AnyqConfidence { get; set; }

    [Column("anyq_predicted_qid")]
    [SortColumn("AnyqPredictedQid", "anyq_predicted_qid")]
    public int AnyqPredictedQid { get; set; }

    [Column("model3_predicted_qid")]
    [SortColumn("Model3PredictedQid", "model3_predicted_qid")]
    public int Model3PredictedQid { get; set; }

    [Column("model3_confidence")]
    [SortColumn("Model3Confidence", "model3_confidence")]
    public float Model3Confidence { get; set; }

    [Column("correct_qid")]
    [SortColumn("CorrectQid", "correct_qid")]
    public int CorrectQid { get; set; }

    [Column("status")]
    [SortColumn("Status", "status")]
    public UserQuestionStatusEnum Status { get; set; }

    [Column("remark")]
    [SortColumn("Remark", "remark")]
    public string Remark { get; set; }

    [Column("ask_by")]
    [SortColumn("AskBy", "ask_by")]
    public string AskBy { get; set; }
}