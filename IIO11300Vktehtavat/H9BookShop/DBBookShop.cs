using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H9BookShop {
    public class DBBookShop {
        public static DataTable GetTestData() {

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("author", typeof(string));
            dt.Columns.Add("country", typeof(string));
            dt.Columns.Add("year", typeof(int));
            dt.Rows.Add(11, "Pekka Lipposen seikkailut", "Outsider", "Suomi", 1950);
            dt.Rows.Add(12, "Lucky Luke", "René Coscinny", "Belgia", 1946);

            return dt;
        }
        public static DataTable GetBooks(string connStr) {
            try {
                using (SqlConnection conn = new SqlConnection(connStr)) {
                    string sql = "SELECT id, name, author, country, year FROM books";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Books");
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }

            } catch (Exception ex) {
                throw ex;
            }
        }
        public static int UpdateBook(string connStr, int id, string name, string author, string country, int year) {

            try {
                using (SqlConnection conn = new SqlConnection(connStr)) {
                    string sql = string.Format("UPDATE books SET name=@Nimi, author=@Kirjailija, country='{3}', year={4} WHERE id={0}", id, name, author, country, year);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlParameter sp;
                    sp = new SqlParameter("Nimi", SqlDbType.NVarChar);
                    sp.Value = name;
                    cmd.Parameters.Add(sp);
                    sp = new SqlParameter("Kirjailija", SqlDbType.NVarChar);
                    sp.Value = name;
                    cmd.Parameters.Add(sp);
                    int lkm = cmd.ExecuteNonQuery();
                    conn.Close();
                    return lkm;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static int InsertBook(string connStr, string name, string author, string country, int year) {
            try {
                using (SqlConnection conn = new SqlConnection(connStr)) {
                    string sql = "INSERT INTO books (name, author, country, year) VALUES(@Nimi, @Kirjailija, @Maa, @Vuosi)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Nimi", name);
                    cmd.Parameters.AddWithValue("@Kirjailija", author);
                    cmd.Parameters.AddWithValue("@Maa", country);
                    cmd.Parameters.AddWithValue("@Vuosi", year);
                   
                    int lkm = cmd.ExecuteNonQuery();
                    conn.Close();
                    return lkm;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static int DeleteBook(string connStr, int id) {
            try {
                using (SqlConnection conn = new SqlConnection(connStr)) {
                    conn.Open();
                    string sql = string.Format("DELETE FROM books WHERE id={0}", id);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int lkm = cmd.ExecuteNonQuery();
                    return lkm;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}

