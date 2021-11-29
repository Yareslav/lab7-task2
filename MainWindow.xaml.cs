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
namespace Hme2
{
    class MyMatrix
    {
        public int[,] value;
        public void Fill()
        {
            var random = new Random();
            for (var i = 0; i < value.GetLength(0); i++)
            {
                for (var j = 0; j < value.GetLength(1); j++)
                {
                    value[i, j] = random.Next(-100, 100);
                }
            }
        }
        public void Create(int columns, int rows)
        {
            value = new int[columns, rows];
        }
        public string GetSize()
        {
            string result = "";

            for (var i = 0; i < value.GetLength(0); i++)
            {
                for (var j = 0; j < value.GetLength(1); j++)
                {
                    result += value[i, j] + " ";
                }
            }
            return result;
        }
    }
    public partial class MainWindow : Window
    {
        private MyMatrix matrix = new MyMatrix();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            int columns = 1;
            int rows = 1;
            if (int.TryParse(Rows.Text, out rows) && int.TryParse(Columns.Text, out columns))
            {
                matrix.Create(columns, rows);
                matrix.Fill();
            }
            else MessageBox.Show("невозможно создать матрицу");
        }
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            if (matrix.value != null) Field.Text = matrix.GetSize();
            else MessageBox.Show("матриця пуста");
        }
    }
}
