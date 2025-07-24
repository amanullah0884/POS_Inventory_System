using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseMastersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PurchaseMastersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<List<PurchaseMasters>> Get()
        {
            var data = await _unitOfWork.PurchaseMastersRepo.GetAll(null, null);
            return data.ToList();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            var find = await _unitOfWork.PurchaseMastersRepo.GetById(id);
            if (find == null)
            {
                return NotFound();
            }
            return Ok(find);
        }
        //[HttpPost]
        //public async Task<IEnumerable<>>
     }
}

