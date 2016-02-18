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
using System.Xml;

namespace H5Movies {
    /// <summary>
    /// Interaction logic for Movies2.xaml
    /// </summary>
    public partial class Movies2 : Window {
        public Movies2() {
            InitializeComponent();
        }

        private void btnAddMovie_Click(object sender, RoutedEventArgs e) {

            if (lbMovies.SelectedIndex >= 0) {
                lbMovies.SelectedIndex = -1;
                btnAddMovie.Content = "Tallenna";
            } else {
                try {
                    string filu = xdpMovies.Source.LocalPath;
                    XmlDocument doc = xdpMovies.Document;
                    XmlNode root = doc.SelectSingleNode("/Movies");
                    XmlNode newMovie = doc.CreateElement("Movie");
                    XmlAttribute xa1 = doc.CreateAttribute("Name");
                    xa1.Value = txtMovieName.Text;
                    newMovie.Attributes.Append(xa1);
                    XmlAttribute xa2 = doc.CreateAttribute("Director");
                    xa2.Value = txtDirectorName.Text;
                    newMovie.Attributes.Append(xa2);
                    XmlAttribute xa3 = doc.CreateAttribute("Country");
                    xa3.Value = txtCountryName.Text;
                    newMovie.Attributes.Append(xa3);
                    XmlAttribute xa4 = doc.CreateAttribute("Checked");
                    xa4.Value = chkWatched.IsChecked.ToString();
                    newMovie.Attributes.Append(xa4);
                    root.AppendChild(newMovie);
                    xdpMovies.Document.Save(filu);
                    MessageBox.Show("Uusi elokuva lisätty onnistuneesti");
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                    btnAddMovie.Content = "Lisää uusi";
                }
            }
        }

        private void btnDeleteMovie_Click(object sender, RoutedEventArgs e) {
            try {
                string filu = xdpMovies.Source.LocalPath;
                XmlDocument doc = xdpMovies.Document;
                XmlNode todelete = null;
                XmlNode root = doc.SelectSingleNode("/Movies");
                var item = doc.SelectSingleNode(string.Format("/Movies/Movie[@Name='{0}']", txtMovieName.Text));
                if (item != null && MessageBox.Show("Poistetaanko elokuva " + txtMovieName.Text, "Elokuvagalleria", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    todelete = item;
                    root.RemoveChild(todelete);
                    xdpMovies.Document.Save(filu);
                    lbMovies.SelectedIndex = -1;
                }
            }catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e) {
            string filu = xdpMovies.Source.LocalPath;
            xdpMovies.Document.Save(filu);
        }
    }
}
