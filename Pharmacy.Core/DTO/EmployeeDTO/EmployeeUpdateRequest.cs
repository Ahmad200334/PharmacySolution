using Pharmacy.Core.Domain.Entities.IdentityEntities;
using Pharmacy.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Core.DTO.EmployeeDTO
{
    public class EmployeeUpdateRequest
    {
        [Required]
        public int EmployeeID { set; get; }
         
        public string? Name { set; get; }

        [Required]
        public string? Email { set; get; }

        [RegularExpression("^(\\d{1,15})$")]
        public string? phone { set; get; }

        public DateTime? HireDate { set; get; }

        public string ? Password { set; get; }

        public float? Salary { set; get; }

        public enEmployeeRole? EnEmployeeRole { set; get; }

         
        public Employee ToEmployee()
        {
            return new Employee()
            {
                Salary = this.Salary,
                HireDate = this.HireDate,


            };
        }
    }
}