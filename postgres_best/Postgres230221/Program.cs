using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgres230221
{
    class Program
    {
        static bool TestDbConnection(string conn)
        {
            try
            {
                using (var my_conn = new NpgsqlConnection(conn))
                {
                    my_conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            string conn_string = "Host=localhost;Username=postgres;Password=admin1;Database=postgres;";
            if (TestDbConnection(conn_string))
            {
                Console.WriteLine("Successfully connected to the DB...");
            }
            else
            {
                Console.WriteLine("Failed to connected to the DB...");
            }
        }
    }
}
