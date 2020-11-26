using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Core.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
