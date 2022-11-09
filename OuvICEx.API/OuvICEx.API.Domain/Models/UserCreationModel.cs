namespace OuvICEx.API.Domain.Models
{
    public class UserCreationModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? DepartamentId { get; set; }
    }
}


