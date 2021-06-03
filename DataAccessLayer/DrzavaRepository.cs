/* VSMTI, 2021. 
 * Programiranje u .NET okolini
 * Konstrukcijska vježba: Temperatura
 * Izradio: Nikola Stjepanović
 * Profesori:
 * Ivan Heđi, dipl.ing., v. pred.
 * Slobodan Mamula, dipl.ing.
*/
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
    public class DrzavaRepository
    {
        string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=!!!;";

        public List<Drzava> _drzave = new List<Drzava>();
        public DrzavaRepository()
        {
            _drzave = getDrzave();
        }
        public List<Drzava> getDrzave()
        {
            var _SveDrzave = new List<Drzava>();
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Stjepanovic_Drzave]";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _SveDrzave.Add(new Drzava()
                        {
                            sOznakaDrzave = (string)reader["Drzava_Oznaka"],
                            sImeDrzave = (string)reader["Drzava_Ime"]
                        });
                    }
                }
            }
            return _SveDrzave;
        }
        public List<string> DajImenaDrzava()
        {
            var _svaimenadrzava = (from a in _drzave select a.sImeDrzave.ToString()).ToList();
            _svaimenadrzava = _svaimenadrzava.OrderBy(x => x).ToList();
            return _svaimenadrzava;
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
