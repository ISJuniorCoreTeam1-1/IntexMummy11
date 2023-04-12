using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IntexMummy11.Models
{
    public partial class Photodata
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Filename { get; set; }
        public int? Photodataid { get; set; }
        public DateTime? Date { get; set; }
        public string Url { get; set; }
    }
}
