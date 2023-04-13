using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexMummy11.Models.ViewModels
{
    public class MinitableViewModel
    {
        public IQueryable<Minitable> Data { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
