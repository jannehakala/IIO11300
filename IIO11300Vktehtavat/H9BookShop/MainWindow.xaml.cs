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
            try {
                dgBooks.DataContext = Bookshop.GetBooks(true);
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            try {
                Book current = (Book)spBook.DataContext;
                if (Bookshop.UpdateBook(current) > 0) {
                    MessageBox.Show(string.Format("Kirja {0} päivitetty tietokantaan onnistuneesti.", current.ToString()));
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e) {
            if (btnNew.Content.ToString() == "Uusi") {
                Book newBook = new Book(0);
                newBook.Name = "Anna kirjan nimi";
                spBook.DataContext = newBook;
                btnNew.Content = "Tallenna uusi kantaan";
            } else {
                Book current = (Book)spBook.DataContext;
                Bookshop.InsertBook(current);
                dgBooks.DataContext = Bookshop.GetBooks(true);
                MessageBox.Show(string.Format("Kirja {0} tallennettu kantaan onnistuneesti", current.ToString()));
                btnNew.Content = "Uusi";
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            try {
                Book current = (Book)spBook.DataContext;
                var retval = MessageBox.Show("Haluatko varmasti poistaa kirjan" + current.ToString(), "BookShop", MessageBoxButton.YesNo);
                if (retval == MessageBoxResult.Yes) {
                    Bookshop.DeleteBook(current);
                    dgBooks.DataContext = Bookshop.GetBooks(true);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            spBook.DataContext = dgBooks.SelectedItem;
        }
    }
}
