using System;
using Application.Interfaces;
using MediatR;

namespace Application.Commands.Cars
{
    public class Delete :IRequest<bool>
    {
        public Delete(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class DeleteHandler : IRequestHandler<Delete, bool>
    {
        private readonly ICarRepostory carRepostory;

        public DeleteHandler(ICarRepostory carRepostory)
        {
            this.carRepostory = carRepostory;
        }

        public async Task<bool> Handle(Delete request, CancellationToken cancellationToken)
        {
            return await carRepostory.Delete(request.Id);
        }
    }
}

