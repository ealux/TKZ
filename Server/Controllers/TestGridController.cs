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
        public async Task<string> Get()
        {
            return await System.IO.File.ReadAllTextAsync("IEEE 14-bus modified test system.json");            
        }
    }
}
