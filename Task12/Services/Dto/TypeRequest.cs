using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class TypeRequest
    {
        public Category TypeCategory { get; set; }
        public string TargetUser { get; set; }
    }
}
