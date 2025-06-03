 
    using Pharmacy.Core.Enum;
using Pharmacy.Core.Domain.Entities.IdentityEntities;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Core.DTO.EmployeeDTO
{
   public class EmployeeAddRequest
    {
        [Required]
        public string UserName { set; get; }

        [EmailAddress]
        [Required]
        public string Email { set; get; }

        [RegularExpression("^(\\d{1,15})$")]
        public string? phone { set; get; }

        public DateTime? HireDate { set; get; } = DateTime.Now;
        
        
        public float? Salary{ set; get; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "كلمة السر يجب أن تكون أكبر من 8 أحرف")]
        [Required]
        public string  Password { set; get; }

        public ApplicationUser? User { set; get; }

        public Guid UesrId { set; get; }

         

        public Employee ToEmployee()
        {
            return new Employee()
            {
                Salary = this.Salary,
                HireDate = this.HireDate,
                User=User,
                UserId=this.UesrId
               
            };
        }
    }
}
