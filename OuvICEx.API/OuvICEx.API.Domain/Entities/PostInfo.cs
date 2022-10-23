namespace OuvICEx.API.Domain.Entities
{
    public class PostInfo
    {
        public string? Content { get; set; }
        public string? Context { get; set; }
        public string? AuthorDepartament { get; set; }
        public string? TargetDepartament { get; set; }

        public bool IsVisible { get; set; }
        public bool IsResolved { get; set; }

        public string? CreatedDate { get; set; }
    }
}