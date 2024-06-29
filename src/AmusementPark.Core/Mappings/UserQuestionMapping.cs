using AmusementPark.Core.Domain;
using AutoMapper;
using AmusementPark.Message.DTO;

namespace AmusementPark.Core.Mappings;

public class UserQuestionMapping : Profile
{
    public UserQuestionMapping()
    {
        CreateMap<UserQuestion, UserQuestionDto>().ReverseMap();

        CreateMap<UpdateUserQuestionDto, UserQuestion>();
    }
}