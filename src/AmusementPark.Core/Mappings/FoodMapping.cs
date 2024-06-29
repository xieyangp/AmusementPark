using AmusementPark.Core.Domain;
using AutoMapper;
using AmusementPark.Message.DTO;

namespace AmusementPark.Core.Mappings;

public class FoodMapping : Profile
{
    public FoodMapping()
    {
        CreateMap<CreateFoodDto, Foods>().ReverseMap();

        CreateMap<UpdateFoodDto, Foods>().ReverseMap();

        CreateMap<DeleteFoodDto, Foods>().ReverseMap();

        CreateMap<Foods, OutFoodDto>();
    }
}