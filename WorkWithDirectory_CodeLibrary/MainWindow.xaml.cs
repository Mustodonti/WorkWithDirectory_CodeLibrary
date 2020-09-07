using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using Microsoft.Office.Interop;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WorkWithDirectory_CodeLibrary
{
    public class DATA
    {
        public string tetex { get; set; }
    }
    public partial class MainWindow : Window
    {
        public int u = 0;
        public DATA data { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //string connectionString = @"Data Source=DESKTOP-997EUHU;Initial Catalog=usersdb;User ID=sa;password=123456";
            //получаем строку подключения
            //string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;User Id = DESKTOP-997EUHU\Йонас";

            //Создание подключения
            //SqlConnection connection = new SqlConnection(get_cs());
            //try
            //{
            //    // Открываем подключение
            //    connection.Open();
            //    MessageBox.Show("Подключение открыто");
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    // закрываем подключение
            //    connection.Close();
            //    MessageBox.Show("Подключение закрыто...");
            //}

            //using (var connection = new SqlConnection(get_cs()))
            //{
            //    connection.Open();
            //    
            //    }
            //    connection.Close();
            //}
            //Binding binding = new Binding();

            //binding.ElementName = "tetex"; // элемент-источник
            //AAD.SetBinding(TextBlock.TextProperty, binding); // установка привязки для элемента-приемника
            //this.DataContext = new DATA { tetex = "dfdfdfd" } ;
            //ConnectWithDB(@"Data Source=DESKTOP-997EUHU\SQLEXPRESS;Initial Catalog=usersd;Integrated Security=True").GetAwaiter();// Создание пула подключений (Первый пул)
            //ConnectWithDB(@"Data Source=DESKTOP-997EUHU\SQLEXPRESS;Initial Catalog=usersd;Integrated Security=True").GetAwaiter();//Второй пул так как в метод уже зашла другая строка
            // MessageBox.Show($"{ert.Children.Add(ButtonAdd())}");
            string connection = @"Data Source=DESKTOP-997EUHU\SQLEXPRESS;Initial Catalog=usersd;Integrated Security=True";
            TablesReaderSQL.GetNameTablesFromSQL(connection).ForEach(i => InitTabItem(i, connection));


        }
        private static async Task ConnectWithDB(string connectionString)
        {
            string sqlExpression1 = "INSERT INTO  [usersd].[dbo].[Table] ([NAME],[AGE]) Values ('yuyu',16)";
            //ExecuteNonQuery: просто выполняет sql-выражение и возвращает количество измененных записей. Подходит для sql-выражений INSERT, UPDATE, DELETE.
            //"INSERT INTO  [usersd].[dbo].[Table] ([NAME],[AGE]) Values ('yuyu',16)"
            //"UPDATE Users SET Age=20 WHERE Name='Tom'" - Здесь обновляется строка, в которой Name=Tom. Все строки, где Name=Tom обновятся все эти строки.
            //"DELETE  FROM Users WHERE Name='Tom'" - Удалим, например, всех пользователей, у которых имя Tom
            string sqlExpression2 = "SELECT * FROM [usersd].[dbo].[Table]"; //"SELECT [NAME] FROM[usersd].[dbo].[Table] ";
            string sqlExpression3 = "INSERT INTO  [usersd].[dbo].[Table] ([NAME],[AGE]) Values ('yuyu',16)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                Console.WriteLine("Подключение открыто");
                // Вывод информации о подключении
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
                Console.WriteLine("\tБаза данных: {0}", connection.Database);
                Console.WriteLine("\tСервер: {0}", connection.DataSource);
                Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
                Console.WriteLine("\tСостояние: {0}", connection.State);
                Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);
                Console.WriteLine("\tClientConnectionId: {0}", connection.ClientConnectionId);
                //ExecuteNonQuery: просто выполняет sql-выражение и возвращает количество измененных записей. Подходит для sql-выражений INSERT, UPDATE, DELETE.
                SqlCommand command1 = new SqlCommand(sqlExpression1, connection);
                int number = command1.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
                //ExecuteReader: выполняет sql-выражение и возвращает строки из таблицы. Подходит для sql-выражения SELECT.

                SqlCommand command = new SqlCommand(sqlExpression2, connection);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("---------------------------------------------");

                if (reader.HasRows) // если есть данные
                {

                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader.Read()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object age = reader.GetValue(2);

                        Console.WriteLine("{0} \t{1} \t{2}", id, name, age);
                    }
                }

                reader.Close();

                //using (var command2 = new SqlCommand(sqlExpression2, connection))
                //{

                //    //using (var reader = command2.ExecuteReader())
                //    //{
                //    //    //if (reader.Read())
                //    //    //{
                //    //    //    //Console.WriteLine(rd.GetValue(0).ToString());
                //    //    //   // AAD.Text = (rd.GetValue(0).ToString());

                //    //    //}
                //    //    if (reader.HasRows) // если есть данные
                //    //    {
                //    //        // выводим названия столбцов
                //    //        Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                //    //        while (reader.Read()) // построчно считываем данные
                //    //        {
                //    //            object id = reader.GetValue(0);
                //    //            object name = reader.GetValue(1);
                //    //            object age = reader.GetValue(2);

                //    //            Console.WriteLine("{0} \t{1} \t{2}", id, name, age);
                //    //        }
                //    //    }
                //    //}
                //}
                //ExecuteScalar: выполняет sql-выражение и возвращает одно скалярное значение, например, число. Подходит для sql-выражения SELECT в паре с одной из встроенных функций SQL, как например, Min, Max, Sum, Count.
                Console.WriteLine("Подключение закрыто...");
            }

        }

        void LibraryDriveInfo(object sender, RoutedEventArgs e)
        {

        }
        void LibraryDirectory(object sender, RoutedEventArgs e)
        {

        }
        void LibraryDirectoryInfo(object sender, RoutedEventArgs e)
        {

        }
        void LibraryPath(object sender, RoutedEventArgs e)
        {

        }
        private void escButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // закрытие окна
        }
        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {

            //object oMissing = System.Reflection.Missing.Value;
            //object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
            ////Start Word and create a new document.
            //Word._Application oWord = new Word.Application();
            //oWord.Visible = true;
            //Word._Document oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            //MessageBox.Show("Действие выполнено");
        }
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(checkBox.Content.ToString() + " отмечен");
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(checkBox.Content.ToString() + " не отмечен");
        }

        private void checkBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(checkBox.Content.ToString() + " в неопределенном состоянии");
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            MessageBox.Show(pressed.Content.ToString());
        }

        private void DriveInfo_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {

            List<MyTable> result = new List<MyTable>(3);
            result.Add(new MyTable(1, "Майкл Джексон", "Thriller", 1982));
            result.Add(new MyTable(2, "AC/DC", "Back in Black", 1980));
            result.Add(new MyTable(3, "Bee Gees", "Saturday Night Fever", 1977));
            result.Add(new MyTable(4, "Pink Floyd", "The Dark Side of the Moon", 1973));
            grid.ItemsSource = result;
        }

        //Получаем данные из таблицы
        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MyTable path = grid.SelectedItem as MyTable;
            MessageBox.Show(" ID: " + path.Id + "\n Исполнитель: " + path.Vocalist + "\n Альбом: " + path.Album
                + "\n Год: " + path.Year);
        }

        public void Button_NewTable_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-997EUHU\SQLEXPRESS;Initial Catalog=usersd;Integrated Security=True";
            //string sql = "SELECT * FROM [usersd].[dbo].[Table]";
            var newtb = new TableSQL(TextBox_NewTable.Text, connectionString);
            newtb.CreateNewTable();
            NewTabItem newtbitem = new NewTabItem(newtb, 150, 5, 500);
            TabItem tbitem = newtbitem.Create();

            MainPanel.Items.Add(tbitem);
            newtbitem.btn_save.Click += (send, EventArgs) => { Btn_Click_Save(send, EventArgs, newtbitem); };
            newtbitem.btn_delete.Click += (send, EventArgs) => { Btn_Click_Delete(send, EventArgs, newtbitem); };
            newtbitem.btn_section.Click += (send, EventArgs) => { Btn_Click_AddSection(send, EventArgs, newtbitem); };

        }
        private void Btn_Click_Save(Object send, EventArgs e, NewTabItem newtbitem)
        {
            //var g = MainPanel.Items.GetItemAt(MainPanel.Items.Count - 1);
            Grid gr = newtbitem.tbitem.Content as Grid;

            foreach (var f in gr.Children)
            {
                if (f as StackPanel != null)
                {
                    StackPanel sp = f as StackPanel;
                    foreach (var i in sp.Children)
                    {
                        if (i as DataGrid != null)
                        {
                            DataGrid dg = i as DataGrid;
                            newtbitem.NewTB.SetDataGridContentToBD();
                        }
                    }
                }
            }
            MessageBox.Show("Изменения успешно сохранены");
        }
        private void Btn_Click_Delete(Object send, EventArgs e, NewTabItem newtbitem)
        {
            newtbitem.DeleteTabItem();
            MainPanel.Items.Remove(newtbitem.tbitem);
            MessageBox.Show("Таблица " + newtbitem.NewTB.nameDB + " успешно удалена");
        }
        private void Btn_Click_AddSection(Object send, EventArgs e, NewTabItem newtbitem)
        {

            MessageBox.Show("Секция добавлена");
        }
        private void InitTabItem(string nameDB, string connection)
        {
            var newtb = new TableSQL(nameDB, connection);
            NewTabItem newtbitem = new NewTabItem(newtb, 150, 5, 500);
            TabItem tbitem = newtbitem.Create();

            MainPanel.Items.Add(tbitem);
            newtbitem.btn_save.Click += (send, EventArgs) => { Btn_Click_Save(send, EventArgs, newtbitem); };
            newtbitem.btn_delete.Click += (send, EventArgs) => { Btn_Click_Delete(send, EventArgs, newtbitem); };
            newtbitem.btn_section.Click += (send, EventArgs) => { Btn_Click_AddSection(send, EventArgs, newtbitem); };
        }

    }
}



