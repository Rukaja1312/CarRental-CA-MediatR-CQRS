using System;
using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Commands.Cars
{
    public class Edit : IRequest<bool>
    {
        public Edit(int id, CarEditDTO carEditDTO)
        {
            Id = id;
            CarEditDTO = carEditDTO;
        }

        public int Id { get; set; }
        public CarEditDTO CarEditDTO { get; set; }
    }

    public class EditHandler : IRequestHandler<Edit, bool>
    {
        private readonly ICarRepostory carRepostory;

        public EditHandler(ICarRepostory carRepostory)
        {
            this.carRepostory = carRepostory;
        }

        public Task<bool> Handle(Edit request, CancellationToken cancellationToken)
        {
            return carRepostory.Edit(request.Id, request.CarEditDTO);
        }
    }
}

