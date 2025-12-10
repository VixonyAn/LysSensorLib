using LysSensorLib;
using Microsoft.AspNetCore.Mvc;

namespace RESTLysSensor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiDataController : ControllerBase
    {
        private IPiDataRepositoryDB repo;

        public PiDataController(IPiDataRepositoryDB rep)
        { // Dependency Injection
            repo = rep;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<PiData> Get()
        {
            PiData lastEntry = repo.Get();
            if (lastEntry == null) { return NoContent(); }
            else { return Ok(lastEntry); }
        }

		[HttpGet("{getAll:bool}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<PiData>> Get(bool getAll = true)
		{
			List<PiData> results = repo.GetAll();
			if (results == null) { return NoContent(); }
			else { return Ok(results); }
		}

		// POST api/<LightSensorController>
		[HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PiData> Post(PiData pidata)
        {
            try
            {
                PiData? item = repo.Add(pidata);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + item.Id;
                return Created(uri, item); // 201 Created
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
