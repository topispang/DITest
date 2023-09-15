using Logic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationAF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogicProvider _logicProvider;

        public HomeController(ILogger<HomeController> logger, ILogicProvider logicProvider)
        {
            _logger = logger;
            _logicProvider = logicProvider;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var list = new List<string>
            {
                "Dennis",
                _logicProvider.Something()
            };

            return list;
        }
    }
}