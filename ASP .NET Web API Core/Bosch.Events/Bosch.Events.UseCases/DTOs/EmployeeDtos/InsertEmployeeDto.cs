using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.UseCases.DTOs.EmployeeDtos
{
    public class InsertEmployeeDto
    {
        public string? EmployeeName { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }


        public string? Phone { get; set; }

        public string? Skillsets { get; set; }

        public string? Avatar { get; set; }

        public DateTime JoiningDate { get; set; }

        public int UserId { get; set; }
    }
}
