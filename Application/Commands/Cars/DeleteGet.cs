using System;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Cars
{
    public class DeleteGet : IRequest<Car>
    {
        public DeleteGet(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class DeleteGetHandler : IRequestHandler<DeleteGet, Car>
    {
        private readonly ICarRepostory carRepostory;

        public DeleteGetHandler(ICarRepostory carRepostory)
        {
            this.carRepostory = carRepostory;
        }

        public Task<Car> Handle(DeleteGet request, CancellationToken cancellationToken)
        {
            return carRepostory.DeleteGet(request.Id);
        }
    }
}

