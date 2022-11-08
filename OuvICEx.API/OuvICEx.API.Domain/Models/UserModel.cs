﻿using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public int? DepartmentId { get; set; }

        public Departament? Departament { get; set; }
    }
}

