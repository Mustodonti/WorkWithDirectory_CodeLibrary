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

namespace WorkWithDirectory_CodeLibrary
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void LibraryDriveInfo (object sender,RoutedEventArgs e)
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
    }
}



