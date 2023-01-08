using BLL;
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
        public string CreateDB(DB_DTO configs)
        {
            DBService dbService = new DBService();
            return dbService.CreateDB(configs);
        }

        [HttpDelete]
        public string DropDB(DB_DTO configs)
        {
            DBService dbService = new DBService();
            return dbService.DropDB(configs);
        }
    }
}