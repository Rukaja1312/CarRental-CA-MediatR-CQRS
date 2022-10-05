using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CarCreateDTO, Car>();
            CreateMap<Car, CarViewDTO>();
            CreateMap<CarCreateOutOfIFormFileDTO, Car>();
            CreateMap<CarCreateDTO, CarCreateOutOfIFormFileDTO>();
            CreateMap<CarEditDTO, Car>();
            CreateMap<Car, CarEditDTO>();
            CreateMap<DealerCarsDTO, Car>();
            CreateMap<DealerDTO, Dealer>();
        }
    }
}
