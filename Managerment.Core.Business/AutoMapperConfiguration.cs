
using AutoMapper;
using Management.Core.Domain.Entities;
using Managerment.Core.Business.DTOs;

namespace Managerment.Core.Business;

public class AutoMapperConfiguration : Profile
{

    public AutoMapperConfiguration()
    {
        CreateMap<Test, TestDTO>().ReverseMap();
    }
}
