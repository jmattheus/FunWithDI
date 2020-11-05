using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FunWithDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeController : ControllerBase
    {
        private readonly ILogger<ShowMeController> _logger;
        private readonly ITopLevel _toplevel;
        private readonly IEnumerable<ILevel> _levels;

        public ShowMeController(ITopLevel toplevel, ILogger<ShowMeController> logger, IEnumerable<ILevel> levels)
        {
            _logger = logger;
            _toplevel = toplevel;
            _levels = levels;
        }

        [HttpGet]
        public string Get() => JsonConvert.SerializeObject(_toplevel, Formatting.Indented);

        [HttpGet]
        [Route("levels")]
        public string GetArray()
        {
            var sb = new StringBuilder();
            foreach(var level in _levels)
            {
                sb.AppendLine($"Type:{level.GetType()} {JsonConvert.SerializeObject(level, Formatting.Indented)}");
            }
            return sb.ToString();
        }
    }
}
