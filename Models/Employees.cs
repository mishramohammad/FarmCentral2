using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmCentral2.Models
{
    public partial class Employees
    {
        public int EId { get; set; }
        public string Ename { get; set; }
        public string Esurname { get; set; }
        public string Email { get; set; }
        public string Eusername { get; set; }
        public string Password { get; set; }
    }
}
