using AutoMapper;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Core.Mappings;

public class FoodMapping : Profile
{
    public FoodMapping()
    {
        CreateMap<CreateFoodDto, Foods>();
        
        CreateMap<Foods, FoodCreatedDto>();

        CreateMap<UpdateFoodDto, Foods>();

        CreateMap<Foods, FoodUpdatedDto>();
    }
}