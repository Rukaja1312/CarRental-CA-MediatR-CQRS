using System;
using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Commands.Dealer
{
    public class CreateDealer : IRequest<bool>
    {
       public DealerDTO DealerDTO { get; set; }
    }

    public class CreateDealerHandler : IRequestHandler<CreateDealer, bool>
    {
        private readonly IDealerRepository dealerRepository;

        public CreateDealerHandler(IDealerRepository dealerRepository)
        {
            this.dealerRepository = dealerRepository;
        }

        public Task<bool> Handle(CreateDealer request, CancellationToken cancellationToken)
        {
            return dealerRepository.CreateDealer(request.DealerDTO);
        }
    }
}

