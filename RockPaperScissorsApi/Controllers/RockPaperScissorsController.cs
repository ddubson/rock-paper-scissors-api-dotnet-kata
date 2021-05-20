using Microsoft.AspNetCore.Mvc;

namespace RockPaperScissorsApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class RockPaperScissorsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello, Players!";
        }
    }
}