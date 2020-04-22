using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TKZ.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TKZ.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        // POST <"Feedback">
        [HttpPost]
        public async Task Post(object context)
        {
            var fed = JsonConvert.DeserializeObject<Feedback>(context.ToString());
            var list = JsonConvert.DeserializeObject<List<Feedback>>(System.IO.File.ReadAllText("feedbacks.json"));
            list.Add(fed);
            System.IO.File.WriteAllText("feedbacks.json", JsonConvert.SerializeObject(list, Formatting.Indented));
        }
    }
}