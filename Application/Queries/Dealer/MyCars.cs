using System;
using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Queries.Dealer
{
    public class MyCars : IRequest<List<CarViewDTO>>
    {

    }

    public class MyCarsHandler : IRequestHandler<MyCars, List<CarViewDTO>>
    {
        private readonly IDealerRepository dealerRepository;

        public MyCarsHandler(IDealerRepository dealerRepository)
        {
            this.dealerRepository = dealerRepository;
        }

        public async Task<List<CarViewDTO>> Handle(MyCars request, CancellationToken cancellationToken)
        {
            return await dealerRepository.DealerCars(cancellationToken);
        }
    }
}

