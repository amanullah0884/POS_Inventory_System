using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            var data = await _unitOfWork.CategoryRepo.GetAll(null, null);
            return Ok(data.ToList());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await _unitOfWork.CategoryRepo.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

       
        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            category.CreatedBy = User.Identity?.Name ?? "Anonymous";
            category.CreatedDate = DateTime.Now;
            category.IsActive = true;

            await _unitOfWork.CategoryRepo.Add(category);
            await _unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = category.ID }, category);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Category updatedCategory)
        {
            var existing = await _unitOfWork.CategoryRepo.GetById(id);
            if (existing == null)
                return NotFound();

            existing.Name = updatedCategory.Name;
            existing.ShortCode = updatedCategory.ShortCode;
            existing.ParentId = updatedCategory.ParentId;
            existing.Description = updatedCategory.Description;
            existing.IsActive = updatedCategory.IsActive;
            existing.ModifiedBy = User.Identity?.Name ?? "Anonymous";
            existing.ModifiedDate = DateTime.Now;

            _unitOfWork.CategoryRepo.Update(existing);
            await _unitOfWork.Save();

            return Ok(existing);
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _unitOfWork.CategoryRepo.GetById(id);
            if (category == null)
                return NotFound();

            _unitOfWork.CategoryRepo.Delete(category);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
