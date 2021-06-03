using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTemperatura
{
    public partial class FormLatLng : Form
    {
        public FormLatLng()
        {
            InitializeComponent();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            lblOblacno.Hide();
        }

        private void btnIzmjeri_Click(object sender, EventArgs e)
        {
            bool ispravanunos = true;
            if (String.IsNullOrEmpty(txtBoxLatituda.Text) == true)
            {
                ispravanunos = false;
                MessageBox.Show("Obavezno je upisati latitudu!");
            }
            else
            {
                if (IsDigitsOnlyLatLng(txtBoxLatituda.Text, 0) == false)
                {
                    MessageBox.Show("Unesena latituda nije broj ili nije u rasponu od -90 do 90");
                    ispravanunos = false;
                }
            }
            if (String.IsNullOrEmpty(txtBoxLongituda.Text) == true)
            {
                ispravanunos = false;
                MessageBox.Show("Obavezno je upisati longitudu!");
            }
            else
            {
                if (IsDigitsOnlyLatLng(txtBoxLongituda.Text, 1) == false)
                {
                    MessageBox.Show("Unesena longituda nije broj ili nije u rasponu od -180 do 180");
                    ispravanunos = false;
                }
            }
            if (ispravanunos == true)
            {
                getMjerenjaAPI(txtBoxLatituda.Text, txtBoxLongituda.Text);
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
                label7.Show();
                label8.Show();
                label9.Show();
                label10.Show();
                label11.Show();
                lblOblacno.Show();
            }
        }
        public void getMjerenjaAPI(string lat, string lng)
        {
            string url = $"{lat}&lon={lng}&appid=d9a74b1412c42b33e3f2d9a19564e631&lang=hr";
            string json = "[" + CallRestMethod(url) + "]";
            JArray jsonObject = JArray.Parse(json);
            foreach (JObject item in jsonObject)
            {
                if (String.IsNullOrEmpty((string)item.SelectToken("current.temp")) == false)
                {
                    label1.Text = (string)item.SelectToken("current.temp");
                }
                else
                {
                    label1.Text = "Nema podatka";
                }
                if (String.IsNullOrEmpty((string)item.SelectToken("current.feels_like")) == false)
                {
                    label2.Text = (string)item.SelectToken("current.feels_like");
                }
                else
                {
                    label2.Text = "Nema podatka";
                }
                if (String.IsNullOrEmpty((string)item.SelectToken("current.humidity")) == false)
                {
                    label3.Text = (string)item.SelectToken("current.humidity");
                }
                else
                {
                    label3.Text = "Nema podatka";
                }
                if (String.IsNullOrEmpty((string)item.SelectToken("current.pressure")) == false)
                {
                    label5.Text = (string)item.SelectToken("current.pressure");
                }
                else
                {
                    label5.Text = "Nema podatka";
                }
                if (String.IsNullOrEmpty((string)item.SelectToken("current.uvi")) == false)
                {
                    label6.Text = (string)item.SelectToken("current.uvi");
                }
                else
                {
                    label6.Text = "Nema podatka";
                }
                if (String.IsNullOrEmpty((string)item.SelectToken("current.visibility")) == false)
                {
                    label7.Text = (string)item.SelectToken("current.visibility");
                }
                else
                {
                    label7.Text = "Nema podatka";
                }
                if (String.IsNullOrEmpty((string)item.SelectToken("current.wind_speed")) == false)
                {
                    label8.Text = (string)item.SelectToken("current.wind_speed");
                }
                else
                {
                    label8.Text = "Nema podatka";
                }
                if (String.IsNullOrEmpty((string)item.SelectToken("current.sunrise")) == false)
                {
                    var sunrise = (double)item.SelectToken("current.sunrise");
                    System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    dtDateTime = dtDateTime.AddSeconds(sunrise).ToLocalTime();
                    label9.Text = dtDateTime.ToString();
                }
                else
                {
                    label9.Text = "Nema podatka";
                }
                if (String.IsNullOrEmpty((string)item.SelectToken("current.sunset")) == false)
                {
                    var sunset = (double)item.SelectToken("current.sunset");
                    System.DateTime dtDateTimee = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    dtDateTimee = dtDateTimee.AddSeconds(sunset).ToLocalTime();
                    label10.Text = dtDateTimee.ToString();
                }
                else
                {
                    label10.Text = "Nema podatka";
                }
                if (String.IsNullOrEmpty((string)item.SelectToken("current.weather[0].description")) == false)
                {
                    label11.Text = (string)item.SelectToken("current.weather[0].description");
                }
                else
                {
                    label11.Text = "Nema podatka";
                }
                pictureBox1.ImageLocation = "http://openweathermap.org/img/wn/" + (string)item.SelectToken("current.weather[0].icon") + "@4x.png";
            }
            label1.Text = "Trenutna temperatura " + Convert.ToString(Convert.ToDecimal(label1.Text.Replace(".", ","))-Convert.ToDecimal(273.15)).Replace(",",".") + "°C";
            label2.Text = "Osjećaj kao da je " + Convert.ToString(Convert.ToDecimal(label2.Text.Replace(".", ",")) - Convert.ToDecimal(273.15)).Replace(",", ".") + "°C";
            label3.Text = "Vlažnost zraka " + label3.Text + "%";
            label5.Text = "Tlak zraka " + label5.Text + " hPa";
            label6.Text = "UV Zračenje " + label6.Text;
            label7.Text = "Vidljivost " + label7.Text + " m";
            label8.Text = "Brzina vjetra " + label8.Text + " m/s";
            label9.Text = "Izlazak sunca " + label9.Text;
            label10.Text = "Zalazak sunca " + label10.Text;
        }
        public bool IsDigitsOnlyLatLng(string str, int deg) // Provjera je li format unesene latitude i longitude tocan
        {
            bool provjera = true;
            int brojactocki = 0;
            if (str.Length > 0)
            {
                if (str[0] == '.')
                {
                    provjera = false;
                }
                if (str[str.Length - 1] == '.')
                {
                    provjera = false;
                }
            }
            var brojac = 0;
            foreach (char c in str)
            {
                brojac = brojac + 1;
                if (brojac != 1)
                {
                    if (c == '-')
                    {
                        provjera = false;
                    }
                }
                if (c == '.')
                {
                    brojactocki = brojactocki + 1;
                }
            }
            if (brojactocki > 1)
            {
                provjera = false;
            }
            foreach (char c in str)
            {
                if ((c < '0' || c > '9') && (c != '.') && (c != '-'))
                {
                    provjera = false;
                }
            }
            double dblString;
            if (deg == 0)
            {
                if (provjera == true)
                {
                    dblString = Convert.ToDouble(str.Replace(".", ","));
                    if (dblString > 90 || dblString < -90)
                    {
                        provjera = false;
                    }
                }
            }
            if (deg == 1)
            {
                if (provjera == true)
                {
                    dblString = Convert.ToDouble(str.Replace(".", ","));
                    if (dblString > 180 || dblString < -180)
                    {
                        provjera = false;
                    }
                }
            }
            return provjera;
        }
        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create("http://api.openweathermap.org/data/2.5/onecall?lat=" + url);
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
