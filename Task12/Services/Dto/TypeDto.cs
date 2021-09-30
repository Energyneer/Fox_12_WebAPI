using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class TypeDto
    {
        public int Id { get; set; }

        [Required]
        public Category OperationCategory { get; set; }

        [Required]
        public TypeVariety Variety { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public enum TypeVariety
    {
        //[Description("STANDART")]
        STANDART,
        //[Description("USER")]
        USER
    }
}
