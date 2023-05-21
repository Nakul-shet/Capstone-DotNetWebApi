using coreWebAngularCapstoneProject.DAL;
using coreWebAngularCapstoneProject.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace coreWebAngularCapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {

        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [EnableCors]
        [HttpGet("GetMedicines")]
        public async Task<List<Medicine>> GetMedicineListAsync()
        {
            try
            {
                return await _medicineService.GetMedicinesListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [HttpGet("GetMedicineById")]
        public async Task<IEnumerable<Medicine>> GetMedicineByIdAsync(int Id)
        {
            try
            {
                var response = await _medicineService.GetMedicineByIdAsync(Id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [HttpGet("GetMedicineByCategoryId")]
        public async Task<IEnumerable<Medicine>> GetMedicineByCategoryIdAsync(int Id)
        {
            try
            {
                var response = await _medicineService.GetMedicineByCategoryId(Id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [HttpPost("AddMedicine")]
        public async Task<int> AddNewProductAsync(Medicine medicine)
        {
            try
            {
                var response = await _medicineService.AddMedicineAsync(medicine);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [HttpPut("UpdateMedicineById")]
        public async Task<int> UpdateProductByIdAsync(Medicine medicine, int id)
        {
            try
            {
                var response = await _medicineService.UpdateMedicineAsync(medicine, id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [HttpDelete("DeleteMediceById")]
        public async Task<int> DeleteProductById(int id)
        {
            try
            {
                var response = await _medicineService.DeleteMedicineAsync(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
