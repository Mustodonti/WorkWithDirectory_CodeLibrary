using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDirectory_CodeLibrary
{
    public static class TablesReaderSQL
    {
        public static List<string> GetNameTablesFromSQL(string connectionString)
        {
            string sqlExpression = "EXEC sp_Tables @table_owner = 'dbo', @table_type = \"'TABLE'\";";
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) // построчно считываем данные
                {
                    string information = reader.GetString(2);
                    result.Add(information);
                }
                reader.Close();
            }
            return result;
        }
    }
}
