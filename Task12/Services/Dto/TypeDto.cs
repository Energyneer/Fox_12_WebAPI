using Domain;
using System.ComponentModel.DataAnnotations;

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
        STANDART,
        USER
    }
}
