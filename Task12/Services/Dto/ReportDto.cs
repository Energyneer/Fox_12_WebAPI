using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class ReportDto
    {
        public decimal Balance { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpend { get; set; }
        public Dictionary<string, decimal> Details { get; set; }

        public ReportDto()
        {
            Details = new Dictionary<string, decimal>();
        }
    }
}
