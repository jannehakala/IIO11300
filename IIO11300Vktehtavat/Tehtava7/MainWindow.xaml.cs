using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Tehtava7 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void txtPasswordToCheck_TextChanged(object sender, RoutedEventArgs e) {
            string password = txtPasswordToCheck.Password;
            int characters = password.Count();
            int numberOfUpperChars = password.Count(char.IsUpper);
            int numberOfLowerChars = password.Count(char.IsLower);
            int numberOfDigits = password.Count(char.IsNumber);
            int numberOfSpecials = Regex.Matches(password, "[^a-zA-Z0-9]").Count;

            int types = 0;
            if (numberOfUpperChars > 0) types++;
            if (numberOfLowerChars > 0) types++;
            if (numberOfDigits > 0) types++;
            if (numberOfSpecials > 0) types++;

            if (characters == 0) {
                tbResult.Text = "give password";
                tbResult.Background = new SolidColorBrush(Colors.Gray);
            }
            else if(characters < 8 && characters > 0 && types >= 1) {
                tbResult.Text = "bad";
                tbResult.Background = new SolidColorBrush(Colors.Red);
            }
            else if(characters < 12 && characters >= 8 && types >= 2) {
                tbResult.Text = "fair";
                tbResult.Background = new SolidColorBrush(Colors.Yellow);
            }
            else if(characters < 16 && characters >= 12 && types >= 3) {
                tbResult.Text = "moderate";
                tbResult.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else if(characters >= 16 && types == 4) {
                tbResult.Text = "good";
                tbResult.Background = new SolidColorBrush(Colors.Green);
            }

            tbCharCount.Text = "Characters: " + password.Length;
            tbUpperCaseCount.Text = "Upper case: " + numberOfUpperChars.ToString();
            tbLoverCaseCount.Text = "Lower case: " + numberOfLowerChars.ToString();
            tbNumberCount.Text = "Digits: " + numberOfDigits.ToString();
            tbSpecialCharCount.Text = "Specials: " + numberOfSpecials.ToString();
        }
        
    }
}
