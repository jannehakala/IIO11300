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

namespace H9BookShop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnGetTestBooks_Click(object sender, RoutedEventArgs e) {
            dgBooks.DataContext = Bookshop.GetTestBooks();
        }

        private void getBooksSQL_Click(object sender, RoutedEventArgs e) {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {

        }

        private void btnNew_Click(object sender, RoutedEventArgs e) {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {

        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            spBooks.DataContext = dgBooks.SelectedItem;
        }
    }
}
