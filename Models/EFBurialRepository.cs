﻿using PostgresCRUD.DataAccess;
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

        public IQueryable<Minitable> Data => context.Data;

        public void Add(Burialmain burial)
        {
            context.Burialmain.Add(burial);
        }

        public void Update(Burialmain burial)
        {
            context.Burialmain.Update(burial);
        }

        public void Delete(Burialmain burial)
        {
            context.Burialmain.Remove(burial);
        }


        public void Save()
        {
            context.SaveChanges();
        }
    }
}