using AutoMapper;
using Day09.DTOs;
using Day09.Models;

namespace Day09.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeResponseDto>();
        CreateMap<CreateEmployeeDto, Employee>();
    }
}