using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipalityManagementSystem.Models
{
    public class Citizen
    {
        public int CitizenID { get; set; }
    public required string FullName { get; set; }
    public required string Address { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime RegistrationDate { get; set; }
    }
}