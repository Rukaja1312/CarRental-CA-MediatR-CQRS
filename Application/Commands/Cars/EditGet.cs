using System;
using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Commands.Cars
{
    public class EditGet : IRequest<CarEditDTO>
    {
        public EditGet(int id )
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class EdintGetHandler : IRequestHandler<EditGet, CarEditDTO>
    {
        private readonly ICarRepostory carRepostory;

        public EdintGetHandler(ICarRepostory carRepostory)
        {
            this.carRepostory = carRepostory;
        }

        public Task<CarEditDTO> Handle(EditGet request, CancellationToken cancellationToken)
        {
            return carRepostory.Edit(request.Id);
        }
    }
}

