using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexMummy11.Models
{
    public interface IBurialRepository
    {
        IQueryable<Burialmain> Burials { get; }
    }
}
