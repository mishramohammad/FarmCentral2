using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmCentral2.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string TypeOfProduct { get; set; }
        public int? FarmerId { get; set; }
    }
}
