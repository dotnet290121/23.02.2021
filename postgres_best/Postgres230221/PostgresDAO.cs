using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgres230221
{
    internal class PostgresDAO : IDataAccess
    {
        private static readonly log4net.ILog my_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string m_conn;

        public PostgresDAO(string m_conn)
        {
            this.m_conn = m_conn;
        }
        /*
    private static List<Movie> PrintAllMovies(string conn_string)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string query = "SELECT * FROM movies";

                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                command.CommandType = System.Data.CommandType.Text; // this is default

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    long id = (long)reader["id"];
                    string title = (string)reader["title"];
                    // ....
                    Console.WriteLine($"{id} {title}");
                }
            }
        }
        */

        public bool TestDbConnection()
        {
            my_logger.Debug("Testing db access");
            try
            {
                using (var my_conn = new NpgsqlConnection(m_conn))
                {
                    my_conn.Open();
                    my_logger.Debug("Testing db access. succeed!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                my_logger.Fatal($"Testing db access. Failed!. Error: {ex}");
                return false;
            }
        }
    }
}
