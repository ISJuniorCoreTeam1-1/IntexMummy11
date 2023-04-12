using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IntexMummy11.Models
{
    public partial class Yarnmanipulation
    {
        public long Id { get; set; }
        public string Thickness { get; set; }
        public string Angle { get; set; }
        public string Manipulation { get; set; }
        public string Material { get; set; }
        public string Count { get; set; }
        public string Component { get; set; }
        public string Ply { get; set; }
        public int? Yarnmanipulationid { get; set; }
        public string Direction { get; set; }
    }
}
