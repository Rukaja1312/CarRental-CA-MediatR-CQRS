using System;
using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Queries.Car
{
    public class SearchByBrandQuery : IRequest<List<CarViewDTO>>
    {
        public SearchByBrandQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class SearchByBrandHandler : IRequestHandler<SearchByBrandQuery, List<CarViewDTO>>
    {
        private readonly ICarRepostory carRepository;

        public SearchByBrandHandler(ICarRepostory carRepository)
        {
            this.carRepository = carRepository;
        }
        
        public Task<List<CarViewDTO>> Handle(SearchByBrandQuery request, CancellationToken cancellationToken)
        {
            return carRepository.SortByBrand(request.Id);
        }
    }
}

