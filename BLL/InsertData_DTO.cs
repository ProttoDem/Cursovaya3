using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InsertData_DTO
    {
        public string TableName;
        public IEnumerable<string>? InsertColumns;
    }
}
