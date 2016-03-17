//Koodannut ja testannut toimivaksi 6.3.2014 EsaSalmik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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
using JAMK.ICT;
using JAMK.ICT.Data;

namespace JAMK.ICT.ADOBlanco {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private string ConnStr;
        private string TableName;
        private DataTable dt;
        private DataView dv;
        public MainWindow() {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff() {
            //TODO täytetään combobox asiakkaitten maitten nimillä
            //esimerkki kuinka App.Configissa oleva connectionstring luetaan
            string message = "";   
            try {
                ConnStr = JAMK.ICT.Properties.Settings.Default.Tietokanta;
                lbMessages.Content = ConnStr;
                TableName = JAMK.ICT.Properties.Settings.Default.Taulu;
                dt = DBPlacebo.GetAllCustomersFromSQLServer(ConnStr, TableName, "", out message);
                dv = dt.DefaultView;
                FillMyCombo();
            } catch (Exception ex) {

                lbMessages.Content = ex.Message;
            }
        }
        private void FillMyCombo() {
            //cbCountries.ItemsSource = DBPlacebo.GetCitiesFromSQLServer(ConnStr, TableName).DefaultView;
            //cbCountries.DisplayMemberPath = "city";
            //cbCountries.SelectedValuePath = "city";
            var result = (from c in dt.AsEnumerable()
                          select c.Field<string>("City")).Distinct().ToList();
            cbCountries.ItemsSource = result;
        }

        private void btnGet3_Click(object sender, RoutedEventArgs e) {
            dgCustomers.ItemsSource = DBPlacebo.GetTestCustomers().DefaultView;
        }

        private void btnGetAll_Click(object sender, RoutedEventArgs e) {
            string message = "";
            try {
                dgCustomers.ItemsSource = dt.DefaultView;
            } catch (Exception ex) {
                message = ex.Message;
            } finally {
                lbMessages.Content = message;
            }
        }

        private void btnGetFrom_Click(object sender, RoutedEventArgs e) {
            //TODO
        }

        private void btnYield_Click(object sender, RoutedEventArgs e) {
            JAMK.ICT.JSON.JSONPlacebo2015 roskaa = new JAMK.ICT.JSON.JSONPlacebo2015();
            MessageBox.Show(roskaa.Yield());
        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            //SuodataVE1();
            SuodataVE2();
        }
        private void SuodataVE1() {
            string message = "";
            string city = "";
            try {
                if (cbCountries.SelectedIndex >= 0) {
                    city = cbCountries.SelectedValue.ToString();
                    dgCustomers.ItemsSource = DBPlacebo.GetAllCustomersFromSQLServer(ConnStr, TableName, city, out message).DefaultView;
                }
            } catch (Exception ex) {
                message = ex.Message;
            } finally {
                lbMessages.Content = message;
            }
        }
        private void SuodataVE2() {
            dv.RowFilter = string.Format("city = '{0}'", cbCountries.SelectedValue.ToString());
        }
    }
}
