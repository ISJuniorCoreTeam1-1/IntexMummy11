using PostgresCRUD.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexMummy11.Models
{
    public class EFBurialRepository: IBurialRepository
    {
        private ebdbContext context { get; set; }
        public EFBurialRepository(ebdbContext temp)
        {
            context = temp;
        }

        public IQueryable<Burialmain> Burials => context.Burialmain;

    }
}