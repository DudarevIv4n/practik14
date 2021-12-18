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
using System.Windows.Shapes;

namespace Практическая_14
{
    /// <summary>
    /// Логика взаимодействия для SetParamsWindow.xaml
    /// </summary>
    public partial class SetParamsWindow : Window
    {
        public SetParamsWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter save = new StreamWriter(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini")))
            {
                save.WriteLine(rowcount.Text);
                save.WriteLine(columncount.Text);
            }
            Close();
        }
    }
}
