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
    public class MjerenjaRepository
    {
        public List<Mjerenja> getMjerenjaAPI(int idgrada,string lat, string lng)
        {
            string url = $"{lat}&lon={lng}&appid=d9a74b1412c42b33e3f2d9a19564e631";
            List<Mjerenja> _mjerenjaa = new List<Mjerenja>();
            string json = "[" + CallRestMethod(url) + "]";
            JArray jsonObject = JArray.Parse(json);
            foreach (JObject item in jsonObject)
            {
                _mjerenjaa.Add(new Mjerenja
                {
                    sMjerenje_Iznos = (string)item.SelectToken("main.temp"),
                    nMjerenje_IdGrada = idgrada,
                    sMjerenje_Datum = DateTime.Now.ToString()
                }); ;
            }
            string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=!!!;";
            using (DbConnection oConnection = new SqlConnection(connectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())
            {
                oCommand.CommandText = $"INSERT INTO [Stjepanovic_MjerenjaTemp] (Mjerenje_Iznos, Mjerenje_IdGrada, Mjerenje_Datum) VALUES('{_mjerenjaa[0].sMjerenje_Iznos}', '{_mjerenjaa[0].nMjerenje_IdGrada}', '{_mjerenjaa[0].sMjerenje_Datum}')";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {

                }
            }
            return _mjerenjaa;
        }
        public List<Mjerenja> dajPovijestMjerenja(int IdGrad)
        {
            List<Mjerenja> _povijestmjerenja = new List<Mjerenja>();
            string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=!!!;";
            using (DbConnection oConnection = new SqlConnection(connectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())
            {
                oCommand.CommandText = $"SELECT * FROM [Stjepanovic_MjerenjaTemp] WHERE Mjerenje_IdGrada = {IdGrad}";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        _povijestmjerenja.Add(new Mjerenja()
                        {
                            sMjerenje_Iznos = (string)oReader["Mjerenje_Iznos"],
                            nMjerenje_IdGrada = (int)oReader["Mjerenje_IdGrada"],
                            sMjerenje_Datum = (string)oReader["Mjerenje_Datum"]
                        });
                    }
                }
            }
            _povijestmjerenja.Reverse();
            return _povijestmjerenja;
        }
        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?lat=" + url);
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
