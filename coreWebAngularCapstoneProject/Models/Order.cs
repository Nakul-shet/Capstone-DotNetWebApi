using System.ComponentModel.DataAnnotations;

namespace coreWebAngularCapstoneProject.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<User> Users { get; set; }
        public int UserId { get; set; }

        public List<Medicine> Medicines { get; set; }

        public int MedicineId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? OrderedDate { get; set; }
    }
}
