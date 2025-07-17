using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System.Threading.Tasks;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Brand>>> Get()
        {
            var data = await _unitOfWork.BrandRepo.GetAll(null, null);
            return Ok(data.ToList());
        }

        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(Brand entity)
        {
            entity.CreatedBy = User.Identity?.Name ?? "Anonymous";
            entity.CreatedDate = DateTime.Now;
            entity.IsActive = true;

            await _unitOfWork.BrandRepo.Add(entity);
            await _unitOfWork.Save();

            return CreatedAtAction(nameof(Get), new { id = entity.ID }, entity);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, Brand entity)
        {
            var existing = await _unitOfWork.BrandRepo.GetById(id);
            if (existing == null)
                return NotFound();

            existing.Name = entity.Name;
            existing.Description = entity.Description;
            existing.IsActive = entity.IsActive;
            existing.ModifiedBy = User.Identity?.Name ?? "Anonymous";
            existing.ModifiedDate = DateTime.Now;

            _unitOfWork.BrandRepo.Update(existing);
            await _unitOfWork.Save();

            return Ok(existing);
        }

   
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.BrandRepo.GetById(id);
            if (entity == null)
                return NotFound();

            _unitOfWork.BrandRepo.Delete(entity);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
