using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexMummy11.Models
{
    public interface IBurialRepository
    {
        IQueryable<Burialmain> Burials { get; }

        IQueryable<Minitable> Data { get; }

        void Add(Burialmain burial);

        void Update(Burialmain burial);

        void Delete(Burialmain burial);
        void Save();
    }
}
