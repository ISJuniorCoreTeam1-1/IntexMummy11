using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace IntexMummy11
{
    public class BoneData
    {
        public float squarenorthsouth { get; set; }
        public float depth { get; set; }
        public float squareeastwest { get; set; }
        public float westtohead { get; set; }
        public float length { get; set; }
        public float westtofeet { get; set; }
        public float southtofeet { get; set; }
        public float east_west_E { get; set; }
        public float east_west_W { get; set; }
        public float adults_be_adults_A { get; set; }
        public float adults_be_adults_C { get; set; }
        public float area_NE { get; set; }
        public float area_NNW { get; set; }
        public float area_NW { get; set; }
        public float area_SE { get; set; }
        public float area_SW { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            squarenorthsouth, depth, squareeastwest, westtohead, length, westtofeet,
                southtofeet, east_west_E, east_west_W, adults_be_adults_A,adults_be_adults_C, area_NE,
                area_NNW, area_NW, area_SE, area_SW
            };
            int[] dimensions = new int[] { 1, 16 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}

