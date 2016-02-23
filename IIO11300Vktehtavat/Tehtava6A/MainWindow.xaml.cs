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
using System.Collections.ObjectModel;

namespace Tehtava6A {

    public partial class MainWindow : Window {
        XElement xe;
        public MainWindow() {
            InitializeComponent();
            tbPath.Text = ConfigurationManager.AppSettings["file"];
            cbWines.SelectedIndex = 0;
            try {
                xe = XElement.Load(tbPath.Text);

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnReadWines_Click(object sender, RoutedEventArgs e) {
            try {
                dataGrid.Items.Clear();
                if (cbWines.SelectedIndex == 0) {
                    foreach (XElement wine in xe.Elements("wine")) {
                        dataGrid.Items.Add(wine);
                    }
                } else {
                    foreach (XElement wine in xe.Elements("wine")) {
                        if (wine.Element("maa").Value == cbWines.SelectedItem.ToString()) {
                            dataGrid.Items.Add(wine);
                        }
                    }
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbWines_Loaded(object sender, RoutedEventArgs e) {
            try {
                           
                XmlDocument doc = new XmlDocument();
                doc.Load(tbPath.Text);
                XmlNodeList nodes = doc.SelectNodes("/viinikellari/wine/maa");
                cbWines.Items.Add("All");

                foreach (XmlNode name in nodes) {
                    if (!cbWines.Items.Contains(name.InnerText)) {
                        cbWines.Items.Add(name.InnerText);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
