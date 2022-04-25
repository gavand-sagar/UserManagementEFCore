using System;
using System.Collections.Generic;

namespace UserManagement.Entities
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
