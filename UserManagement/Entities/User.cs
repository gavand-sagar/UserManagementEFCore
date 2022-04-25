using System;
using System.Collections.Generic;

namespace UserManagement.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? City { get; set; }
    }
}
