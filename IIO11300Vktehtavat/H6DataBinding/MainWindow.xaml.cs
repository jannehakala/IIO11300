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

namespace H6DataBinding {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        HockeyLeague smliiga;
        List<HockeyTeam> liigajoukkueet;
        int pointer;
        public MainWindow() {
            InitializeComponent();
            InitializeControlls();
        }
        private void InitializeControlls() {
            List<string> teams = new List<string>();
            teams.Add("Ilves");
            teams.Add("JYP");
            teams.Add("TPS");
            cbTeams.ItemsSource = teams;
            smliiga = new HockeyLeague();
            liigajoukkueet = smliiga.GetTeams();
        }

        private void btnGetSettings_Click(object sender, RoutedEventArgs e) {
            btnGetSettings.Content = H6DataBinding.Properties.Settings.Default.UserName;
        }

        private void btnBind_Click(object sender, RoutedEventArgs e) {
                spLiiga.DataContext = liigajoukkueet;
        }

        private void btnForward_Click(object sender, RoutedEventArgs e) {
            if (pointer < liigajoukkueet.Count-1) {
                pointer++;
                spLiiga.DataContext = liigajoukkueet[pointer];
            }
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e) {
            if (pointer > 0) {
                pointer--;
                spLiiga.DataContext = liigajoukkueet[pointer];
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e) {
            HockeyTeam uusi = new HockeyTeam();
            liigajoukkueet.Add(uusi);
            pointer = liigajoukkueet.Count - 1;
            spLiiga.DataContext = liigajoukkueet[pointer];
        }
    }
}
