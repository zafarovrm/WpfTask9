using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfTask3_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = (sender as ComboBox).SelectedItem as string;
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = (sender as ComboBox).SelectedItem as string;
            if (textBox != null)
            {
                textBox.FontSize = double.Parse(fontSize);
            }
        }
        private void rbBlacl_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if (textBox != null)
            {

                textBox.Selection.ApplyPropertyValue(ForegroundProperty, "Black");
            }
        }
        private void rbRed_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if (textBox != null)
            {
                textBox.Selection.ApplyPropertyValue(ForegroundProperty, "Red");
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {                
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                TextRange range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Text);
            }
        }

        //private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*txt|Все файлы (*.*)|*.*";
        //    if (saveFileDialog.ShowDialog() == true)
        //    {               
        //        FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
        //        TextRange range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
        //        range.Save(fileStream, DataFormats.Text);
        //    }
        //}

        //private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                TextRange range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Text);
            }
        }
        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                TextRange range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Text);
            }
        }
        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Style_Black_Click(object sender, RoutedEventArgs e)
        {

            Uri uri = new Uri("Dark.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void Style_Light_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }      
       
    }
}
