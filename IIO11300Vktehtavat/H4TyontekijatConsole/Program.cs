using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace H4TyontekijatConsole {
    class Program {
        static void CalculateSalarySumFromXML(string file) {
            try {
                //tutkitaan onko tiedosto olemassa
                if (File.Exists(file)) {
                    //luetaan tiedosto XmlDocument-olioon
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(file);
                    //haetaan kaikkien vakituisten työntekijöitten palkkaelementit XPath -komennolla
                    XmlNodeList xnl = xmldoc.SelectNodes("/tyontekijat/tyontekija[tyosuhde='vakituinen']/palkka");
                    //loopataan nodelista läpi
                    int sum = 0;
                    for (int i = 0; i < xnl.Count; i++) {
                        sum += Convert.ToInt32(xnl.Item(i).InnerText);
                    }
                    Console.WriteLine(string.Format("Vakituisia on {0} ja heidän palkat yhteensä {1}", xnl.Count, sum));
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        static void ReadWorkersFromXML(string file) {
            try {
                //tutkitaan onko tiedosto olemassa
                if (File.Exists(file)) {
                    //luetaan tiedosto XmlDocument-olioon
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(file);
                    //haetaan kaikki työntekijä elementti XPath -komennolla
                    XmlNodeList xnl = xmldoc.SelectNodes("/tyontekijat/tyontekija");
                    XmlNode xn; //tämä edustaa yksittäistä noodia
                    XmlNodeList xnl2;
                    //loopataan nodelista läpi
                    for (int i = 0; i < xnl.Count; i++) {
                        //näytetään käyttäjälle noodien sisältö
                        xn = xnl.Item(i);
                        //Console.WriteLine(xn.InnerText);
                        xnl2 = xn.ChildNodes;
                        for (int j = 0; j < xnl2.Count; j++) {
                            Console.WriteLine(xnl2.Item(j).InnerText);
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        static void Main(string[] args) {
            try {
                // ReadWorkersFromXML("d:\\Tyontekijat2016.xml");
                CalculateSalarySumFromXML("d:\\Tyontekijat2016.xml");
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
