using HNG.StageOneTask.BackendC_.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HNGTask1.Controllers
{
	[ApiController]
	[Route("api")]
	public class RequestController : ControllerBase
	{
		private readonly GreetingService _greetingService;

		public RequestController(GreetingService myGreeting)
		{
			_greetingService = myGreeting;
		}

		[HttpGet("hello")]
		public async Task<ActionResult> Greeter([FromQuery] string visitor_name, CancellationToken token)
		{
			var greeting = await _greetingService.Greet(HttpContext, visitor_name, token);
			return Ok(greeting);
		}
	}
}
