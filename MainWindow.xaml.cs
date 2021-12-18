using LibMas;
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

namespace Практическая_14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                using (StreamReader open = new StreamReader(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini")))
                {
                    int column = Convert.ToInt32(open.ReadLine());
                    int row = Convert.ToInt32(open.ReadLine());
                    myarray = new MyArray(row, column);
                    InitializeComponent();
                    datagrid.ItemsSource = myarray.ToDataTable().DefaultView;
                }
            }
            catch
            {
                MessageBox.Show("Конфигруация не найдена!", "Конфигрурация", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            InitializeComponent();
        }

        private MyArray myarray;

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ExitWindow ew = new ExitWindow();
            ew.Owner = this;
            ew.ShowDialog();
        }

        private void GetInformation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил Дударев И. В. ИСП-34. \nВариант 4.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateTable_Click(object sender, RoutedEventArgs e)
        {
            if (rowcount.Text != "" && columncount.Text != "")
            {
                int row = Convert.ToInt32(rowcount.Text);
                int column = int.Parse(columncount.Text);
                myarray = new MyArray(row, column);
                datagrid.ItemsSource = myarray.ToDataTable().DefaultView;
                size.Text = row + "x" + column;
            }
            else MessageBox.Show("Введите данные", "Ошибка");
        }

        private void CompleteTable_Click(object sender, RoutedEventArgs e)
        {
            if (rowcount.Text != "" && columncount.Text != "")
            {
                myarray.Initialize();
                datagrid.ItemsSource = myarray.ToDataTable().DefaultView;
            }
            else MessageBox.Show("Введите данные", "Ошибка");
        }

        private void Define_Click(object sender, RoutedEventArgs e)
        {
            if (rowcount.Text != "" && columncount.Text != "")
            {
                int kol = 0;
                int row = Convert.ToInt32(rowcount.Text);
                int[] columnline = new int[row];
                for (int i = 0; i < myarray.ColumnLength; i++)
                {
                    Array.Clear(columnline, 0, columnline.Length);
                    for (int j = 0; j < myarray.LineLength; j++)
                    {
                        columnline[j] = myarray[j, i];
                    }
                    if (columnline.Distinct().Count() == columnline.Length)
                    {
                        kol++;
                    }
                }
                result.Text = kol.ToString();
            }
            else MessageBox.Show("Введите данные", "Ошибка");
        }

        private void ClearArray_Click(object sender, RoutedEventArgs e)
        {
            myarray.Initialize(0, 0);
            result.Clear();
            rowcount.Clear();
            columncount.Clear();
            size.Text = "0x0";
            datagrid.ItemsSource = myarray.ToDataTable().DefaultView;
        }

        private void Rowcount_TextChanged(object sender, TextChangedEventArgs e)
        {
            result.Clear();
        }

        private void Columncount_TextChanged(object sender, TextChangedEventArgs e)
        {
            result.Clear();
        }

        private void SaveArray_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Сохранение матрицы";

            if (saveFileDialog.ShowDialog() == true)
            {
                myarray.Save(saveFileDialog.FileName);
            }
            datagrid.ItemsSource = null;
        }

        private void OpenArray_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Открытие матрицы";

            if (openFileDialog.ShowDialog() == true)
            {
                myarray.Open(openFileDialog.FileName);
                datagrid.ItemsSource = myarray.ToDataTable().DefaultView;
            }

        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selectedsell.Text = "Выбранная ячейка: " + datagrid.Items.IndexOf(datagrid.CurrentItem) + "x" + datagrid.CurrentColumn.DisplayIndex;
        }

        private void Loade_Loaded(object sender, RoutedEventArgs e)
        {
            LoginWindow logwin = new LoginWindow();
            logwin.Owner = this;
            logwin.ShowDialog();
        }

        private void SetParams_Click(object sender, RoutedEventArgs e)
        {
            SetParamsWindow setparams = new SetParamsWindow();
            setparams.Owner = this;
            setparams.ShowDialog();
        }
    }
}
