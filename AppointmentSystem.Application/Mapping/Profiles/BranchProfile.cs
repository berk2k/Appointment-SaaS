using AppointmentSystem.Application.DTOs.Branch;
using AppointmentSystem.Domain.Entities;
using AutoMapper;

namespace AppointmentSystem.Application.Mapping.Profiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<CreateBranchRequest, Branch>();
            CreateMap<Branch, BranchResponse>();
        }
    }
}
