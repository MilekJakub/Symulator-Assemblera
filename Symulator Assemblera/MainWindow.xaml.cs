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
            resetValuesButton.Click += ResetValuesButton_Click;
            resetSelectedButton.Click += ResetSelectedButton_Click;

            fromAX.Checked += fromAX_Checked;
            onAX.Checked += onAX_Checked;

            fromBX.Checked += fromBX_Checked;
            onBX.Checked += onBX_Checked;

            fromCX.Checked += fromCX_Checked;
            onCX.Checked += onCX_Checked;

            fromDX.Checked += fromDX_Checked;
            onDX.Checked += onDX_Checked;
        }

        #region RadioButtonsEvents
        private void onDX_Checked(object sender, RoutedEventArgs e)
        {
            fromDX.IsChecked = false;
        }

        private void onCX_Checked(object sender, RoutedEventArgs e)
        {
            fromCX.IsChecked = false;
        }

        private void onBX_Checked(object sender, RoutedEventArgs e)
        {
            fromBX.IsChecked = false;
        }

        private void onAX_Checked(object sender, RoutedEventArgs e)
        {
            fromAX.IsChecked = false;
        }

        private void fromDX_Checked(object sender, RoutedEventArgs e)
        {
            onDX.IsChecked = false;
        }

        private void fromCX_Checked(object sender, RoutedEventArgs e)
        {
            onCX.IsChecked = false;
        }

        private void fromBX_Checked(object sender, RoutedEventArgs e)
        {
            onBX.IsChecked = false;
        }

        private void fromAX_Checked(object sender, RoutedEventArgs e)
        {
            onAX.IsChecked = false;
        }
        #endregion

        private void ResetValuesButton_Click(object sender, RoutedEventArgs e)
        {
            axValue.Text = "0";
            bxValue.Text = "0";
            cxValue.Text = "0";
            dxValue.Text = "0";
        }

        private void ResetSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            fromAX.IsChecked = false;
            onAX.IsChecked = false;

            fromBX.IsChecked = false;
            onBX.IsChecked = false;

            fromCX.IsChecked = false;
            onCX.IsChecked = false;

            fromDX.IsChecked = false;
            onDX.IsChecked = false;
        }

        private void XchgButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] textBoxes = new TextBox[] { axValue, bxValue, cxValue, dxValue };

            RadioButton[] radioButtonTab = new RadioButton[] { fromAX, fromBX, fromCX, fromDX };

            int from = -1;
            for (int i = 0; i < radioButtonTab.Length; i++)
            {
                if (radioButtonTab[i].IsChecked == true)
                {
                    from = i;
                    break;
                }
            }
            if (from == -1)
            {
                MessageBox.Show("Invalid selection for the XCGH instruction.", "Invalid selection", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            radioButtonTab = new RadioButton[] { onAX, onBX, onCX, onDX };

            int on = -1;
            for (int i = 0; i < radioButtonTab.Length; i++)
            {
                if (radioButtonTab[i].IsChecked == true)
                {
                    on = i;
                    break;
                }
            }
            if (on == -1)
            {
                MessageBox.Show("Invalid selection for the XCGH instruction.", "Invalid selection", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string temp;
            temp = textBoxes[from].Text;
            textBoxes[from].Text = textBoxes[on].Text;
            textBoxes[on].Text = temp;
        }

        private void MovButton_Click(object sender, RoutedEventArgs e)
        {
            axValue.Text = ParseInput(axInput.Text);
            bxValue.Text = ParseInput(bxInput.Text);
            cxValue.Text = ParseInput(cxInput.Text);
            dxValue.Text = ParseInput(dxInput.Text);
        }

        private string ParseInput(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                input = "0";

            bool isNegative = false;
            if (input[0] == '-')
            {
                string tempStr = input.Substring(1);
                input = tempStr;
                isNegative = true;
            }

            int temp;

            try
            {
                temp = int.Parse(input, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                MessageBox.Show($"{input} is not a valid hexadecimal number.", "Invalid value", MessageBoxButton.OK, MessageBoxImage.Error);
                temp = 0;
            }

            if(isNegative)
                temp *= -1;

            return temp.ToString();
        }
    }
}
