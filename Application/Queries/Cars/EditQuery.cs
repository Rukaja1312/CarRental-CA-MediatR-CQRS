using System;
using Application.Commands.Cars;
using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Queries.Cars
{
    public class EditQuery : IRequest<CarEditDTO>
    {
        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class EdintGetHandler : IRequestHandler<EditQuery, CarEditDTO>
    {
        private readonly ICarRepostory carRepostory;

        public EdintGetHandler(ICarRepostory carRepostory)
        {
            this.carRepostory = carRepostory;
        }

        public Task<CarEditDTO> Handle(EditQuery request, CancellationToken cancellationToken)
        {
            return carRepostory.Edit(request.Id);
        }
    }
}

