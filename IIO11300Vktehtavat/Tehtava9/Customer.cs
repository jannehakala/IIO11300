using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava9 {
    public static class Customer {
        public static DataTable GetAllCustomersFromSQLServer(string connectionStr, string table, out string message) {
            try {
                using (SqlConnection conn = new SqlConnection(connectionStr)) {
                    conn.Open();
                    string sql = "SELECT * FROM " + table;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, table);
                    conn.Close();
                    message = " asiakkaan tiedot haettu";
                    return ds.Tables[table];
                }
            } catch (Exception ex) {
                message = ex.Message;
                throw;
            }
        }
        public static void CreateNewCustomer(string connectionStr, string table, out string message, string firstname, string lastname, string address, string zip, string city) {
            try {
                using (SqlConnection conn = new SqlConnection(connectionStr)) {
                    conn.Open();
                    string sql = string.Format("INSERT INTO customer (firstname, lastname, address, zip, city) VALUES ('{0}','{1}','{2}','{3}','{4}')", firstname, lastname, address, zip, city);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    message = string.Format("Lisätty uusi asiakas: {0} {1}", lastname, firstname);
                }
            } catch (Exception ex) {
                message = ex.Message;
                throw;
            }
        }
        public static void DeleteCustomer(string connectionStr, string table, out string message, string lastname) {
            try {
                using (SqlConnection conn = new SqlConnection(connectionStr)) {
                    conn.Open();
                    string sql = string.Format("DELETE FROM customer WHERE lastname='{0}'", lastname);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    message = "Asiakas poistettu!";
                }
            } catch (Exception ex) {
                message = ex.Message;
                throw;
            }
        }
    }
}
