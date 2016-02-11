using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace JAMK.IT.IIO11300 {
    [Serializable]
    public class Pelaaja {

        #region VARIABLES
        private string fname;
        private string lname;
        private string team;
        private int price;
        #endregion
        #region PROPERTIES
        public string Fname {
            get { return fname; }
            set { fname = value; }
        }
        public string Lname {
            get { return lname; }
            set { lname = value; }
        }
        public string Fullname {
            get { return fname + " " + lname; }
        }
        public string Previewname {
            get { return Fullname + ", " + team; }
        }
        public string Team {
            get { return team; }
            set { team = value; }
        }
        public int Price {
            get { return price; }
            set { price = value; }
        }
        #endregion
        #region CONSTRUCTORS
        public Pelaaja() { }
        public Pelaaja(string fname, string lname, int price, string team) {
            this.fname = fname;
            this.lname = lname;
            this.price = price;
            this.team = team;
        }
        #endregion
        #region METHODS

        public static bool WriteToFile(List<Pelaaja> pelaajat) {
            try {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "Pelaajat";

                sfd.InitialDirectory = "d:\\";
                sfd.Filter = "Tekstitiedostot .txt|*.txt|Xml-tiedostot|*.xml|All files|*.*";
                Nullable<bool> result = sfd.ShowDialog();

                if (result == true) {
                    string filename = sfd.FileName;
                    string terminal = Path.GetExtension(filename);
                    if (terminal == ".txt") {
                        StreamWriter sw;
                        try {
                            string line = "";
                            sw = new StreamWriter(filename);
                            for (int i = 0; i < pelaajat.Count(); i++) {
                                line = pelaajat[i].GetValues();
                                sw.WriteLine(line);
                            }
                            sw.Close();
                            return true;
                        } catch (Exception ex) {
                            throw ex;
                        }
                    }
                    if (terminal == ".xml") {
                        XmlWriter file;
                        try {
                            file = XmlWriter.Create(filename);
                            XmlSerializer serializer = new XmlSerializer(pelaajat.GetType());
                            serializer.Serialize(file, pelaajat);
                            file.Close();
                            return true;
                        } catch (Exception ex) {
                            throw ex;
                        }
                    } else {
                        return false;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
            return false;
        }
        public static List<Pelaaja> ReadFromFile() {
            try {
                List<Pelaaja> pelaajat = null;

                OpenFileDialog ofd = new OpenFileDialog();

                ofd.InitialDirectory = "d:\\";
                ofd.Filter = "Tekstitiedostot .txt|*.txt|Xml-tiedostot .xml|*.xml|All files|*.*";
                Nullable<bool> result = ofd.ShowDialog();

                if (result == true) {
                    string filename = ofd.FileName;
                    string terminal = Path.GetExtension(filename);

                    if (terminal == ".txt") {
                        if (File.Exists(filename)) {
                            pelaajat = new List<Pelaaja>();
                            StreamReader sr;
                            string line;
                            try {
                                sr = new StreamReader(File.OpenRead(filename));
                                while (!sr.EndOfStream) {
                                    line = sr.ReadLine();
                                    string[] array = line.Split(' ');
                                    int price = int.Parse(array[2]);     
                                    pelaajat.Add(new Pelaaja(array[0], array[1], price, array[3]));
                                }
                            } catch (Exception ex) {
                                throw ex;
                            }
                        }
                    }
                    if (terminal == ".xml") {
                        if (File.Exists(filename)) {
                            pelaajat = new List<Pelaaja>();
                            XmlReader file;
                            try {
                                file = XmlReader.Create(filename);
                                XmlSerializer serializer = new XmlSerializer(pelaajat.GetType());
                                pelaajat = serializer.Deserialize(file) as List<Pelaaja>;
                                file.Close();
                            } catch (Exception ex) {
                                throw ex;
                            }
                        }
                    }
                }
                return pelaajat;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public string GetValues() {
            return Fullname + " " + Price + " " + Team;
        }
        public override string ToString() {
            return Previewname;
        }
        #endregion
    }
}
