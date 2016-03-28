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

namespace Tehtava10 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private List<Pelaaja> pelaajat;

        public MainWindow() {
            InitializeComponent();
            this.GetPlayers();
        }

        private void btnGetPlayers_Click(object sender, RoutedEventArgs e) {
            this.GetPlayers();
        }
        private void btnAddPlayer_Click(object sender, RoutedEventArgs e) {
            try {
                if (btnAddPlayer.Content.ToString() == "Luo pelaaja") {
                    Pelaaja pelaaja = new Pelaaja(Liiga.GetMaxId());
                    spPelaaja.DataContext = pelaaja;
                    btnAddPlayer.Content = "Tallenna uusi pelaaja";
                } else {
                    Pelaaja current = (Pelaaja)spPelaaja.DataContext;
                    Liiga.InsertPelaaja(current);
                    this.GetPlayers();
                    MessageBox.Show(string.Format("Pelaaja {0} lisätty kantaan onnistuneesti", current.ToString()));
                    btnAddPlayer.Content = "Luo pelaaja";
                }
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSavePlayers_Click(object sender, RoutedEventArgs e) {
            try {
                Pelaaja current = (Pelaaja)spPelaaja.DataContext;
                if (Liiga.UpdatePelaaja(current) > 0) {
                    this.GetPlayers();
                    MessageBox.Show(string.Format("Pelaaja {0} päivitetty kantaan onnistuneesti", current.ToString()));
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        } 

        private void GetPlayers() {
            try {
                pelaajat = Liiga.GetPelaajat();
                lbPelaajat.DataContext = pelaajat;
                lbPelaajat.SelectedIndex = 0;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void lbPelaajat_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            spPelaaja.DataContext = lbPelaajat.SelectedItem;
        }
    }
}