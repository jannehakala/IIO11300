using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml;
using System.Xml.Linq;
using System.Configuration;


namespace Tehtava6A {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            tbPath.Text = ConfigurationManager.AppSettings["file"];
            cbWines.SelectedIndex = 0;
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(tbPath.Text);
                XmlNodeList colorList = doc.SelectNodes("/viinikellari/wine/maa");
                cbWines.Items.Add("Kaikki");

                foreach (XmlNode name in colorList) {
                    if (!cbWines.Items.Contains(name.InnerText)) {
                        cbWines.Items.Add(name.InnerText);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReadWines_Click(object sender, RoutedEventArgs e) {
            try {
                if (cbWines.SelectedIndex == 0) {
                    XmlDataProvider xdpWineData = (XmlDataProvider)this.FindResource("WineData");
                    xdpWineData.Source = new Uri(tbPath.Text, UriKind.RelativeOrAbsolute);
                } else {
                    XDocument xDoc = XDocument.Load(tbPath.Text);
                    string selected = cbWines.Text.ToString();
                    var items = xDoc.Descendants("wine").Where(w => w.Element("maa").Value == selected);
                    foreach (var item in items) {
                        //dataGrid.ItemsSource = null;
                       // dataGrid.Items.Add("dsf");
                        Console.WriteLine(item.Element("nimi").Value + item.Element("maa").Value);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
