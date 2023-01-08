using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabasesRepository : BaseRepository<DBInfo>, IDatabasesRepository
    {
        public DatabasesRepository(DatabasesContext dbContext) : base(dbContext)
        {

        }
    }
}
