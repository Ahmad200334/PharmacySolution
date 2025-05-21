namespace Pharmacy.Core.Domain.Entities
{
    public class MedicineType
    {
        public int Id { get; set; }

        public string? Name { get; set; }  // مثلًا: شراب، أقراص، كريم

        public ICollection<Medicine>? Medicines { get; set; }
    }

}