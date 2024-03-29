﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using TKZ.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TKZ.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        // POST <"Feedback">
        [HttpPost]
        public async Task Post([FromBody]object context)
        {
            var fed = JsonConvert.DeserializeObject<Feedback>(context.ToString());
            var list = JsonConvert.DeserializeObject<List<Feedback>>(System.IO.File.ReadAllText("feedbacks.json"));
            list.Add(fed);
            await System.IO.File.WriteAllTextAsync("feedbacks.json", JsonConvert.SerializeObject(list, Formatting.Indented));
        }
    }
}