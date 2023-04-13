using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Threading.Tasks;

namespace IntexMummy11.Controllers
{
    [ApiController]
    [Route("Api/Score")]
    public class InferenceController : ControllerBase
    {
        private InferenceSession _session;

        public InferenceController(InferenceSession session)
        {
            _session = session;
        }

        [HttpPost]
        public ActionResult Score(BoneData data)
        {
            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });
            Tensor<string> score = result.First().AsTensor<string>();
            var categories = new[] { "E", "W" };
            int predictionIndex = Array.IndexOf(score.ToArray(), score.Max());
            var prediction = new Prediction { PredictedValue = categories[predictionIndex] }; ;
            result.Dispose();
            return Ok(prediction);
        }
    }
}
