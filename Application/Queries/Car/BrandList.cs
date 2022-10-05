using System;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Application.Queries.Car
{
    public class BrandList : IRequest<List<SelectListItem>>
    {
       
    }
    public class BrandListHandler : IRequestHandler<BrandList, List<SelectListItem>>
    {
        private readonly ICarRepostory carRepostory;

        public BrandListHandler(ICarRepostory carRepostory)
        {
            this.carRepostory = carRepostory;
        }

        public async Task<List<SelectListItem>> Handle(BrandList request, CancellationToken cancellationToken)
        {
            return await carRepostory.BrandList();
        }
    }
}

