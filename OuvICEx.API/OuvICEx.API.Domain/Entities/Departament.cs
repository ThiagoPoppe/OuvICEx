using System.ComponentModel.DataAnnotations;

namespace OuvICEx.API.Domain.Entities
{
    public class Departament
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "{0} length must be less than {1}")]
        public string? Name { get; set; }
    }
}
