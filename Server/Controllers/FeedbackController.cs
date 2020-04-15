using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TKZ.Shared;
using Newtonsoft.Json;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TKZ.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {

        //private readonly ILogger<FeedbackController> logger;

        //public FeedbackController(ILogger<FeedbackController> logger)
        //{
        //    this.logger = logger;
        //}

        // POST <FeedbackController>
        [HttpPost]
        public async Task Post(object context)
        {
            //Feedback fb = JsonConvert.DeserializeObject<Feedback>(context);
            using (StreamWriter file = new StreamWriter(Environment.CurrentDirectory+"/feedbacks.json", append: true))
            {
                Feedback fb = JsonConvert.DeserializeObject<Feedback>(context.ToString());
                await Task.Run(()=>file.WriteLineAsync(fb.ToString()));
            }
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
