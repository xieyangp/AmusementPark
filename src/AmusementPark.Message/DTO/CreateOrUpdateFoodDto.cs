using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmusementPark.Message.DTO;

public class CreateFoodDto
{
    public string Name { get; set; }

    public string Color { get; set; }
}

public class UpdateFoodDto : CreateFoodDto
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}