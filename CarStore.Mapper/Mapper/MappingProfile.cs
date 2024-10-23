namespace CarStore.Mapper.Mapper 
{
    using AutoMapper;
    using CarStore.DataAccess.Entities;
    using CarStore.Domain.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarEntity, CarModel>();
        }
    }
}