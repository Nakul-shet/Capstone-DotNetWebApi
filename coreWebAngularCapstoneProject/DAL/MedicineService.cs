using coreWebAngularCapstoneProject.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace coreWebAngularCapstoneProject.DAL
{
    public class MedicineService : IMedicineService
    {

        private readonly ApplicationDBContext _context;

        public MedicineService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Medicine>> GetMedicinesListAsync()
        {
            return await _context.Medicines.FromSqlRaw<Medicine>("GetMedicines").ToListAsync();
        }

        public async Task<IEnumerable<Medicine>> GetMedicineByIdAsync(int id)
        {
            var param = new SqlParameter("@MedicineId", id);

            var productDetails = await Task.Run(() => _context.Medicines
            .FromSqlRaw(@"exec GetMedicineById @MedicineId", param).ToListAsync()
            );

            return productDetails;
        }

        public async Task<IEnumerable<Medicine>> GetMedicineByCategoryId(int id)
        {
            var param = new SqlParameter("@CategoryId", id);

            var productDetails = await Task.Run(() => _context.Medicines
            .FromSqlRaw(@"exec GetMedicineByCategoryId @CategoryId", param).ToListAsync()
            );

            return productDetails;
        }
        public async Task<int> AddMedicineAsync(Medicine medicine)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@MedicineName", medicine.MedicineName));
            parameter.Add(new SqlParameter("@MedicinePrice", medicine.MedicinePrice));
            parameter.Add(new SqlParameter("@MedicineImage", medicine.MedicineImage));
            parameter.Add(new SqlParameter("@MedicineSeller", medicine.Seller));
            parameter.Add(new SqlParameter("@MedicineDescription", medicine.MedicineDescription));
            parameter.Add(new SqlParameter("@MedicineCategory", medicine.CategoryId));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec AddMedicine @MedicineName,
            @MedicinePrice,
            @MedicineImage,
            @MedicineSeller,
            @MedicineDescription,
            @MedicineCategory
            ",
           parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateMedicineAsync(Medicine medicine, int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@MedicineId", id));
            parameter.Add(new SqlParameter("@MedicineName", medicine.MedicineName));
            parameter.Add(new SqlParameter("@MedicinePrice", medicine.MedicinePrice));
            parameter.Add(new SqlParameter("@MedicineImage", medicine.MedicineImage));
            parameter.Add(new SqlParameter("@MedicineSeller", medicine.Seller));
            parameter.Add(new SqlParameter("@MedicineDescription", medicine.MedicineDescription));
            parameter.Add(new SqlParameter("@MedicineCategory", medicine.CategoryId));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec UpdateMedicineById @MedicineId ,@MedicineName,
            @MedicinePrice,
            @MedicineImage,
            @MedicineSeller,
            @MedicineDescription,
            @MedicineCategory
            ",
            parameter.ToArray()));

            return result;
        }

        public async Task<int> DeleteMedicineAsync(int id)
        {
            var param = new SqlParameter("@MedicineId", id);

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec DeleteMediceById @MedicineId", param)
            );

            return result;
        }

    }
}
