using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava10 {
    public class DBPelaajat {
        public static DataTable GetPelaajat(string connStr) {
            try {
                using (OleDbConnection conn = new OleDbConnection(connStr)) {
                    string sql = "SELECT id, etunimi, sukunimi, seura, arvo FROM Pelaajat";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable("Pelaajat");
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static int InsertPelaaja(string connStr, int id, string etunimi, string sukunimi, string seura, int arvo) {
            try {
                using(OleDbConnection conn = new OleDbConnection(connStr)) {
                    string sql = "INSERT INTO Pelaajat (id, etunimi, sukunimi, seura, arvo) VALUES(@Id, @Etunimi, @Sukunimi, @Seura, @Arvo)";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Etunimi", etunimi);
                    cmd.Parameters.AddWithValue("@Sukunimi", sukunimi);
                    cmd.Parameters.AddWithValue("@Seura", seura);
                    cmd.Parameters.AddWithValue("@Arvo", arvo);

                    int lkm = cmd.ExecuteNonQuery();
                    conn.Close();
                    return lkm;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static int UpdatePelaaja(string connStr, int id, string etunimi, string sukunimi, string seura, int arvo) {
            try {
                using (OleDbConnection conn = new OleDbConnection(connStr)) {   
                    string sql = string.Format("UPDATE Pelaajat SET etunimi=@Etunimi, sukunimi=@Sukunimi, seura=@Seura, arvo=@Arvo WHERE id={0}", id, etunimi, sukunimi, seura, arvo);
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Etunimi", etunimi);
                    cmd.Parameters.AddWithValue("@Sukunimi", sukunimi);
                    cmd.Parameters.AddWithValue("@Seura", seura);
                    cmd.Parameters.AddWithValue("@Arvo", arvo);

                    int lkm = cmd.ExecuteNonQuery();
                    conn.Close();
                    return lkm;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static int GetMaxId(string connStr) {

            try {
                using(OleDbConnection conn = new OleDbConnection(connStr)) {
                    string sql = "SELECT MAX(id) FROM Pelaajat";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);

                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                    return id + 1;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}