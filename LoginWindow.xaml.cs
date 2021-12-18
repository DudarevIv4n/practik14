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
using System.Windows.Shapes;

namespace Практическая_14
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            passwordbox.Focus();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (passwordbox.Password == "123")
            {
                Close();
            }
            else MessageBox.Show("Ошибка. Неверный пароль!");
        }

        private void Decline_Click(object sender, RoutedEventArgs e)
        {
            Owner.Close();
        }
    }
}
