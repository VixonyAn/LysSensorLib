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
        
    
    }
}
