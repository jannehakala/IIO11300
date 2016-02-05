using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300 {
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
        public static void WriteToFile(List<Pelaaja> pelaajat) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Pelaajat";
            sfd.InitialDirectory = "d:\\";
            sfd.Filter = "Tekstitiedostot .txt|*.txt|All files|*.*";
            Nullable<bool> result = sfd.ShowDialog();

            if (result == true) {
                StreamWriter sw = File.AppendText(sfd.FileName);
                foreach (var pelaaja in pelaajat) {
                    sw.WriteLine(pelaaja);
                }
                sw.Close();
            }
        }
        public override string ToString() {
            return Previewname;
        }
        #endregion
    }
}
