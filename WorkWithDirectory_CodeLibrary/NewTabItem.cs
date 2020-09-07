using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WorkWithDirectory_CodeLibrary
{
    public class NewTabItem
    {
        public Button btn_section;
        public Button btn_save;
        public Button btn_delete;
        public TabItem tbitem;
        public TableSQL NewTB { get; private set; }
        private string _nameNewTB;
        private int _widthfirstcolumn;
        private int _widthsecondcolumn;
        private int _widththirdcolumn;
        public NewTabItem(TableSQL newtb, int widthfirstcolumn, int widthsecondcolumn, int widththirdcolumn)
        {
            NewTB = newtb;
            _nameNewTB = NewTB.nameDB;
            _widthfirstcolumn = widthfirstcolumn;
            _widthsecondcolumn = widthsecondcolumn;
            _widththirdcolumn = widththirdcolumn;
        }
        public TabItem Create()
        {
            Grid gr = new Grid();
            gr.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(_widthfirstcolumn) });
            gr.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(_widthsecondcolumn) });
            gr.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(_widththirdcolumn) });

            StackPanel sp1 = new StackPanel();
            sp1.SetValue(Grid.ColumnProperty, 0);

            StackPanel sp2 = new StackPanel();
            sp2.SetValue(Grid.ColumnProperty, 2);

            DataGrid table = new DataGrid
            {
                HorizontalAlignment = HorizontalAlignment.Left,
            };
            table.ItemsSource = NewTB.GetDataGridContentFromBD();
            TextBlock tbl = new TextBlock
            {
                Background = new SolidColorBrush(Colors.Black),
            };
            tbl.SetValue(Grid.ColumnProperty, 1);
            btn_section = new Button
            {
                Content = "Создать новый раздел",
            };
            btn_save = new Button
            {
                Content = "Сохранить изменения",
            };
            btn_delete = new Button
            {
                Content = "Удалить таблицу",
            };

            gr.Children.Add(tbl);
            gr.Children.Add(sp1);
            gr.Children.Add(sp2);
            sp1.Children.Add(btn_section);
            sp1.Children.Add(btn_save);
            sp1.Children.Add(btn_delete);
            sp2.Children.Add(table);
            tbitem = new TabItem
            {
                Header = new TextBlock { Text = _nameNewTB }, // установка заголовка вкладки
                Content = gr,// установка содержимого вкладки
            };
            return tbitem;
        }
        public void DeleteTabItem()
        {
            NewTB.DeleteNewTable();
        }
        public void AddSection()
        {
        }

    }
}
