using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemsController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<List<Item>> Get()
        {
            var data = await _unitOfWork.ItemRepo.GetAll(null, null);
            return data.ToList();
        }

        // POST: api/Items
        [HttpPost]
        public async Task<IActionResult> Post(Item entity)
        {
            entity.CreatedBy = User.Identity?.Name ?? "Not authenticated";
            entity.CreatedDate = DateTime.Now.Date;
            entity.IsActive = true;
            await _unitOfWork.ItemRepo.Add(entity);
            _unitOfWork.save();
            return Created("", entity);
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Item entity)
        {
            var existing = await _unitOfWork.ItemRepo.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = entity.Name;
            existing.Description = entity.Description;
            existing.IsActive = entity.IsActive;
            existing.ModifiedBy = User.Identity?.Name ?? "Not authenticated";
            existing.ModifiedDate = DateTime.Now;

            _unitOfWork.ItemRepo.Update(existing);
            _unitOfWork.save();

            return Ok(existing);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.ItemRepo.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }

            _unitOfWork.ItemRepo.Delete(entity);
            _unitOfWork.save();

            return NoContent();
        }
    }
}
