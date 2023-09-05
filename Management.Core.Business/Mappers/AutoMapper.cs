using AutoMapper;
using Management.Core.Business.DTOs;
using Management.Core.Domain.Entities;

namespace Management.Core.Business.Mappers;

public class AutoMapper: Profile
{
    public AutoMapper()
    {
        CreateMap<Test, TestDto>().ReverseMap();
    }
}
