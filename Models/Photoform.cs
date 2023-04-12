using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IntexMummy11.Models
{
    public partial class Photoform
    {
        public long Id { get; set; }
        public string Area { get; set; }
        public string Squarenorthsouth { get; set; }
        public string Tableassociation { get; set; }
        public string Filename { get; set; }
        public string Photographer { get; set; }
        public string Burialnumber { get; set; }
        public string Squareeastwest { get; set; }
        public string Eastwest { get; set; }
        public string Northsouth { get; set; }
        public DateTime? Photodate { get; set; }
    }
}
