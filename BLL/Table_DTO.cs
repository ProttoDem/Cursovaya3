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
        public string Name { get; set; } = "undefinedTable";
        public IEnumerable<TableColumn>? Columns { get; set; }
        public IEnumerable<TableColumnAlter>? AlterColumns { get; set; }

    }
}
