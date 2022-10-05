using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Interfaces
{
    public interface ICarRepostory
    {
        Task<List<CarViewDTO>> GetAllCars();
        Task<bool> CarCreate(CarCreateDTO carCreateDTO);
        Task<bool> Delete(int id);
        Task<Car> DeleteGet(int id);
        Task<bool> Edit(int carId, CarEditDTO carEditDTO);
        Task<CarEditDTO> Edit(int id);
        Task<List<CarViewDTO>> SortByBrand(int id);
        Task<List<SelectListItem>> BrandList();
    }
}
