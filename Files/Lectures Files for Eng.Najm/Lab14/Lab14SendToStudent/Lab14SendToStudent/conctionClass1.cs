//using MySql.Data.MySqlClient;
//namespace Lab14SendToStudent
//{
//    public static class DbConection
//    {
//        private static readonly string _connectionString = "server=localhost;database=company;user=root;password=root;";
//        public static string GetConnection()
//        {
//            return _connectionString;
//        }
//    }
//}

using System.Data.SqlClient; 

namespace Lab14SendToStudent
{
    public static class DbConection
    {
        private static string connectionString = "Server=OSAMA-PC\\MSSQLSERVERO;Database=Employee;Trusted_Connection=True;";

        public static string GetConnection()
        {
            return connectionString;
        }
    }
}
