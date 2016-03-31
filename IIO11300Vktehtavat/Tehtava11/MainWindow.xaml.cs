using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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

namespace Tehtava11 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        SMLiigaEntities ctx;
        public MainWindow() {
            InitializeComponent();
            IniMyStuff();
        }

        public void IniMyStuff() {
            ctx = new SMLiigaEntities();
            ctx.Pelaajat.Load();
        }

        private void btnGetPlayers_Click(object sender, RoutedEventArgs e) {
            this.GetPlayers();
        }

        private void btnSavePlayers_Click(object sender, RoutedEventArgs e) {
            try {
                ctx.SaveChanges();
                tbMessage.Text = "Tiedot tallennettu onnistuneesti kantaan";
                this.GetPlayers();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnNewPlayer_Click(object sender, RoutedEventArgs e) {
            try {
                Pelaaja newPelaaja;
                tbMessage.Text = "Luo uusi pelaaja";
                if (btnNewPlayer.Content.ToString() == "Uusi pelaaja") {
                    newPelaaja = new Pelaaja();
                    spPelaaja.DataContext = newPelaaja;
                    btnNewPlayer.Content = "Tallenna uusi kantaan";
                } else {
                    newPelaaja = (Pelaaja)spPelaaja.DataContext;
                    ctx.Pelaajat.Add(newPelaaja);
                    ctx.SaveChanges();
                    btnNewPlayer.Content = "Uusi pelaaja";
                    tbMessage.Text = "Pelaaja " + newPelaaja.DisplayName + " lisätty kantaan";
                    this.GetPlayers();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e) {
            try {
                Pelaaja current = (Pelaaja)spPelaaja.DataContext;
                var retval = MessageBox.Show("Haluatko varmasti poistaa pelaajan " + current.DisplayName, "SMLiiga", MessageBoxButton.YesNo);
                if (retval == MessageBoxResult.Yes) {
                    ctx.Pelaajat.Remove(current);
                    ctx.SaveChanges();
                    lbPelaajat.SelectedIndex = 0;
                    this.GetPlayers();
                    tbMessage.Text = "Pelaaja " + current.DisplayName + " poistettu onnistuneesti";
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetPlayers() {
            try {
                bool init = false;
                var players = ctx.Pelaajat.ToList();
                lbPelaajat.DataContext = players;
                lbPelaajat.DisplayMemberPath = "DisplayName";
                if (init == false) {
                    tbMessage.Text = "Haettiin " + lbPelaajat.Items.Count.ToString() + " pelaajan tiedot";
                    init = true;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbPelaajat_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            spPelaaja.DataContext = lbPelaajat.SelectedItem;
            Pelaaja pl = (Pelaaja)lbPelaajat.SelectedItem;
            tbMessage.Text = "Valitsit pelaajan: " + pl.DisplayName;
        }
    }
}
