using System;
using Application.Commands.Cars;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Cars
{
    public class DeleteQuery : IRequest<Car>
    {
        public DeleteQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class DeleteGetQueryHandler : IRequestHandler<DeleteQuery, Car>
    {
        private readonly ICarRepostory carRepostory;

        public DeleteGetQueryHandler(ICarRepostory carRepostory)
        {
            this.carRepostory = carRepostory;
        }

        public Task<Car> Handle(DeleteQuery request, CancellationToken cancellationToken)
        {
            return carRepostory.DeleteGet(request.Id);
        }
    }
}

