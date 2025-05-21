using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Domain.Entities
{
    public class Medicine
    {  
        [Key]
        [ForeignKey("Product")]
        public int ProductID { set; get; } //this is Fk and PK

        public Product? Product { set; get; }

        public string? Name { set; get; }
         
        public string? Manufacturer { set; get; }

        public string? ActiveIngredient { set; get; }
         

        [ForeignKey("Category")]
        public int CategoryID { set; get; }
        public MedicineCategory? Category { set; get; }


        [ForeignKey("MedicineType")]         
        public int MedicineTypeId { get; set; }  
         
        public MedicineType? MedicineType { get; set; }  // Navigation
     
    }
}
