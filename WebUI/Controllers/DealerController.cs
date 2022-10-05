using Application.Commands.Dealer;
using Application.DTOs;
using Application.Queries.Dealer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebUI.Controllers
{
    public class DealerController : Controller
    {
        private readonly IMediator mediator;

        public DealerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(DealerDTO dealerDTO)
        {
            var dealer = await mediator.Send(new CreateDealer());//CreateDealer(dealerDTO);
            if (!dealer)
            {
                return View(dealer);
            }
            return RedirectToAction("Index", "Car");
        }

        [Authorize]
        public async Task<IActionResult> MyCars(CancellationToken cancellationToken)
        {
            var myCars = await mediator.Send(new MyCars());//DealerCars(cancellationToken);

            return View(myCars);
        }

    }
}
