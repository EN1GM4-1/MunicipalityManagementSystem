using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipalityManagementSystem.Models
{
    public class Report
    {
    public int ReportID { get; set; }
    public int ServiceRequestID { get; set; }
    public int StaffID { get; set; }
    public DateTime ReportDate { get; set; }
    public required string ReportDetails { get; set; }
    public bool IsResolved { get; set; }
    }
}