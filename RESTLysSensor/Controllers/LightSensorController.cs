using LysSensorLib;
using Microsoft.AspNetCore.Mvc;
namespace RESTLysSensor.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LightSensorController : ControllerBase
	{
		private LightSensorRepositoryDB repo;

		public LightSensorController(LightSensorRepositoryDB rep)
		{ // Dependency Injection
			repo = rep;
		}

		// GET: api/<LightSensorController>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult Get([FromQuery] DateTime? date, [FromQuery] bool? descending)
		{
			List<LogEntry> entries = repo.Get(date, descending).ToList<LogEntry>();
			if (entries.Count == 0) { return NoContent(); }
			else { return Ok(entries); }
		}

		// GET api/<LightSensorController>/5
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public LogEntry Get(int id)
		{
			return repo.GetById(id);
		}

		// POST api/<LightSensorController>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public void Post([FromBody] LogEntry value)
		{
			repo.Add(value);
		}

		// DELETE api/<LightSensorController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public void Delete(int id)
		{
			repo.Delete(id);
		}
	}
}
