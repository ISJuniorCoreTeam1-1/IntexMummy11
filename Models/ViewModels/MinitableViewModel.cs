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
        public string SexFilter { get; set; }
        public string AgeFilter { get; set; }
        public string TextileColorFilter { get; set; }
        public string TextileStructureFilter { get; set; }
        public string TextileFunctionFilter { get; set; }
        public string HairColorFilter { get; set; }
        public decimal BurialDepthFilterMin { get; set; }
        public decimal BurialDepthFilterMax { get; set; }
        public string EstimatedStatureFilter { get; set; }
        public string HeadDirectionFilter { get; set; }
        public string BurialWrappingFilter { get; set; }
        public string FaceBundleFilter { get; set; }
        public long BurialIDForDescription { get; set; }
        public long Burialidfordelete { get; set; }
        



    }
}
