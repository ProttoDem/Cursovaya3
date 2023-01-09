using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Table_DTO
    {
        public string Name { get; set; }
        public IEnumerable<TableColumn> Columns { get; set; }
    }
}
