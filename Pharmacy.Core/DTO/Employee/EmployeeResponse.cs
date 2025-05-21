using Pharmacy.Core.Domain.Entities.IdentityEntities;
using Pharmacy.Core.DTO.EmployeeDTO;
using Pharmacy.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.DTO.EmployeeDTO
{
    public class EmployeeResponse
    {

        public int EmployeeID { set; get; }

        public string? Name { set; get; }

        public string? Email { set; get; }

        public string? phone { set; get; }

        public DateTime? HireDate { set; get; }

        public float? Salary { set; get; }
         
        public string? Role { set; get; }
    } 
}



 

public static class EmployeeExtension
        {

    public static  EmployeeResponse ToEmployeeResponse(this Employee employee)
    {

        return new EmployeeResponse()
        {
           
            HireDate = employee.HireDate,
            Name = employee.User.UserName,
            EmployeeID = employee.EmployeeID,
            Salary = employee.Salary,
            Email=employee.User.Email,
            phone=employee.User.PhoneNumber,
 
        };

    } 

        }


