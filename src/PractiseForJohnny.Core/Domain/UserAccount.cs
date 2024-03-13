using System.ComponentModel.DataAnnotations.Schema;

namespace PractiseForJohnny.Core.Domain;

[Table("user_account")]
public class UserAccount : IEntity
{
    [Column("id")]
    public int Id { get; set; }

    [Column("created_on")]
    public DateTime CreatedOn { get; set; }

    [Column("modified_on")]
    public DateTime ModifiedOn { get; set; }

    [Column("user_name")]
    public string UserName { get; set; }

    [Column("pass_word")]
    public string PassWord { get; set; }
}