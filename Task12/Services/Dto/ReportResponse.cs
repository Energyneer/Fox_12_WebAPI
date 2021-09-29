using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class ReportResponse
    {
        public decimal Balance { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpend { get; set; }
        public Dictionary<TypeDto, decimal> Details { get; set; }

        public ReportResponse()
        {
            Details = new Dictionary<TypeDto, decimal>();
        }
    }
}
