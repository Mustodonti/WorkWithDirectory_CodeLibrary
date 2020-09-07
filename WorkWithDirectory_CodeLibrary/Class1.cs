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
using System.Windows.Forms;
using System.Collections;


namespace WorkWithDirectory_CodeLibrary
{
    public class Phone
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
    }
    public class MyTable
    {
        public MyTable(int Id, string Vocalist, string Album, int Year)
        {
            this.Id = Id;
            this.Vocalist = Vocalist;
            this.Album = Album;
            this.Year = Year;
        }
        public int Id { get; set; }
        public string Vocalist { get; set; }
        public string Album { get; set; }
        public int Year { get; set; }
    }
}
