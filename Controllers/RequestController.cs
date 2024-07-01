using HNG.StageOneTask.BackendC_.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HNGTask1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RequestController : ControllerBase
	{
		private readonly GreetingService _greetingService;

		public RequestController(GreetingService myGreeting)
		{
			_greetingService = myGreeting;
		}

		[HttpGet("hello")]
		public async Task<ActionResult> Greeter([FromQuery] string nameOfVisitor, CancellationToken token)
		{
			var greeting = await _greetingService.Greet(HttpContext, nameOfVisitor, token);
			return Ok(greeting);
		}
	}
}
