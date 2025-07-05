
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyBranchsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public CompanyBranchsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CompanyBranch>> Get()
        {
            var data = await _unitOfWork.CompanyBranchRepo.GetAll(null, null);
            return data.ToList();
        }
        [HttpPost]
        public async Task<IActionResult> Post(CompanyBranch entity)
        {
            entity.CreatedBy = User.Identity?.Name ?? "Not authenticated";
            entity.CreatedDate = DateTime.Now.Date;
            entity.IsActive = true;
            await _unitOfWork.CompanyBranchRepo.Add(entity);
            _unitOfWork.save();
            return Created("", entity);

        }
    }
}
