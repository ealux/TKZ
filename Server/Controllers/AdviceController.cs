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
    public class AdviceController : ControllerBase
    {
        // about
        [HttpGet("about")]
        public async Task<string> About()
        {
            return await System.IO.File.ReadAllTextAsync("docs/about.html");
        }

        // calc
        [HttpGet("calc")]
        public async Task<string> Calc()
        {
            return await System.IO.File.ReadAllTextAsync("docs/calc.html");
        }

        // docs
        [HttpGet("docs")]
        public async Task<string> Docs()
        {
            return await System.IO.File.ReadAllTextAsync("docs/docs.html");
        }

        // elements
        [HttpGet("elements")]
        public async Task<string> Elements()
        {
            return await System.IO.File.ReadAllTextAsync("docs/elements.html");
        }

        // glossary
        [HttpGet("glossary")]
        public async Task<string> Glossary()
        {
            return await System.IO.File.ReadAllTextAsync("docs/glossary.html");
        }

        // input
        [HttpGet("input")]
        public async Task<string> Input()
        {
            return await System.IO.File.ReadAllTextAsync("docs/input.html");
        }

        // model
        [HttpGet("prep")]
        public async Task<string> Model()
        {
            return await System.IO.File.ReadAllTextAsync("docs/prep.html");
        }

        // source
        [HttpGet("source")]
        public async Task<string> Source()
        {
            return await System.IO.File.ReadAllTextAsync("docs/source.html");
        }
    }
}