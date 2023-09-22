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
        private readonly IGlobalLogging _globalLogging;

        public HomeController(ILogger<HomeController> logger, ILogicProvider logicProvider, IGlobalLogging globalLogging)
        {
            _logger = logger;
            _logicProvider = logicProvider;
            _globalLogging = globalLogging;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var list = new List<string>
            {
                "Dennis",
                _logicProvider.Something()
            };

            _globalLogging.LogToEverything();

            return list;
        }
    }
}