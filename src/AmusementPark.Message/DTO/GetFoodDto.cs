namespace AmusementPark.Message.DTO;

public class GetFoodDto
{
    public int Id { get; set; }
}

public class OutFoodDto : GetFoodDto
{
    public string Name { get; set; }

    public string Color { get; set; }
}