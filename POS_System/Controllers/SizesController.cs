using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SizesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Size>>> Get()
        {
            var data = await _unitOfWork.SizeRepo.GetAll(null, null);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Size size)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            size.CreatedBy = User.Identity?.Name ?? "System";
            size.CreatedDate = DateTime.Now;
            size.IsActive = true;

            await _unitOfWork.SizeRepo.Add(size);
            await _unitOfWork.Save();

            return CreatedAtAction(nameof(Get), new { id = size.ID }, size);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Size size)
        {
            if (!ModelState.IsValid || id != size.ID)
                return BadRequest();

            size.ModifiedDate = DateTime.Now;

            _unitOfWork.SizeRepo.Update(size);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.SizeRepo.GetById(id);
            if (item == null)
                return NotFound();

            _unitOfWork.SizeRepo.Delete(item);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
