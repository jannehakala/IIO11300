using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava10 {

    public class Pelaaja {
        #region PROPERTIES

        private int id;
        public int Id {
            get { return id; }
        }

        private string sukunimi;
        public string Sukunimi {
            get { return sukunimi; }
            set { sukunimi = value; }
        }

        private string etunimi;
        public string Etunimi {
            get { return etunimi; }
            set { etunimi = value; }
        }

        private string seura;
        public string Seura {
            get { return seura; }
            set { seura = value; }
        }

        private int arvo;
        public int Arvo {
            get { return arvo; }
            set { arvo = value; }
        }

        #endregion
        #region CONSTRUCTORS
        public Pelaaja(int id) {
            this.id = id;
        }

        public Pelaaja(int id, string sukunimi, string etunimi, string seura, int arvo) {
            this.id = id;
            this.sukunimi = sukunimi;
            this.etunimi = etunimi;
            this.seura = seura;
            this.arvo = arvo;
        }
        #endregion
        #region METHODS
        public override string ToString() {
            return etunimi + " " + sukunimi + ", " + seura;
        }
        #endregion
    }
    public class Liiga {
        private static string cs = Tehtava10.Properties.Settings.Default.Tietokanta;

        public static List<Pelaaja> GetPelaajat() {
            try {
                DataTable dt;
                List<Pelaaja> pelaajat = new List<Pelaaja>();
                dt = DBPelaajat.GetPelaajat(cs);

                Pelaaja pelaaja;
                foreach (DataRow row in dt.Rows) {
                    pelaaja = new Pelaaja(int.Parse(row["id"].ToString()));
                    pelaaja.Etunimi = row["etunimi"].ToString();
                    pelaaja.Sukunimi = row["sukunimi"].ToString();
                    pelaaja.Seura = row["seura"].ToString();
                    pelaaja.Arvo = int.Parse(row["arvo"].ToString());

                    pelaajat.Add(pelaaja);
                }
                return pelaajat;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static int UpdatePelaaja(Pelaaja pelaaja) {
            try {
                int lkm = DBPelaajat.UpdatePelaaja(cs, pelaaja.Id, pelaaja.Etunimi, pelaaja.Sukunimi, pelaaja.Seura, pelaaja.Arvo);
                return lkm;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static bool InsertPelaaja(Pelaaja pelaaja) {
            try {
                int lkm = DBPelaajat.InsertPelaaja(cs, pelaaja.Id, pelaaja.Etunimi, pelaaja.Sukunimi, pelaaja.Seura, pelaaja.Arvo);
                if (lkm > 0) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static int GetMaxId() {
            try {

                int id = DBPelaajat.GetMaxId(cs);
                return id;
            } catch (Exception ex) {

                throw ex;
            }
        }
    }
}

