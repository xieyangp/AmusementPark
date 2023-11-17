namespace PractiseForJohnny.Message.DTO;

public class CreateFoodDto
{
    public string Name { get; set; }

    public string Color { get; set; }
}

public class FoodCreatedDto : CreateFoodDto
{
    public int Id { get; set; }
}

public class UpdateFoodDto : CreateFoodDto
{
    public int Id { get; set; }
}

public class FoodUpdatedDto : CreateFoodDto
{
    public int Id { get; set; }
}