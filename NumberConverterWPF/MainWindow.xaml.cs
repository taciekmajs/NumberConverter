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
using static NumberConverterWPF.Convert;

namespace NumberConverterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //main point of app- method that allows conversion
        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                leftNumber.Text = leftNumber.Text.ToUpper();
                if (!checkBases())
                {
                    error.Content = "Something is wrong with your bases";
                    break;
                }
                if (!checkNumber(int.Parse(leftBase.Text)))
                {
                    error.Content = "Something is wrong with your number";
                    break;
                }
                double dec = Convert.imalToDec(leftNumber.Text, double.Parse(leftBase.Text));
                rightNumber.Text = Convert.decToImal((int)dec, int.Parse(rightBase.Text));
                error.Content = "";
                if (leftBase.Text == "13" || rightBase.Text == "13") error.Content = "You better watch out, 13 belongs to Zuza Schaefer!";
                break;
            }
            
        }

        

        //Validation methods
        public bool checkNumber(int leftBase)
        {
            for (int i = 0; i<leftNumber.Text.Length; i++)
            {
                if (Array.IndexOf(Global.alphabet, leftNumber.Text[i].ToString()) > leftBase-1 ||
                    Array.IndexOf(Global.alphabet, leftNumber.Text[i].ToString()) == -1) return false;
            }
            return true;
        }

        public bool checkBases()
        {
            int left, right;
            if (!int.TryParse(leftBase.Text,out left))return false;
            if (!int.TryParse(rightBase.Text, out right)) return false;
            if (left<2 || left>32 || right < 2 || right > 32)return false;
            return true;
        }

        //Little methods which are meant to make app more user friendly
        private void Arrow_Click(object sender, RoutedEventArgs e)
        {
            leftNumber.Text = rightNumber.Text;
            rightNumber.Text = "";
        }

        private void lBin_Click(object sender, RoutedEventArgs e)
        {
            leftBase.Text = "2";
        }

        private void lDec_Click(object sender, RoutedEventArgs e)
        {
            leftBase.Text = "10";
        }

        private void lHex_Click(object sender, RoutedEventArgs e)
        {
            leftBase.Text = "16";
        }

        private void rBin_Click(object sender, RoutedEventArgs e)
        {
            rightBase.Text = "2";
        }

        private void rDec_Click(object sender, RoutedEventArgs e)
        {
            rightBase.Text = "10";
        }

        private void rHex_Click(object sender, RoutedEventArgs e)
        {
            rightBase.Text = "16";
        }

        private void lUp_Click(object sender, RoutedEventArgs e)
        {
            changeLeft(1);
        }

        private void lDown_Click(object sender, RoutedEventArgs e)
        {
            changeLeft(-1);
        }

        private void rUp_Click(object sender, RoutedEventArgs e)
        {
            changeRight(1);
        }

        private void rDown_Click(object sender, RoutedEventArgs e)
        {
            changeRight(-1);
        }
        
        public void changeLeft(int updown)
        {
            int left;
            if (int.TryParse(leftBase.Text, out left)) leftBase.Text = (left + updown).ToString();
            else leftBase.Text = "2";
        }
        public void changeRight(int updown)
        {
            int right;
            if (int.TryParse(rightBase.Text, out right)) rightBase.Text = (right + updown).ToString();
            else rightBase.Text = "2";
        }

        private void random_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            if (checkBases()) leftNumber.Text = decToImal(random.Next(100, 9999), int.Parse(leftBase.Text));
        }
    }
}
