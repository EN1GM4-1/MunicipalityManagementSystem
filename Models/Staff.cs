using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipalityManagementSystem.Models
{
    public class Staff
    {
    public int StaffID { get; set; }
    public required string FullName { get; set; }
    public required string Position { get; set; }
    public required string Department { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime DateHired { get; set; }
    }
}