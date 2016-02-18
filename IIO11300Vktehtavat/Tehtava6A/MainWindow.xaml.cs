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

namespace Tehtava6A {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            tbPath.Text = "aa";
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load("Viinit1.xml");
                XmlNodeList colorList = doc.SelectNodes("/viinikellari/wine/maa");
                cbWines.Items.Add("");

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
                XDocument xDoc = XDocument.Load("Viinit1.xml");
                XmlDocument xml = new XmlDocument();
                xml.Load("Viinit1.xml");
                string selected = cbWines.Text.ToString();
                var items = xDoc.Descendants("wine").Where(w => w.Element("maa").Value == selected);
                foreach (var item in items) {
                    dataGrid.ItemsSource = null;
                  
                    

                    dataGrid.Items.Add("dsf");
                    Console.WriteLine(item.Element("nimi").Value + item.Element("maa").Value);
                } 
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
