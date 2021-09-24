using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class TypeDto
    {
        [Required]
        public BaseType OperationType { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
