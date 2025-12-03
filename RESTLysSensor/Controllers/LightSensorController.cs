using LysSensorLib;
using Microsoft.AspNetCore.Mvc;
namespace RESTLysSensor.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LightSensorController : ControllerBase
	{
		private ILightSensorRepositoryDB repo;

		public LightSensorController(ILightSensorRepositoryDB rep)
		{ // Dependency Injection
			repo = rep;
		}

		// GET: api/<LightSensorController>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<LogEntry>> Get([FromQuery] long? date, [FromQuery] bool? descending)
		{
			List<LogEntry> entries = repo.Get(date, descending).ToList<LogEntry>();
			if (entries.Count == 0) { return NoContent(); }
			else { return Ok(entries); }
		}

		// GET api/<LightSensorController>/5
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<LogEntry> Get(int id)
		{
			LogEntry? item = repo.GetById(id);
			if (item == null) { return NotFound(); }
			else { return Ok(item); }
		}

		// POST api/<LightSensorController>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<LogEntry> Post([FromBody] LogEntry value)
		{
			try
			{
				LogEntry? item = repo.Add(value);
				string uri = Url.RouteUrl(RouteData.Values) + "/" + item.Id;
				return Created(uri, item); // 201 Created
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// DELETE api/<LightSensorController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<LogEntry> Delete(int id)
		{
			LogEntry? item = repo.Delete(id);
			if (item == null) { return NotFound(); }
			else { return Ok(item); }
		}
	}
}
