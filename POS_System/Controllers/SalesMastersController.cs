using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesMastersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesMastersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesMaster>>> Get()
        {
            var data = await _unitOfWork.SalesMasterRepo.GetAll(null, null);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SalesMaster salesMaster)
        {
            salesMaster.CreatedBy = User.Identity?.Name ?? "Anonymous";
            salesMaster.CreatedDate = DateTime.Now;
            salesMaster.IsActive = true;

            await _unitOfWork.SalesMasterRepo.Add(salesMaster);
            await _unitOfWork.Save();

            return CreatedAtAction(nameof(Get), new { id = salesMaster.ID }, salesMaster);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SalesMaster salesMaster)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _unitOfWork.SalesMasterRepo.GetById(id);
            if (existing == null)
                return NotFound();

            existing.SalesDate = salesMaster.SalesDate;
            existing.TotalQuantity = salesMaster.TotalQuantity;
            existing.TotalPrice = salesMaster.TotalPrice;
            existing.VoucherNo = salesMaster.VoucherNo;
            existing.BillNo = salesMaster.BillNo;
            existing.TDiscountrate = salesMaster.TDiscountrate;
            existing.TVatrate = salesMaster.TVatrate;
            existing.TDiscountamount = salesMaster.TDiscountamount;
            existing.TVatamount = salesMaster.TVatamount;
            existing.Paidamount = salesMaster.Paidamount;
            existing.Due = salesMaster.Due;
            existing.Convence = salesMaster.Convence;
            existing.Packing = salesMaster.Packing;
            existing.Note = salesMaster.Note;
            existing.PaymentModeId = salesMaster.PaymentModeId;
            existing.CustomerID = salesMaster.CustomerID;
            existing.VoucherTypeID = salesMaster.VoucherTypeID;
            existing.CompanyId = salesMaster.CompanyId;
            existing.BranchID = salesMaster.BranchID;
            existing.IsActive = salesMaster.IsActive;
            existing.ModifiedBy = User.Identity?.Name ?? "Anonymous";
            existing.ModifiedDate = DateTime.Now;

            _unitOfWork.SalesMasterRepo.Update(existing);
            await _unitOfWork.Save();

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _unitOfWork.SalesMasterRepo.GetById(id);
            if (existing == null)
                return NotFound();

            _unitOfWork.SalesMasterRepo.Delete(existing);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
