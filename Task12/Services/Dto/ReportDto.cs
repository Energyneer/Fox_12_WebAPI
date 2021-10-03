using System.Collections.Generic;

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
