using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private IReportService _reportService;
        private IAccountService _accountService;

        public ReportController(IReportService reportService, IAccountService accountService)
        {
            _reportService = reportService;
            _accountService = accountService;
        }

        [HttpGet]
        public ReportDto GetReport(string? typename, DateTime? timestart, DateTime? timeend)
        {
            User user = _accountService.GetByUserName(User.Identity.Name);
            return _reportService.Get(user, typename, timestart, timeend);
        }
    }
}
