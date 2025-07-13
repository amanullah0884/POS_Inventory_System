// ColorsController.cs
using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ColorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> Get()
        {
            var colors = await _unitOfWork.ColorRepo.GetAll(null, null); // null পাস দিতে হতে পারে, তোমার রেপোসিটরি অনুসারে
            return Ok(colors);
        }


    
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> Get(int id)
        {
            var color = await _unitOfWork.ColorRepo.GetById(id);
            if (color == null)
                return NotFound();

            return Ok(color);
        }

     
        [HttpPost]
        public async Task<IActionResult> Post(Color entity)
        {
            entity.CreatedBy = User.Identity?.Name ?? "Anonymous";
            entity.CreatedDate = DateTime.UtcNow;
            entity.IsActive = true;

            await _unitOfWork.ColorRepo.Add(entity);
            await _unitOfWork.Save();

            return CreatedAtAction(nameof(Get), new { id = entity.ID }, entity);
        }

   
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Color entity)
        {
            var existing = await _unitOfWork.ColorRepo.GetById(id);
            if (existing == null)
                return NotFound();

            existing.Name = entity.Name;
            existing.Description = entity.Description;
            existing.IsActive = entity.IsActive;
            existing.ModifiedBy = User.Identity?.Name ?? "Anonymous";
            existing.ModifiedDate = DateTime.UtcNow;

            _unitOfWork.ColorRepo.Update(existing);
            await _unitOfWork.Save();

            return Ok(existing);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var color = await _unitOfWork.ColorRepo.GetById(id);
            if (color == null)
                return NotFound();

            _unitOfWork.ColorRepo.Delete(color);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
