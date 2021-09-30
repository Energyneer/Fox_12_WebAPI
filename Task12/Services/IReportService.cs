using Domain;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IReportService
    {
        ReportDto Get(User user, string typeName = null, DateTime? startTime = null, DateTime? endTime = null);
    }
}
