namespace PractiseForJohnny.Message.DTO.UserAccount;

public class UserAccountDto
{
    public int Id { get; set; }

    public DateTime CreatedOn { get; set; }
    
    public DateTime ModifiedOn { get; set; }
    
    public string UserName { get; set; }

    public string PassWord { get; set; }
    
    public List<RoleDto> Roles { get; set; }
}