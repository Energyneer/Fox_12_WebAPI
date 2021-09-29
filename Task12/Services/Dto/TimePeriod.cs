using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class TimePeriod
    {
        [Required]
        public DateTime beginTime { get; set; }

        [Required]
        public DateTime endTime { get; set; }
    }
}
