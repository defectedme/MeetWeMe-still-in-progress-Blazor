using AutoMapper;
using MeetWeMe.Model;



namespace MeetWeMe.Web.Models
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<Users, EditUserModel>()
          .ForMember(dest => dest.ConfirmEmail,
                     opt => opt.MapFrom(src => src.Email));
            CreateMap<EditUserModel, Users>();
        }
    }



}
