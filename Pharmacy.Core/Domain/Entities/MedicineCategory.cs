namespace Pharmacy.Core.Domain.Entities
{
    public class MedicineCategory
    {
        public int MedicineCategoryID { set; get; }

        public string ? Name { set; get; }

        public ICollection<Medicine>? Medicines { set; get; }
    }
}