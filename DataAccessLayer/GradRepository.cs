/* VSMTI, 2021. 
 * Programiranje u .NET okolini
 * Konstrukcijska vježba: Temperatura
 * Izradio: Nikola Stjepanović
 * Profesori:
 * Ivan Heđi, dipl.ing., v. pred.
 * Slobodan Mamula, dipl.ing.
*/
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GradRepository
    {
        string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=!!!;";
        public DrzavaRepository drzavarepository = new DrzavaRepository();
        public List<Grad> _gradovi = new List<Grad>();
        public List<Grad> dajGradove()
        {
            var _gradovis = getGradovi();
            var _drzave = drzavarepository.getDrzave();
            var _gradovii = _gradovis;
            foreach (var x in _drzave)
            {
                foreach ( var y in _gradovii)
                {
                    if (x.sOznakaDrzave == y.sGrad_Drzava)
                    {
                        y.sGrad_Drzava = x.sImeDrzave;
                    }
                }
            }
            return _gradovii;
        }
        public List<Grad> DajGradovePoDrzavi(string oznakadrzave)
        {
            var _SviGradovi = new List<Grad>();
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM [Stjepanovic_Gradovi] WHERE {oznakadrzave}==Grad_Drzava";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _SviGradovi.Add(new Grad()
                        {
                            nGrad_Id = (int)reader["Grad_Id"],
                            sGrad_Naziv = (string)reader["Grad_Naziv"],
                            sGrad_Lat = (string)reader["Grad_Lat"],
                            sGrad_Lng = (string)reader["Grad_Lng"],
                            sGrad_Drzava = (string)reader["Grad_Drzava"]
                        });
                    }
                }
            }
            return _SviGradovi;
        }
        public List<Grad> getGradovi()
        {
            var _SviGradovi = new List<Grad>();
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Stjepanovic_Gradovi]";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _SviGradovi.Add(new Grad()
                        {
                            nGrad_Id = (int)reader["Grad_Id"],
                            sGrad_Naziv = (string)reader["Grad_Naziv"],
                            sGrad_Lat = (string)reader["Grad_Lat"],
                            sGrad_Lng = (string)reader["Grad_Lng"],
                            sGrad_Drzava = (string)reader["Grad_Drzava"]
                        });
                    }
                }
            }
            return _SviGradovi;
        }
        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }
    }
}
