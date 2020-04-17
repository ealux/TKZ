using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
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
            using (StreamWriter file = new StreamWriter(Environment.CurrentDirectory + "/feedbacks.json", append: true))
            {
                await file.WriteLineAsync(JsonConvert.DeserializeObject<Feedback>(context.ToString()).ToString());
            }
        }
    }
}