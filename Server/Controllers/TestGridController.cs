using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TKZ.Shared;
using System.IO;
using Newtonsoft.Json;

namespace TKZ.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestGridController : ControllerBase
    {
        // GET
        [HttpGet]
        public Grid Get()
        {
            Grid g = JsonConvert.DeserializeObject<Grid>(System.IO.File.ReadAllText("IEE 14-bus modified test system.json"));
            return g;
        }
    }
}
