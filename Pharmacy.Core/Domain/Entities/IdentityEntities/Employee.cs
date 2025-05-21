using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Domain.Entities.IdentityEntities
{
  public  class Employee
    {
        [Key]
        public int EmployeeID { set; get; }
        
        [Required]
        public DateTime? HireDate { set; get; }

        public float ? Salary { set; get; }

        // الربط مع المستخدم من Identity
        public Guid? UserId { get; set; }

        public ApplicationUser? User { get; set; }

        public ICollection<Sale>? Sales { get; set; }

        public ICollection<StockMovement>? StockMovements { get; set; }

    }
}
