using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WorkWithDirectory_CodeLibrary
{
    /// <summary>
    /// Библиотека для получения таблицы типа Table для загрузки в Datagrid
    /// private void InitTabItem(string nameDB, string connection)
    /// DataGrid table = new DataGrid(); table.ItemsSource = TableSQL.GetDataGridContentFromBD(nameDB, connection);
    /// </summary>
    public class TableSQL
    {
        private DataSet _ds { get; set; }
        public string nameDB { get; private set; }
        private string _connectionString { get; set; }
        public TableSQL(string namedb, string connectionString)
        {
            _ds = new DataSet();
            nameDB = namedb;
            _connectionString = connectionString;
        }
        public void CreateNewTable()
        {
            string sqlExpression = "CREATE TABLE " + nameDB + " (ID INT, INFORMATION NVARCHAR (50), EXAMPLE INT, NOTICE nvarchar(MAX))";
            // $"SELECT * FROM [usersd].[dbo].[{_nameDB}]";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteNewTable()
        {
            string sqlExpression = $"DROP TABLE [usersd].[dbo].[{nameDB}]";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }
        public DataView GetDataGridContentFromBD()
        {
            string sqlExpression = $"SELECT * FROM [usersd].[dbo].[{nameDB}]"; //"SELECT [NAME] FROM[usersd].[dbo].[Table] ";
            DataView data = new DataView();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connection);
                // Создаем объект Dataset

                // Заполняем Dataset
                adapter.Fill(_ds);
                // Отображаем данные
                data = _ds.Tables[0].DefaultView;
            }
            return data;
        }
        public void SetDataGridContentToBD()
        {
            string sqlExpression = $"SELECT * FROM [usersd].[dbo].[{nameDB}]"; //"SELECT [NAME] FROM[usersd].[dbo].[Table] ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                adapter.Update(_ds);

            }
        }
        //    public  List<Table> GetDataGridContentTypeOfTableFromBD(string nameDB, string connectionString)
        //    {
        //        string sqlExpression = $"SELECT * FROM [usersd].[dbo].[{nameDB}]"; //"SELECT [NAME] FROM[usersd].[dbo].[Table] ";
        //        List<Table> result = new List<Table>();
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            SqlCommand command = new SqlCommand(sqlExpression, connection);
        //            SqlDataReader reader = command.ExecuteReader();

        //            if (reader.HasRows) // если есть данные
        //            {
        //                while (reader.Read()) // построчно считываем данные
        //                {
        //                    string information = reader.GetString(1);
        //                    int example = reader.GetInt32(2);
        //                    result.Add(new Table(information, example, null));
        //                }
        //            }
        //            reader.Close();
        //        }
        //        return result;
        //    }
        //}
    }
}
