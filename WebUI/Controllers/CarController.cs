using System.Threading;
using Application.Commands.Cars;
using Application.DTOs;
using Application.Queries.Cars;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IMediator mediator;

        public CarController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> SearchForm()
        {
            ViewData["BrandId"] = await mediator.Send(new BrandList());
            return View();
        }

        public async Task<IActionResult> SearchByBrand(int id)
        {
            var cars = await mediator.Send(new SearchByBrandQuery(id));
            return View("Index", cars);
        }

        public async Task<IActionResult> Index()
        {
            var cars = await mediator.Send(new AllCars());
            return View(cars);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["BrandId"] = await mediator.Send(new BrandList());
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateDTO carCreateDTO)
        {
            try
            {
                var car = await mediator.Send(new CarCreate(carCreateDTO));
                if (!car)
                {
                    return RedirectToAction("Create", "Dealer");
                }
                return RedirectToAction("MyCars", "Dealer");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var car = await mediator.Send(new EditQuery(id));

            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarEditDTO carEditDTO)
        {

            var carEdit = await mediator.Send(new Edit(id, carEditDTO));

            if (ModelState.IsValid)
            {
                if (!carEdit)
                {
                    return BadRequest();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(carEdit);
        }     

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await mediator.Send( new DeleteQuery(id));
            return View(car);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            var car = await mediator.Send(new Delete(id));

            if (!car)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Car");
        }
    }
}
