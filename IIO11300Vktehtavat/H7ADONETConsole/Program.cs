﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H7ADONETConsole {
    class Program {
        static void Main(string[] args) {
            try {
                
                string connStr = H7ADONETConsole.Properties.Settings.Default.Tietokanta;
                using (SqlConnection conn = new SqlConnection(connStr)) {
                    //1 luodaan yhteys
                    conn.Open();
                    //2 luodaan komento ja suoritetaan se
                    SqlCommand cmd = new SqlCommand("SELECT asioid, lastname, firstname, date FROM presences WHERE asioid = 'H3298'", conn);
                    //3 käydään tulos=Reader-olio läpi
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //4 käydään rdr läpi
                    if (rdr.HasRows) {
                        int lkm = 0;
                        while (rdr.Read()) {
                            Console.WriteLine("Läsnäolosi{0} {1} {2} {3}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDateTime(3).ToShortDateString());
                            lkm++;
                        }
                        Console.WriteLine("Tulostettu {0} läsnäoloa", lkm);
                    }
                    //sulje yhteys
                    rdr.Close();
                    conn.Close();
                    Console.WriteLine("Tietokantayhteys suljettiin onnistuneesti");
                }
               
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);
            } finally {
                Console.ReadKey();
            }
        }
    }
}
