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

        public BrandsController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<List<Brand>> Get()
        {
            var data = await _unitOfWork.BrandRepo.GetAll(null, null);
            return data.ToList();
        }

        // POST: api/Brands
        [HttpPost]
        public async Task<IActionResult> Post(Brand entity)
        {
            entity.CreatedBy = User.Identity?.Name ?? "Not authenticated";
            entity.CreatedDate = DateTime.Now.Date;
            entity.IsActive = true;
            await _unitOfWork.BrandRepo.Add(entity);
            _unitOfWork.save();
            return Created("", entity);
        }

        // PUT: api/Brands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Brand entity)
        {
            var existing = await _unitOfWork.BrandRepo.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = entity.Name;
            existing.Description = entity.Description;
            existing.IsActive = entity.IsActive;
            existing.ModifiedBy = User.Identity?.Name ?? "Not authenticated";
            existing.ModifiedDate = DateTime.Now;

            _unitOfWork.BrandRepo.Update(existing);
            _unitOfWork.save();

            return Ok(existing);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.BrandRepo.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }

            _unitOfWork.BrandRepo.Delete(entity);
            _unitOfWork.save();

            return NoContent();
        }
    }
}
