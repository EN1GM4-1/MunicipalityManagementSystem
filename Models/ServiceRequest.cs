using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipalityManagementSystem.Models
{
    public class ServiceRequest
    {
    public int ServiceRequestID { get; set; }
    public int CitizenID { get; set; }
    public required string RequestType { get; set; }
    public required string Description { get; set; }
    public DateTime RequestDate { get; set; }
    public required string Status { get; set; }
    }
}