namespace OuvICEx.API.Domain.Entities
{
    public class PostSelectionFilter
    {
        public string? Context { get; set; }
        public string? AuthorDepartament { get; set; }
        public string? TargetDepartament { get; set; }
        public bool? IsResolved { get; set; }
    }
}
