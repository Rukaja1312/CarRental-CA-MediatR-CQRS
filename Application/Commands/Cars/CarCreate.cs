using System;
using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Cars
{
    public class CarCreate : IRequest<bool>
    {
        public CarCreate(CarCreateDTO carCreateDTO)
        {
            CarCreateDTO = carCreateDTO;
        }

        public CarCreateDTO CarCreateDTO { get; set; }
    }

    public class CarCreateHandler : IRequestHandler<CarCreate, bool>
    {
        private readonly ICarRepostory carRespostory;

        public CarCreateHandler(ICarRepostory carRespostory)
        {
            this.carRespostory = carRespostory;
        }

        public Task<bool> Handle(CarCreate request, CancellationToken cancellationToken)
        {
            return carRespostory.CarCreate(request.CarCreateDTO);
        }
    }
}

