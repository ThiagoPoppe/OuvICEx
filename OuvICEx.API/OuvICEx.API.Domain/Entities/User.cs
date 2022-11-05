using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OuvICEx.API.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "{0} length must be less than {1}")]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "{0} length must be less than {1}")]
        public string? Password { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey("DepartamentId")]
        public Departament? TargetDepartament { get; set; }
    }
}
