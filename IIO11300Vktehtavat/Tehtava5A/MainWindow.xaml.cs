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

namespace JAMK.IT.IIO11300 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        List<Pelaaja> pelaajat;
        public MainWindow() {
            InitializeComponent();
            pelaajat = new List<Pelaaja>();
            string[] teams = new string[] { "Blues", "HIFK", "HPK", "Ilves", "JYP", "KalPa", "KooKoo",
            "Kärpät", "Lukko", "Pelicans", "SaiPa", "Sport", "Tappara", "TPS", "Ässät" };
            cbTeam.ItemsSource = teams;
        }

        private void btnNewPlayer_Click(object sender, RoutedEventArgs e) {
            try {
                if (!string.IsNullOrWhiteSpace(txtFirstname.Text) && !string.IsNullOrWhiteSpace(txtLastname.Text)
                    && !string.IsNullOrWhiteSpace(txtPrice.Text) && cbTeam.SelectedItem != null) {
                    if (Regex.IsMatch(txtFirstname.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtLastname.Text, @"^[a-zA-Z]+$")) {
                        Pelaaja pelaaja = new Pelaaja(txtFirstname.Text, txtLastname.Text, int.Parse(txtPrice.Text), cbTeam.SelectedValue.ToString());
                        if (pelaajat.Exists(Pelaaja => Pelaaja.Fullname == pelaaja.Fullname)) {
                            pelaaja = null;
                            tbStatus.Text = "Tila: Pelaaja on jo listassa!";
                        } else {
                            pelaajat.Add(pelaaja);
                            ApplyChanges();
                            tbStatus.Text = "Tila: Pelaajan luonti onnistui!";
                        }
                    } else {
                        tbStatus.Text = "Tila: Merkkijono on väärässä muodossa.";
                    }
                } else {
                    tbStatus.Text = "Tila: Jokin kenttä jäi tyhjäksi.";
                }
            } catch (Exception ex) {
                tbStatus.Text = "Tila: Merkkijono on väärässä muodossa.";
            }
        }
        private void btnSavePlayer_Click(object sender, RoutedEventArgs e) {
            try {
                if (!string.IsNullOrWhiteSpace(txtFirstname.Text) && !string.IsNullOrWhiteSpace(txtLastname.Text)
                    && !string.IsNullOrWhiteSpace(txtPrice.Text) && cbTeam.SelectedItem != null) {
                    if (Regex.IsMatch(txtFirstname.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtLastname.Text, @"^[a-zA-Z]+$")) {
                        int index = listBox.Items.IndexOf(listBox.SelectedItem);
                        pelaajat[index].Fname = txtFirstname.Text;
                        pelaajat[index].Lname = txtLastname.Text;
                        pelaajat[index].Team = cbTeam.SelectedValue.ToString();
                        pelaajat[index].Price = int.Parse(txtPrice.Text);
                        Clear();
                        ApplyChanges();
                        tbStatus.Text = "Pelaaja " + pelaajat[index].Fullname + " tallennettu";
                    } else {
                        tbStatus.Text = "Tila: Merkkijono on väärässä muodossa.";
                    }
                } else {
                    tbStatus.Text = "Tila: Jokin kenttä jäi tyhjäksi.";
                }
            } catch (Exception ex) {
                tbStatus.Text = "Tila: Merkkijono on väärässä muodossa.";
            }
        }
        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e) {
            try {
                int index = listBox.Items.IndexOf(listBox.SelectedItem);
                pelaajat.RemoveAt(index);
                Clear();
                ApplyChanges();
                tbStatus.Text = "Tila: Pelaaja poistettu.";
            } catch (Exception ex) {
                tbStatus.Text = "Tila: " + ex.ToString();
            }
        }
        private void btnWritePlayers_Click(object sender, RoutedEventArgs e) {
            try {
                if (Pelaaja.WriteToFile(pelaajat)) {
                    tbStatus.Text = "Tila: Pelaajat kirjoitettu tiedostoon.";
                } else {
                    tbStatus.Text = "Tila: Pelaajia ei tallennettu tiedostoon.";
                }
            } catch (Exception ex) {
                tbStatus.Text = "Tila: " + ex.ToString(); 
            }
        }
        private void btnReadPlayers_Click(object sender, RoutedEventArgs e) {
            try {
                var kaikki = pelaajat.Concat(Pelaaja.ReadFromFile()).ToList();
                pelaajat = kaikki;
                listBox.ItemsSource = null;
                listBox.ItemsSource = pelaajat;
                tbStatus.Text = "Tila: Pelaajat haettu tiedostosta.";
            } catch (Exception ex) {
                tbStatus.Text = "Tila: Haku peruttu tai haussa tapahtui virhe.";
            }
        }
        private void lbSelection_Click(object sender, SelectionChangedEventArgs e) {
            if (listBox.SelectedItem != null) {
                int index = listBox.Items.IndexOf(listBox.SelectedItem);
                txtFirstname.Text = pelaajat[index].Fname;
                txtLastname.Text = pelaajat[index].Lname;
                txtPrice.Text = pelaajat[index].Price.ToString();
                cbTeam.SelectedValue = pelaajat[index].Team;
                tbStatus.Text = "Tila: " + pelaajat[index].Fullname + " valittu.";
            }
        }
        private void ApplyChanges() {
            listBox.ItemsSource = null;
            listBox.ItemsSource = pelaajat;
        }
        private void Clear() {
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtPrice.Text = "";
            cbTeam.SelectedValue = "";
        }
        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}

