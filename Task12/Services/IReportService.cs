using Domain;
using Services.Dto;
using System;

namespace Services
{
    public interface IReportService
    {
        ReportDto Get(User user, string typeName = null, DateTime? startTime = null, DateTime? endTime = null);
    }
}
