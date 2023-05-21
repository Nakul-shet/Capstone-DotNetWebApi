namespace coreWebAngularCapstoneProject.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }

        public string MedicineName { get; set; }

        public int MedicinePrice { get; set; }

        public string MedicineImage { get; set; }

        public string Seller { get; set; }

        public string MedicineDescription { get; set; }

        public Category? Category { get; set; }

        public int CategoryId { get; set; }
    }
}
