using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPackagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductPackagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<List<ProductPackage>> Get()
        {
            var data = await _unitOfWork.ProductPackageRepo.GetAll(null, null);
            return data.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPackage>> Get(int id)
        {
            var entity = await _unitOfWork.ProductPackageRepo.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductPackage productPackage)
        {
            productPackage.CreatedBy = User.Identity?.Name ?? "Not authenticated";
            productPackage.CreatedDate = DateTime.Now;
            productPackage.IsActive = true;

            await _unitOfWork.ProductPackageRepo.Add(productPackage);
            await _unitOfWork.Save();

            return CreatedAtAction(nameof(Get), new { id = productPackage.ID }, productPackage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductPackage productPackage)
        {
            var existing = await _unitOfWork.ProductPackageRepo.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = productPackage.Name;
            existing.Description = productPackage.Description;
            existing.IsActive = productPackage.IsActive;
            existing.ModifiedBy = User.Identity?.Name ?? "Not authenticated";
            existing.ModifiedDate = DateTime.Now;

            _unitOfWork.ProductPackageRepo.Update(existing);
            await _unitOfWork.Save();

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.ProductPackageRepo.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }

            _unitOfWork.ProductPackageRepo.Delete(entity);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}




//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using POS_Inventory_System.Models;
//using POS_Inventory_System.Repositories.Base;

//namespace POS_System.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductPackagesController : ControllerBase
//    {
//        private IUnitOfWork _unitOfWork;
//        public ProductPackagesController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        [HttpGet]
//        public async Task<List<ProductPackage>>Get()
//       {
//            var data = await _unitOfWork.ProductPackageRepo.GetAll(null, null);
//                return data.ToList();

//       }
//        [HttpPost]
//        public async Task<IActionResult> Post(ProductPackage productPackage)
//        {
//            productPackage.CreatedBy = User.Identity?.Name ?? "Not authenticated";
//            productPackage.CreatedDate=DateTime.Now;
//            productPackage.IsActive=true;
//            await _unitOfWork.ProductPackageRepo.Add(productPackage);
//            _unitOfWork.save();
//            return Created("",productPackage);

//        }
//    }
//}
