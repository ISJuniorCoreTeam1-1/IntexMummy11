using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IntexMummy11.Models
{
    public partial class Newsarticle
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Urltoimage { get; set; }
        public string Url { get; set; }
    }
}
