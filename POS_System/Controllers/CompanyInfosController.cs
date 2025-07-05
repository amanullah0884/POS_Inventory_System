using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using POS_Inventory_System.Repositories.Child;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyInfosController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public CompanyInfosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CompanyInfo>> Get()
        {
            var data = await _unitOfWork.CompanyRepo.GetAll(null, null);
            return data.ToList();
        }
        [HttpPost]
        public async Task<IActionResult> Post(CompanyInfo entity)
        {
            await _unitOfWork.CompanyRepo.Add(entity);
            _unitOfWork.save();
            return Created("", entity);

        }

        //Aman
    }
}