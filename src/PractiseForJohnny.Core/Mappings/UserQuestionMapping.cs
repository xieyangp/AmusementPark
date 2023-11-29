using AutoMapper;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Core.Mappings;

public class UserQuestionMapping : Profile
{
    public UserQuestionMapping()
    {
        CreateMap<UserQuestion, UserQuestionDto>();

        CreateMap<UserQuestionDto, UserQuestion>();

        CreateMap<UpdateUserQuestionDto, UserQuestion>().ReverseMap();
    }
}