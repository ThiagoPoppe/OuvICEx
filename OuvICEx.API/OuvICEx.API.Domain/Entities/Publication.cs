using OuvICEx.API.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OuvICEx.API.Domain.Entities
{
    public class Publication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1080, ErrorMessage = "{0} length must be less than {1}")]
        public string Text { get; set; }

        [Required]
        public PublicationStatus Status { get; set; }

        [Required]
        public PublicationContext Context { get; set; }

        [Required]
        public bool PermissionToPublicate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        //public int? UserId { get; set; }
        //public int? TargetDepartamentId { get; set; }

        //[ForeignKey("UserId")]
        //public User? User { get; set; }

        //[ForeignKey("TargetDepartamentId")]
        //public Departament? TargetDepartament { get; set; }

        [StringLength(32, ErrorMessage = "{0} length must be less than {1}")]
        public string? Title { get; set; }
    }
}
