using System;
using Application.Interfaces;
using MediatR;

namespace Application.Queries.Dealer
{
    public class IsDealer : IRequest<bool>
    {
        public IsDealer(string userId)
        {
            UserId = userId;
        }
        public string UserId { get; set; }
    }

    public class IsDealerHandler : IRequestHandler<IsDealer, bool>
    {
        private readonly IDealerRepository dealerRepository;

        public IsDealerHandler(IDealerRepository dealerRepository)
        {
            this.dealerRepository = dealerRepository;
        }

        public Task<bool> Handle(IsDealer request, CancellationToken cancellationToken)
        {
            return dealerRepository.IsDealer(request.UserId);
        }
    }
}

