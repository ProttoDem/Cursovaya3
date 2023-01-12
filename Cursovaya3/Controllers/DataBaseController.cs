using AutoMapper;
using BLL;
using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace Cursovaya3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DataBaseController : ControllerBase
    {        
        private readonly IDBService dbService;
        private readonly IMapper _mapper;

        public DataBaseController(IDBService _dBService, IMapper mapper)
        {
            dbService = _dBService;
            _mapper = mapper;
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


        [HttpPatch]
        public string AlterTable(DB_Table db_table)
        {
            return dbService.AlterTable(db_table.DB_DTO, db_table.Table_DTO);
        }

        [HttpPost]
        public string InsertData(DB_InsertData_DTO insert)
        {
            //НЕ видит insertData внутри DTO
            return dbService.InsertData(insert.db_dto, insert.insertData);
        }

        [HttpDelete]
        public string DeleteData(DB_DeleteData_DTO delete)
        {
            //НЕ видит insertData внутри DTO
            return dbService.DeleteData(delete.db_dto, delete.delete_dto);
        }

        [HttpPost]
        public IEnumerable<string> GetTables(DB_DTO configs)
        {
            //НЕ видит insertData внутри DTO
            return dbService.GetTables(configs);
        }
    }
}