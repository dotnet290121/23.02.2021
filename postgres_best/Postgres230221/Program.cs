﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgres230221
{
    class Program
    {
        private static readonly log4net.ILog my_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                PostgresAppConfig.Instance.Init(args[0]);
            }
            else
            {
                PostgresAppConfig.Instance.Init();
            }

            my_logger.Info("**************************** System started");

            string conn_string = PostgresAppConfig.Instance.ConnectionString; //"Host=localhost;Username=postgres;Password=admin;Database=postgres;";
            IDataAccess dao = new PostgresDAO(conn_string);

            if (dao.TestDbConnection())
            {
                Console.WriteLine("Successfully connected to the DB...");

                var movies = dao.GetAllMovies();
                movies.ForEach(m => Console.WriteLine(m));

            }
            else
            {
                Console.WriteLine("Failed to connected to the DB...");
            }

            my_logger.Info("**************************** System shutdown");

            Console.ReadLine();
        }
    }
}
