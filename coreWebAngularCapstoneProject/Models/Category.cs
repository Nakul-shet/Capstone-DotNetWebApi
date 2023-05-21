using System.ComponentModel.DataAnnotations;

namespace coreWebAngularCapstoneProject.Models
{
    public class Category
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }

        public List<Medicine>? Medicines { get; set; }

    }
}
