using BLL;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace Cursovaya3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DataBaseController : ControllerBase
    {        
        private readonly IDBService dbService;

        public DataBaseController(IDBService _dBService)
        {
            dbService = _dBService;
        }

        [HttpPost]
        public string CreateDB(DB_DTO configs)
        {
            return dbService.CreateDB(configs);
        }

        [HttpDelete]
        public string DropDB(DB_DTO configs)
        {
            return dbService.DropDB(configs);
        }

        [HttpPost]
        public string CreateTable(DB_Table db_table)
        {
            return dbService.CreateTable(db_table.DB_DTO, db_table.Table_DTO);
        }

        [HttpDelete]
        public string DropTable(DB_Table db_table)
        {
            return dbService.DropTable(db_table.DB_DTO, db_table.Table_DTO);
        }

    }
}