using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TableColumnAlter_DTO : TableColumn_DTO
    {
        public string Action { get; set; }
        public string? NewName { get; set; }
        public string? NewDataType { get; set; }

    }
}
