using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;

namespace Cursovaya3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DataBaseController : ControllerBase
    {        
        private readonly ILogger<DataBaseController> _logger;

        public DataBaseController(ILogger<DataBaseController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void CreateDB()
        {
            
        }
    }
}