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
        int numberOfUpperChars;

        private void txtTextToCheck_TextChanged(object sender, TextChangedEventArgs e) {
            if(txtTextToCheck.Text.Any(c => char.IsUpper(c))){

            }
            if (Regex.IsMatch(txtTextToCheck.Text, "[A-Z]")) {
                numberOfUpperChars++;
            }        
            
            tbCharCount.Text = "Characters: " + txtTextToCheck.Text.Length;
            tbUpperCaseCount.Text = "Upper case: " + numberOfUpperChars.ToString();
        }
    }
}
