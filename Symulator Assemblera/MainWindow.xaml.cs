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

namespace Symulator_Assemblera
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            movButton.Click += MovButton_Click;
            xchgButton.Click += XchgButton_Click;
        }

        private void XchgButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        private void MovButton_Click(object sender, RoutedEventArgs e)
        {
            string ax = ParseInput(axInput.Text);
            string bx = ParseInput(bxInput.Text);
            string cx = ParseInput(cxInput.Text);
            string dx = ParseInput(dxInput.Text);
            axValue.Text = ax;
            bxValue.Text = bx;
            cxValue.Text = cx;
            dxValue.Text = dx;
        }
        private string ParseInput(string input)
        {
            int temp;
            if (String.IsNullOrWhiteSpace(input))
                input = "0";

            try
            {
                temp = int.Parse(input, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                MessageBox.Show($"{input} is not a valid number.", "Invalid value", MessageBoxButton.OK, MessageBoxImage.Error);
                temp = 0;
            }

            return input = temp.ToString();
        }
    }
}
