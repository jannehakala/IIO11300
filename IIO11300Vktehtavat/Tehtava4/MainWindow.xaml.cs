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

namespace JAMK.IT.IIO11300 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void comboSelectTeam_Loaded(object sender, RoutedEventArgs e) {
            cbTeam.Items.Add("Blues"); cbTeam.Items.Add("HIFK"); cbTeam.Items.Add("HPK");
            cbTeam.Items.Add("Ilves"); cbTeam.Items.Add("JYP"); cbTeam.Items.Add("KalPa");
            cbTeam.Items.Add("KooKoo"); cbTeam.Items.Add("Kärpät"); cbTeam.Items.Add("Lukko");
            cbTeam.Items.Add("Pelicans"); cbTeam.Items.Add("SaiPa"); cbTeam.Items.Add("Sport");
            cbTeam.Items.Add("Tappara"); cbTeam.Items.Add("TPS"); cbTeam.Items.Add("Ässät");
        }


        private void btnNewPlayer_Click(object sender, RoutedEventArgs e) {
            try {
                if (!string.IsNullOrEmpty(txtFirstname.Text) && !string.IsNullOrEmpty(txtLastname.Text)
                        && !string.IsNullOrEmpty(txtPrice.Text) && !string.IsNullOrEmpty(cbTeam.Text)) {
                    Pelaaja pelaaja = new Pelaaja(txtFirstname.Text, txtLastname.Text, int.Parse(txtPrice.Text), cbTeam.Text);
                    listBox.Items.Add(pelaaja.Previewname);
                    tbStatus.Text = "Tila: Pelaajan luonti onnistui!";
                } else {
                    tbStatus.Text = "Tila: Jokin kohta jäi tyhjäksi!";
                }
            } catch (Exception ex) {
                tbStatus.Text = "Tila: Syötä hinnaksi vain numeroita!";
            }
            
        }

        private void btnSavePlayer_Click(object sender, RoutedEventArgs e) {

        }

        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e) {

        }

        private void btnWritePlayers_Click(object sender, RoutedEventArgs e) {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
