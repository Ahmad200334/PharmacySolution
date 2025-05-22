using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.DTO.SupplierDTO
{
   public class SupplierUpdateRequest
    {
        [Required]
        public int SupplierID { set; get; }
         
        [StringLength(50, MinimumLength = 3)]
        public string? Name { set; get; }

        [RegularExpression("^(\\d{1,15})$")]
         public string Phone { set; get; }

         public string Email { set; get; }


        public Supplier ToSupplier()
        {
            return new Supplier()
            {
                Email = this.Email,
                Name = this.Name,
                Phone = this.Phone,

            };

        }
    }
    }

