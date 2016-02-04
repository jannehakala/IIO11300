using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300 {
    public class Pelaaja {
        #region PROPERTIES

        private string fname;
        public string Fname {
            get { return fname; }
            set { fname = value; }
        }

        private string lname;
        public string Lname {
            get { return lname; }
            set { lname = value; }
        }

        public string Fullname {
            get { return lname + fname; }
        }

        public string Previewname {
            get { return fname + " " + lname + ", " + team; }
        }

        private string team;
        public string Team {
            get { return team; }
            set { team = value; }
        }
        
        private int price;
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

        #endregion
    }
}
