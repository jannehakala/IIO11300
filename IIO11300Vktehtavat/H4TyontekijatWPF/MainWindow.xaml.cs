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
using System.Xml;
using System.Xml.Linq;
namespace H4TyontekijatWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        XElement xe;
        XmlDocument xd;
        XmlNodeList employers;
        public MainWindow() {
            InitializeComponent();
        }

        private void btnReadXML_Click(object sender, RoutedEventArgs e) {
            //luetaan XML-tiedostosta tyontekija-elementit ja sidotaan ne DataGridiin
            try {
                string file = "d:\\Tyontekijat2016.xml";
                xe = XElement.Load(file);
                xd = new XmlDocument();
                xd.Load(file);
                employers = xd.SelectNodes("/tyontekijat/tyontekija");
                dgData.DataContext = xe.Elements("tyontekija");
                tbMessage.Text = string.Format("Vakituisia työntekijöitä {0} ja palkat yhteensä {1}", CountWorkers("vakituinen"), CalculateSalarySum("vakituinen"));
            } catch (Exception ex) {
                throw ex;
            }
        }
        private int CountWorkers() {
            int amount = 0;
            amount = employers.Count;
            return amount;
        }
        private int CountWorkers(string jobdesc) {
            int amount = 0;
            //lasketaan LINQ -kyselyllä tietyn tyyppiset työntekijät 
            var lastnames = from elem 
                       in xe.Elements()
                       where elem.Element("tyosuhde").Value == jobdesc
                       select elem.Element("sukunimi");
            amount = lastnames.Count();
            return amount;
        }
        
        private decimal CalculateSalarySum() {
            decimal sum = 0;
            XmlNode xn;
            for (int i = 0; i < employers.Count; i++) {
                xn = employers.Item(i);
                sum += decimal.Parse(xn.LastChild.InnerText);
            }
            return sum;
        }
        private decimal CalculateSalarySum(string jobdesc) {
            decimal sum = 0;

            var salaries = from elem
                       in xe.Elements()
                       where elem.Element("tyosuhde").Value == jobdesc
                       select elem.Element("palkka").Value;
            foreach (var item in salaries) {
                sum += decimal.Parse(item);
            }
            return sum;
        }
    }
}
