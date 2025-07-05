using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountrysController : ControllerBase
    {
        private  IUnitOfWork _unitOfWork;
        public CountrysController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Country>>Get()
        {
            var data = await _unitOfWork.CountryRepo.GetAll(null, null);
            return data.ToList();
        }
        public async Task<IActionResult>Post (Country country)
        {
            country.CreatedBy = User.Identity?.Name ?? "Not authenticated";
            country.CreatedDate= DateTime.Now;
            country.IsActive = true;
            await _unitOfWork.CompanyBranchRepo.Add(country);
            _unitOfWork.save();
            return Created("", country);
        }
    }
}
