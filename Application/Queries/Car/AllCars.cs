using System;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Queries.Car
{
    public class AllCars : IRequest<List<CarViewDTO>>
    {
        
    }

    public class AllCarsHandler : IRequestHandler<AllCars, List<CarViewDTO>>
    {
        private readonly ICarRepostory carRepostory;

        public AllCarsHandler(ICarRepostory carRepostory)
        {
            this.carRepostory = carRepostory;
        }

        public async Task<List<CarViewDTO>> Handle(AllCars request, CancellationToken cancellationToken)
        {
            return await carRepostory.GetAllCars();
        }
    }
}

