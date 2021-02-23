using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgres230221
{
    interface IDataAccess
    {
        bool TestDbConnection();

        List<Movie> GetAllMovies();
    }
}
