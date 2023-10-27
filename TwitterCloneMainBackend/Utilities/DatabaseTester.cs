using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace TwitterCloneMainBackend.Utilities
{

    public class DatabaseTester
    {

        private readonly ILogger<DatabaseTester> _logger;

        public DatabaseTester(ILogger<DatabaseTester> logger)
        {
            _logger = logger;
        }
        public static void TestConnection(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful.");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                }
            }
        }
    }
}
