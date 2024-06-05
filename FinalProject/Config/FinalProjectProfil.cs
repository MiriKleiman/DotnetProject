using AutoMapper;
using Subscriber_CORE.DTO;
using Subscriber_Data.Entities;

namespace FinalProject.Config
{
    public class FinalProjectProfil:Profile
    {
        public FinalProjectProfil()
        {
            //הפונקציה REVERSE מתיחסת לשני הדרכים 
            CreateMap<CardDTO, Card_Table>().ReverseMap();
            //CreateMap<Student   , StudentDTO>();
            CreateMap<SubscriberDTO, Subscriber>().ReverseMap();
            //CreateMap<Student, StudentDTO>().ForMember(sss => sss.FulName, m => m.MapFrom(source => source.FirstName + source.LastName));


        }
    }
}
