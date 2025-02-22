using ACV.ConditionReports.API.Models.Request;
using ACV.ConditionReports.API.Repositories.Entities;
using AutoMapper;

namespace ACV.ConditionReports.API.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ConditionReport, InspectionCR>().ForMember(dest => dest.Damages, opt => opt.MapFrom(src => src.Damages));
            CreateMap<Damage, DamageCR>();
        }
    }
}
