using OuvICEx.API.Domain.Enums;

namespace OuvICEx.API.Domain.Models
{
    public class PublicationCreationModel
    {
        public string Text { get; set; }
        
        public PublicationStatus Status { get; set; }
        public PublicationContext Context { get; set; }
        
        public bool PermissionToPublicate { get; set; }

        public string? Title { get; set; }

        public int? UserId { get; set; }
        public int? TargetDepartamentId { get; set; }
    }
}
