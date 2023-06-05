using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmCentral2.Models
{
    public partial class Farmers
    {
        public int FId { get; set; }
        public string Fname { get; set; }
        public string Fsurname { get; set; }
        public string Femail { get; set; }
        public string Fusername { get; set; }
        public string Fpassword { get; set; }
    }
}
