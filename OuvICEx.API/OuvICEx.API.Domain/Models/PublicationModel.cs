using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OuvICEx.API.Domain.Models
{
    public class PublicationModel
    { 
        public string Text { get; set; }
        public string Title { get; set; }

        public PublicationStatus Status { get; set; }
        public PublicationContext Context { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? AuthorDepartamentName { get; set; }
        public string? TargetDepartamentName { get; set; }
    }
}
