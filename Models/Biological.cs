using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IntexMummy11.Models
{
    public partial class Biological
    {
        public long Id { get; set; }
        public int? Racknumber { get; set; }
        public int? Bagnumber { get; set; }
        public string Previouslysampled { get; set; }
        public string Initials { get; set; }
        public int? Clusternumber { get; set; }
        public DateTime? Date { get; set; }
        public string Notes { get; set; }
    }
}
