using DesingPatternsV2.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesingPatternsV2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SingletonController : Controller
    {
        private readonly SingletonService _singletonservice;
        public SingletonController(SingletonService singletonService)
        {
            _singletonservice = singletonService;
        }
        
        public IActionResult Get()
        {
            var singleton = _singletonservice;
            return Ok(singleton);
        }
    }
}