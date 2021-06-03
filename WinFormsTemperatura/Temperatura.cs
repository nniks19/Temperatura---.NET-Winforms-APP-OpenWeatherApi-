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
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;
using DataAccessLayer;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using System.Runtime.Serialization;

namespace WinFormsTemperatura
{
    public partial class Temperatura : Form
    {
        public struct KartaTemp // Struktura, spaja oznaku drzave sa iznosom temperature
        {
            public string sDrzavaOznaka;
            public double dTemperatura;
        }
        public struct DateModel // Struktura služi za graf
        {
            public DateTime DateTime { get; set; }
            public double Value { get; set; }
            public DateModel(double val, DateTime datee)
            {
                Value = val;
                DateTime = datee;
            }
        }
        // kreiranje BindingSource i Repository tipova
        public GradRepository _gradRepository = new GradRepository();
        public DrzavaRepository _drzaveRepository = new DrzavaRepository();
        public MjerenjaRepository _mjerenjaRepository = new MjerenjaRepository();
        public BindingSource _tableBindingSource1 = new BindingSource();
        public BindingSource _tableBindingSource2 = new BindingSource();
        public BindingSource _comboboxBindingSource1 = new BindingSource();
        public BindingSource _comboboxBindingSource2 = new BindingSource();
        public BindingSource _comboboxBindingSource3 = new BindingSource();
        public BindingSource _comboboxBindingSource4 = new BindingSource();
        public LiveCharts.WinForms.GeoMap geoMap = new LiveCharts.WinForms.GeoMap();
        public List<KartaTemp> _kartatemp = new List<KartaTemp>();
        public string pametnavarijablastupanj = "C"; //  saznanje u kojoj temperaturnoj jedinici je izmjerena temperatura. (kod pretvorbe)
        public bool clickedornot = false; //  izbacivanje obavijesti kod karte samo prvi put
        public Temperatura()
        {
            InitializeComponent();
            _tableBindingSource1.DataSource = getGradoviii();
            _comboboxBindingSource1.DataSource = _drzaveRepository.DajImenaDrzava();
            _comboboxBindingSource2.DataSource = _drzaveRepository.DajImenaDrzava();
            _comboboxBindingSource3.DataSource = _drzaveRepository.DajImenaDrzava();
            _comboboxBindingSource4.DataSource = _drzaveRepository.DajImenaDrzava();
        }
        private void Temperatura_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _tableBindingSource1;
            dataGridViewPovijest.DataSource = _tableBindingSource2;
            comboBoxDrzave.DataSource = _comboboxBindingSource1;
            comboBoxSortGradove.DataSource = _comboboxBindingSource2;
            comboBoxSortGradove2.DataSource = _comboboxBindingSource3;
            dataGridViewPovijest.AutoGenerateColumns = false;
            DataGridViewImageColumn oEditbutton = new DataGridViewImageColumn();
            oEditbutton.Image = Image.FromFile(@"C:\Users\NS\source\repos\Temperatura\WinFormsTemperatura\Resources\iconedit.png");
            dataGridView1.Columns.Add(oEditbutton);
            oEditbutton.Width = 30;
            oEditbutton.HeaderText = "Uredi";
            oEditbutton.Name = "Uredi";
            DataGridViewImageColumn oDeletebutton = new DataGridViewImageColumn();
            oDeletebutton.Image = Image.FromFile(@"C:\Users\NS\source\repos\Temperatura\WinFormsTemperatura\Resources\icondelete.png");
            dataGridView1.Columns.Add(oDeletebutton);
            oDeletebutton.Width = 40;
            oDeletebutton.HeaderText = "Obriši";
            oDeletebutton.Name = "Obriši";
            dataGridView1.AutoGenerateColumns = false;
            UcitajKartu();
            dataGridViewPovijest.Hide();
            btnFarad.Hide();
            btnCelzij.Hide();
            btnKelvin.Hide();

        } // Load programa
        public void GradoviPoDrzavama() //  vraća imena gradiva ovisno iz koje države su ti gradovi (tab Mjerenja)
        {
            List<Grad> _gradovi;
            string drzava = comboBoxSortGradove.SelectedItem.ToString();
            _gradovi = getGradoviii();
            _gradovi = _gradovi.Where(x => x.sGrad_Drzava == drzava).ToList();
            comboBoxGradovi.DisplayMember = "sGrad_Naziv";
            comboBoxGradovi.ValueMember = "nGrad_Id";
            comboBoxGradovi.DataSource = _gradovi;

        }
        public void GradoviPoDrzavama2()//  vraća imena gradiva ovisno iz koje države su ti gradovi (tab Grafikon)
        {
            string drzava = comboBoxSortGradove2.SelectedItem.ToString();
            var _gradovi2 = getGradoviii();
            _gradovi2 = _gradovi2.Where(x => x.sGrad_Drzava == drzava).ToList();
            List<String> _gradovii;
            _gradovii = _gradovi2.Select(x => x.sGrad_Naziv).ToList();
            _gradovii.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            _gradovii = _gradovii.OrderBy(x => x).ToList();
            checkedListBoxGradovi.DataSource = _gradovii;
        }
        public void DodajGrad(Grad ograd)
        {
            string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=!!!;";
            using (DbConnection oConnection = new SqlConnection(connectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())
            {
                var _imenadrzava = _drzaveRepository.getDrzave();
                for (int i = 0; i < _imenadrzava.Count(); i++)
                {
                    if (ograd.sGrad_Drzava == _imenadrzava[i].sImeDrzave)
                    {
                        ograd.sGrad_Drzava = _imenadrzava[i].sOznakaDrzave;
                    }
                }
                oCommand.CommandText = $"INSERT INTO [Stjepanovic_Gradovi] (Grad_Id, Grad_Naziv, Grad_Lat, Grad_Lng, Grad_Drzava) VALUES('{ograd.nGrad_Id}', '{ograd.sGrad_Naziv}', '{ograd.sGrad_Lat}', '{ograd.sGrad_Lng}', '{ograd.sGrad_Drzava}')";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {

                }
            }
        } // Dodavanje novog grada u bazu
        public void ProvjeraZasebno() // Provjera zasebnojesu li dobro unesene vrijednosti za dodavanje novog grada, ako nisu ispisuje se pogreska
        {
            if (txtBoxIdGrada.Text.Any(char.IsDigit) == true && ProvjeraPostojecegID(Convert.ToInt32(txtBoxIdGrada.Text)) == true)
            {
                MessageBox.Show("Uneseni ID grada već postoji u bazi podataka!");
            }
            if (txtBoxIdGrada.Text.Any(char.IsDigit) == false)
            {
                MessageBox.Show("Uneseni ID grada nije broj!");
            }
            if (String.IsNullOrEmpty(txtBoxIdGrada.Text) == true || txtBoxIdGrada.Text == "Id grada")
            {
                MessageBox.Show("Obavezan je unos ID grada!");
            }
            if (String.IsNullOrEmpty(txtBoxNazivGrada.Text) == true || txtBoxNazivGrada.Text == "Naziv grada")
            {
                MessageBox.Show("Obavezan je unos naziva grada!");
            }
            if (String.IsNullOrEmpty(txtBoxLatituda.Text) == true || txtBoxLatituda.Text == "Latituda")
            {
                MessageBox.Show("Obavezan je unos latitude grada!");
            }
            if (String.IsNullOrEmpty(txtBoxLongituda.Text) == true || txtBoxLongituda.Text == "Longituda")
            {
                MessageBox.Show("Obavezan je unos longitude grada!");
            }
            if (IsDigitsOnlyLatLng(txtBoxLongituda.Text, 1) == false)
            {
                MessageBox.Show("Unesena longituda nije dobroga formata / nije u rasponu od -90 do 90");
            }
            if (IsDigitsOnlyLatLng(txtBoxLatituda.Text, 0) == false)
            {
                MessageBox.Show("Unesena latituda nije dobroga formata / nije u rasponu od -90 do 90");
            }
        }
        public bool ProvjeraSvih()
        {
            bool provjera = true;
            if (IsDigitsOnlyLatLng(txtBoxLatituda.Text, 0) == false || IsDigitsOnlyLatLng(txtBoxLongituda.Text, 1) == false || String.IsNullOrEmpty(txtBoxIdGrada.Text) == true || txtBoxIdGrada.Text == "Id grada" || String.IsNullOrEmpty(txtBoxNazivGrada.Text) == true || txtBoxNazivGrada.Text == "Naziv grada" || String.IsNullOrEmpty(txtBoxLatituda.Text) == true || txtBoxLatituda.Text == "Latituda" || String.IsNullOrEmpty(txtBoxLongituda.Text) == true || txtBoxLongituda.Text == "Longituda" || !txtBoxIdGrada.Text.Any(char.IsDigit) || ProvjeraPostojecegID(Convert.ToInt32(txtBoxIdGrada.Text)) == true)
            {
                provjera = false;
            }
            return provjera;
        } // Provjera unosa, kako bi se dodao novi grad
        public bool ProvjeraPostojecegID(int idgrada) // Provjera postoji li taj grad već u bazi
        {
            var _gradovii = _gradRepository.dajGradove();
            bool postojili = false;
            for (int i = 0; i < _gradovii.Count(); i++)
            {
                if (_gradovii[i].nGrad_Id == idgrada)
                {
                    postojili = true;
                }
            }
            return postojili;

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
                    if (dblString >= 90 || dblString <= -90)
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
                    if (dblString >= 180 || dblString <= -180)
                    {
                        provjera = false;
                    }
                }
            }
            return provjera;
        }
        public string DajTemperaturu(int idgrada,string lat, string lng)
        {
            var _mjerenja = _mjerenjaRepository.getMjerenjaAPI(idgrada,lat,lng);
            return _mjerenja[0].sMjerenje_Iznos;
        } // Izvlacenje temperature iz API-ja
        public void UcitajKartu() //  učitavanje geografsku kartu 
        {
            geoMap.Source = $"{Application.StartupPath}\\World.xml";
            Dictionary<string, double> keyValues = new Dictionary<string, double>();
            List<Mjerenja> _mjerenjepogradu = new List<Mjerenja>();
            var _izmjerenetemperature = PovijestMjerenjaa();
            var _svigradovi = _gradRepository.getGradovi();
            var _drzave = _drzaveRepository.getDrzave();
            _svigradovi.RemoveAll(a => !_izmjerenetemperature.Exists(b => a.nGrad_Id == b.nMjerenje_IdGrada));
            for (int i = 0; i < _svigradovi.Count(); i++)
            {
                double mjerenje = 0;
                int brojac = 0;
                for (int j = 0; j < _izmjerenetemperature.Count(); j++)
                {
                    if (_svigradovi[i].nGrad_Id == _izmjerenetemperature[j].nMjerenje_IdGrada)
                    {
                        mjerenje = mjerenje + Convert.ToDouble(_izmjerenetemperature[j].sMjerenje_Iznos.Replace(".", ","));
                        brojac = brojac + 1;
                    }
                }
                if (brojac != 0)
                {
                    double x = mjerenje / brojac;
                    _mjerenjepogradu.Add(new Mjerenja() { nMjerenje_IdGrada = _svigradovi[i].nGrad_Id, sMjerenje_Iznos = Convert.ToString(x).Replace(",", ".") });
                }
            }
            for (int i = 0; i < _drzave.Count(); i++)
            {
                int brojac = 0;
                double ukupnodrzava = 0;
                for (int j = 0; j < _svigradovi.Count(); j++)
                {
                    if (_svigradovi[j].sGrad_Drzava == _drzave[i].sOznakaDrzave)
                    {
                        for (int k = 0; k < _mjerenjepogradu.Count(); k++)
                        {
                            if (_svigradovi[j].nGrad_Id == _mjerenjepogradu[k].nMjerenje_IdGrada)
                            {
                                brojac = brojac + 1;
                                ukupnodrzava = ukupnodrzava + Convert.ToDouble(_mjerenjepogradu[k].sMjerenje_Iznos.Replace(".", ","));
                            }
                        }
                    }
                }

                if (brojac != 0)
                {
                    keyValues[_drzave[i].sOznakaDrzave.Replace(" ", "")] = Convert.ToDouble(ukupnodrzava / brojac);
                    _kartatemp.Add(new KartaTemp() { sDrzavaOznaka = _drzave[i].sOznakaDrzave.Replace(" ", ""), dTemperatura = ukupnodrzava / brojac });


                }
                if (brojac == 0)
                {
                    _kartatemp.Add(new KartaTemp() { sDrzavaOznaka = _drzave[i].sOznakaDrzave.Replace(" ", ""), dTemperatura = 0 });
                }
            }
            geoMap.LandClick += geoMap_LandClick;
            geoMap.HeatMap = keyValues;
            metroTabPage2.Controls.Add(geoMap);
            geoMap.Dock = DockStyle.Fill;
        }
        public void geoMap_LandClick(object arg1, LiveCharts.Maps.MapData arg2) // Prikaz pritiskom na kartu
        {
            bool pronaden = false;
            for (int i = 0; i < _kartatemp.Count(); i++)
            {

                if (_kartatemp[i].sDrzavaOznaka == arg2.Id)
                {
                    pronaden = true;
                    string url = $"{arg2.Name}&appid=d9a74b1412c42b33e3f2d9a19564e631";
                    string json = "[" + CallRestMethod(url) + "]";
                    JArray jsonObject = JArray.Parse(json);
                    double trenutnatemperatura = 0;
                    foreach (JObject item in jsonObject)
                    {
                        trenutnatemperatura = (double)item.SelectToken("main.temp");
                    }
                    if (_kartatemp[i].dTemperatura != 0)
                    {
                        MessageBox.Show("Oznaka države: " + arg2.Id + Environment.NewLine + "Naziv države: " + arg2.Name + Environment.NewLine + "Prosječna temperatura: " + Convert.ToDecimal((_kartatemp[i].dTemperatura - 273.15)).ToString("0.00") + "°C" + Environment.NewLine + "Trenutna temperatura: " + Convert.ToDecimal(trenutnatemperatura - 273.15).ToString("0.00") + "°C");
                    }
                    if (_kartatemp[i].dTemperatura == 0)
                    {
                        MessageBox.Show("Oznaka države: " + arg2.Id + Environment.NewLine + "Naziv države: " + arg2.Name + Environment.NewLine + "Prosječna temperatura: " + "Prosječna temperatura je 0 ili ne postoje mjerenja za ovu državu" + Environment.NewLine + "Trenutna temperatura: " + Convert.ToDecimal(trenutnatemperatura - 273.15).ToString("0.00") + "°C");
                    }
                }
            }
            if (pronaden == false)
            {
                MessageBox.Show("Podatci za ovu državu ne postoje!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        } // Zatvaranje forme

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        } // Minimiziranje forme
        public List<Grad> getGradoviii()
        {
            var _SviGradovi = new List<Grad>();
            string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=!!!;";
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
            var _drzave = _drzaveRepository.getDrzave();
            foreach (var x in _drzave)
            {
                foreach (var y in _SviGradovi)
                {
                    if (x.sOznakaDrzave == y.sGrad_Drzava)
                    {
                        y.sGrad_Drzava = x.sImeDrzave;
                    }
                }
            }
            _SviGradovi.Sort((x, y) => string.Compare(x.sGrad_Naziv, y.sGrad_Naziv));
            return _SviGradovi;
        } // Učitavanje gradova iz baze - za datagridview da odmah nove dohvati
        private void btnDodajGrad_Click(object sender, EventArgs e)
        {
            Grad oGrad = new Grad();
            if (txtBoxIdGrada.Text.Any(char.IsDigit) == true)
            {
                oGrad.nGrad_Id = Convert.ToInt32(txtBoxIdGrada.Text);
            }
            oGrad.sGrad_Naziv = txtBoxNazivGrada.Text;
            oGrad.sGrad_Lat = txtBoxLatituda.Text;
            oGrad.sGrad_Lng = txtBoxLongituda.Text;
            oGrad.sGrad_Drzava = comboBoxDrzave.SelectedItem.ToString();
            if (ProvjeraSvih() == true)
            {
                DodajGrad(oGrad);
                MessageBox.Show("Grad sa slijedećim podacima uspješno dodan! " + Environment.NewLine + $"ID grada :{oGrad.nGrad_Id}" + Environment.NewLine + $"Ime grada: {oGrad.sGrad_Naziv}" + Environment.NewLine + $"Latituda: {oGrad.sGrad_Lat}" + Environment.NewLine + $"Longituda: {oGrad.sGrad_Lng}" + Environment.NewLine + $"Država iz koje je grad: {comboBoxDrzave.SelectedItem.ToString()}");
                txtBoxIdGrada.Text = "Id grada";
                txtBoxNazivGrada.Text = "Naziv grada";
                txtBoxLatituda.Text = "Latituda";
                txtBoxLongituda.Text = "Longituda";
                OsvjeziPodatke();
            }
            else
            {
                ProvjeraZasebno();
            }
        } // Tipka na koju pritiskom se dodaje novi grad u bazu
        public void OsvjeziPodatke() // Osvjezavanje datagridviewa
        {
            if (textBoxFilter.Text.Length < 1)
            {
                dataGridView1.Hide();
                dataGridView1.DataSource = null;
                _tableBindingSource1.DataSource = getGradoviii();
                dataGridView1.DataSource = _tableBindingSource1;
                dataGridView1.Show();
                GradoviPoDrzavama();
                GradoviPoDrzavama2();
                btnCelzij.Hide();
                btnKelvin.Hide();
                btnFarad.Hide();
                dataGridViewPovijest.Hide();
                comboBoxGradovi.Hide();
                lblTemperatura.Hide();
                lblGrad.Hide();
            }
            else
            {
                var _sortiranje = getGradoviii();
                var gradovifilter = _sortiranje.Where(x => x.sGrad_Naziv.ToLower().Contains(textBoxFilter.Text.ToLower())).ToList();
                if (gradovifilter.Count > 0)
                {
                    dataGridView1.DataSource = null;
                    _tableBindingSource1.DataSource = gradovifilter;
                    dataGridView1.DataSource = _tableBindingSource1;
                    GradoviPoDrzavama();
                    GradoviPoDrzavama2();
                    btnCelzij.Hide();
                    btnKelvin.Hide();
                    btnFarad.Hide();
                    dataGridViewPovijest.Hide();
                    comboBoxGradovi.Hide();
                    lblTemperatura.Hide();
                    lblGrad.Hide();
                }
                else
                {
                    dataGridView1.DataSource = null;
                    _tableBindingSource1.DataSource = getGradoviii();
                    dataGridView1.DataSource = _tableBindingSource1;
                    GradoviPoDrzavama();
                    GradoviPoDrzavama2();
                    btnCelzij.Hide();
                    btnKelvin.Hide();
                    btnFarad.Hide();
                    dataGridViewPovijest.Hide();
                    comboBoxGradovi.Hide();
                    lblTemperatura.Hide();
                    lblGrad.Hide();
                }
            }
        }
        private void btnKelvin_Click(object sender, EventArgs e)
        {
            if (pametnavarijablastupanj != "K")
            {


                if (pametnavarijablastupanj == "C")
                {
                    lblTemperatura.Text = lblTemperatura.Text.Replace("C", "").Replace("°", "");
                    var temperatura = Convert.ToDecimal(lblTemperatura.Text.Replace(".", ","));
                    temperatura = temperatura + Convert.ToDecimal(273.15);
                    lblTemperatura.Text = temperatura.ToString().Replace(",", ".") + "°K";
                    MessageBox.Show("Trenutna temperatura iz °C pretvorena je u °K");
                    pametnavarijablastupanj = "K";
                }
                if (pametnavarijablastupanj == "F")
                {
                    lblTemperatura.Text = lblTemperatura.Text.Replace("F", "").Replace("°", "");
                    var temperatura = Convert.ToDecimal(lblTemperatura.Text.Replace(".", ","));
                    temperatura = temperatura - 32;
                    temperatura = temperatura * 5;
                    temperatura = temperatura / 9;
                    temperatura = temperatura + Convert.ToDecimal(273.15);
                    lblTemperatura.Text = temperatura.ToString("0.00").Replace(",", ".") + "°K";
                    MessageBox.Show("Trenutna temperatura iz °F pretvorena je u °K");
                    pametnavarijablastupanj = "K";
                }
            }
            else
            {
                MessageBox.Show("Trenutna temperatura koja je izmjerena je već u °K");
            }
        } // Pretvorba u Kelvine

        private void btnCelzij_Click(object sender, EventArgs e)
        {
            if (pametnavarijablastupanj != "C")
            {
                if (pametnavarijablastupanj == "K")
                {
                    lblTemperatura.Text = lblTemperatura.Text.Replace("K", "").Replace("°", "");
                    var temperatura = Convert.ToDecimal(lblTemperatura.Text.Replace(".", ","));
                    temperatura = temperatura - Convert.ToDecimal(273.15);
                    lblTemperatura.Text = temperatura.ToString().Replace(",", ".") + "°C";
                    MessageBox.Show("Trenutna temperatura iz °K pretvorena je u °C");
                    pametnavarijablastupanj = "C";
                }
                if (pametnavarijablastupanj == "F")
                {
                    lblTemperatura.Text = lblTemperatura.Text.Replace("F", "").Replace("°", "");
                    var temperatura = Convert.ToDecimal(lblTemperatura.Text.Replace(".", ","));
                    temperatura = temperatura - 32;
                    temperatura = temperatura * 5;
                    temperatura = temperatura / 9;
                    lblTemperatura.Text = temperatura.ToString("0.00").Replace(",", ".") + "°C";
                    MessageBox.Show("Trenutna temperatura iz °F pretvorena je u °C");
                    pametnavarijablastupanj = "C";
                }
            }
            else
            {
                MessageBox.Show("Trenutna temperatura koja je izmjerena je već u °C");
            }
        } // Pretvorba u celzij

        private void btnFarad_Click(object sender, EventArgs e)
        {
            if (pametnavarijablastupanj != "F")
            {
                if (pametnavarijablastupanj == "K")
                {
                    lblTemperatura.Text = lblTemperatura.Text.Replace("K", "").Replace("°", "");
                    var temperatura = Convert.ToDecimal(lblTemperatura.Text.Replace(".", ","));
                    temperatura = temperatura - Convert.ToDecimal(273.15);
                    temperatura = temperatura * Convert.ToDecimal(1.8);
                    temperatura = temperatura + 32;
                    lblTemperatura.Text = temperatura.ToString().Replace(",", ".") + "°F";
                    MessageBox.Show("Trenutna temperatura iz °K pretvorena je u °F");
                    pametnavarijablastupanj = "F";
                }
                if (pametnavarijablastupanj == "C")
                {
                    lblTemperatura.Text = lblTemperatura.Text.Replace("C", "").Replace("°", "");
                    var temperatura = Convert.ToDecimal(lblTemperatura.Text.Replace(".", ","));
                    temperatura = temperatura * Convert.ToDecimal(1.8);
                    temperatura = temperatura + 32;
                    lblTemperatura.Text = temperatura.ToString().Replace(",", ".") + "°F";
                    MessageBox.Show("Trenutna temperatura iz °C pretvorena je u °F");
                    pametnavarijablastupanj = "F";
                }
            }
            else
            {
                MessageBox.Show("Trenutna temperatura koja je izmjerena je već u °F");
            }
        } // Pretvorba u farad
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e) // pomicanje  aplikacije 
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e) // pomicanje aplikacije
        {
            lastPoint = new Point(e.X, e.Y);
        }
        //picturebox
        private void pictureBox3_Click(object sender, EventArgs e) // Prebacivanje na stranicu vsmti.hr klikom na sliku
        {
            System.Diagnostics.Process.Start("https:/www.vsmti.hr");
        }

        private void txtBoxIdGrada_Enter(object sender, EventArgs e) // Klikom na textbox tekst se brise
        {
            if (txtBoxIdGrada.Text == "Id grada")
            {
                txtBoxIdGrada.Text = "";

                txtBoxIdGrada.ForeColor = Color.White;
            }
        }

        private void txtBoxNazivGrada_Enter(object sender, EventArgs e) // Klikom na textbox tekst se brise
        {
            if (txtBoxNazivGrada.Text == "Naziv grada")
            {
                txtBoxNazivGrada.Text = "";

                txtBoxNazivGrada.ForeColor = Color.White;
            }
        }

        private void txtBoxLatituda_Enter(object sender, EventArgs e) // Klikom na textbox tekst se brise
        {
            if (txtBoxLatituda.Text == "Latituda")
            {
                txtBoxLatituda.Text = "";

                txtBoxLatituda.ForeColor = Color.White;
            }
        }

        private void txtBoxLongituda_Enter(object sender, EventArgs e) // Klikom na textbox tekst se brise
        {
            if (txtBoxLongituda.Text == "Longituda")
            {
                txtBoxLongituda.Text = "";

                txtBoxLongituda.ForeColor = Color.White;
            }
        }

        private void txtBoxIdGrada_Leave(object sender, EventArgs e) // Klikom bilo gdje osim na textbox on vraća početni tekst ako je prazan
        {
            if (txtBoxIdGrada.Text == "")
            {
                txtBoxIdGrada.Text = "Id grada";

                txtBoxIdGrada.ForeColor = Color.White;
            }
        }

        private void txtBoxNazivGrada_Leave(object sender, EventArgs e) // Klikom bilo gdje osim na textbox on vraća početni tekst ako je prazan
        {
            if (txtBoxNazivGrada.Text == "")
            {
                txtBoxNazivGrada.Text = "Naziv grada";

                txtBoxNazivGrada.ForeColor = Color.White;
            }
        }

        private void txtBoxLatituda_Leave(object sender, EventArgs e) // Klikom bilo gdje osim na textbox on vraća početni tekst ako je prazan
        {
            if (txtBoxLatituda.Text == "")
            {
                txtBoxLatituda.Text = "Latituda";

                txtBoxLatituda.ForeColor = Color.White;
            }
        }

        private void txtBoxLongituda_Leave(object sender, EventArgs e) // Klikom bilo gdje osim na textbox on vraća početni tekst ako je prazan
        {
            if (txtBoxLongituda.Text == "")
            {
                txtBoxLongituda.Text = "Longituda";

                txtBoxLongituda.ForeColor = Color.White;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // Klik na čeliju u tablici
        {
            
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
            {
            }
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(1) && e.RowIndex != -1)
            {
            }
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(2) && e.RowIndex != -1)
            {
            }
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(3) && e.RowIndex != -1)
            {
            }
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(4) && e.RowIndex != -1)
            {
            }
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1)
            {
                FormEditGrad FormEditGrad = new FormEditGrad(this);
                FormEditGrad.txtboxEditGradID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                FormEditGrad.txtBoxEditGrad_Naziv.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                FormEditGrad.txtBoxEditGrad_Latituda.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                FormEditGrad.txtBoxEditGrad_Longituda.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                FormEditGrad.comboBoxEditGrad_Drzava.DataSource = _comboboxBindingSource4;
                FormEditGrad.comboBoxEditGrad_Drzava.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                FormEditGrad.lblstariID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                FormEditGrad.ShowDialog();
            }
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(6) && e.RowIndex != -1)
            {
                DialogResult dialogResult = MessageBox.Show($"Jeste li sigurni da želite obrisati {dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()}", "Brisanje grada", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string odabranigrad = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=!!!;";
                    using (DbConnection oConnection = new SqlConnection(connectionString))
                    using (DbCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.CommandText = $"DELETE FROM [Stjepanovic_Gradovi] WHERE ( Grad_Id = '{odabranigrad}' )";
                        oConnection.Open();
                        using (DbDataReader reader = oCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                            }
                        }
                    }
                    using (DbConnection oConnection = new SqlConnection(connectionString))
                    using (DbCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.CommandText = $"DELETE FROM [Stjepanovic_MjerenjaTemp] WHERE ( Mjerenje_IdGrada = '{odabranigrad}')";
                        oConnection.Open();
                        using (DbDataReader oReader = oCommand.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                            }
                        }
                    }
                    OsvjeziPodatke();
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
        }

        private void comboBoxSortGradove2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSortGradove2.SelectedIndex != -1)
            {
                GradoviPoDrzavama2();
            }
        } // Sortiranje gradova po drzavama
        int brojaccmbsort = 0;
        private void comboBoxSortGradove_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSortGradove.SelectedIndex != -1)
            {
                brojaccmbsort += 1;
                if (brojaccmbsort != 1)
                {
                    GradoviPoDrzavama();
                    lblGrad.Show();
                    comboBoxGradovi.Show();
                }
            }
        } // Promjena indeksa na combobxu

        private void comboBoxGradovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSortGradove.SelectedIndex != -1 && comboBoxGradovi.SelectedIndex != -1)
            {
                pametnavarijablastupanj = "K";
                var odabranigrad = Convert.ToInt32(comboBoxGradovi.SelectedValue.ToString());
                string lat, lng;
                string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=!!!";
                using (DbConnection oConnection = new SqlConnection(connectionString))
                using (DbCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandText = $"SELECT Grad_Id,Grad_Lat,Grad_Lng FROM [Stjepanovic_Gradovi] WHERE ( Grad_Id = '{odabranigrad}' )";
                    oConnection.Open();
                    using (DbDataReader reader = oCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lat = (string)reader["Grad_Lat"];
                            lng = (string)reader["Grad_Lng"];
                            lblTemperatura.Text = $"{DajTemperaturu(odabranigrad, lat, lng)}°K";
                            lblTemperatura.Text = lblTemperatura.Text.Replace("K", "").Replace("°", "");
                            var temperatura = Convert.ToDecimal(lblTemperatura.Text.Replace(".", ","));
                            temperatura = temperatura - Convert.ToDecimal(273.15);
                            lblTemperatura.Text = temperatura.ToString().Replace(",", ".") + "°C";
                            pametnavarijablastupanj = "C";
                            _tableBindingSource2.DataSource = _mjerenjaRepository.dajPovijestMjerenja(odabranigrad);
                            btnFarad.Show();
                            btnCelzij.Show();
                            btnKelvin.Show();
                            dataGridViewPovijest.Show();
                            lblTemperatura.Show();
                        }
                    }
                }
            }
        } // Promjena indeksa na combobxu
        private void metroTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl.SelectedIndex == 3)
            {
                if (clickedornot == false)
                {
                    MessageBox.Show("Izmjerene temperature na karti ne ulaze u prosjek dosadašnjih izmjerenih temperatura.");
                }
                clickedornot = true;
            }
            if (metroTabControl.SelectedIndex == 4)
            {
                int brojacizmjerenih = 0;
                double ukupnoizmjerene = 0;
                var _svigradovi = _gradRepository.getGradovi();
                var _izmjerenetemperature = PovijestMjerenjaa();
                for (int i = 0; i < _izmjerenetemperature.Count(); i = i + 1)
                {
                    brojacizmjerenih = brojacizmjerenih + 1;
                    ukupnoizmjerene = ukupnoizmjerene + Convert.ToDouble(_izmjerenetemperature[i].sMjerenje_Iznos.Replace(".", ","));
                }
                _izmjerenetemperature = _izmjerenetemperature.OrderBy(x => x.sMjerenje_Iznos).ToList();
                double max = Convert.ToDouble(_izmjerenetemperature[_izmjerenetemperature.Count()-1].sMjerenje_Iznos.Replace(".", ","));
                double min= Convert.ToDouble(_izmjerenetemperature[0].sMjerenje_Iznos.Replace(".", ","));
                lblMaxTempValue.Text = Convert.ToString(max - 273.15) + " °C";
                lblMinTempValue.Text = Convert.ToString(min - 273.15) + " °C";
                lblAvgTempValue.Text = ((ukupnoizmjerene / brojacizmjerenih) - 273.15).ToString("0.00") + " °C";
                lblTotalMjerenja.Text = Convert.ToString(_izmjerenetemperature.Count());
            }
        } // Promjena indeksa na combobxu
        private void lblMaxTempValue_Click(object sender, EventArgs e)
        {
            var maxtempval = lblMaxTempValue.Text.Remove(lblMaxTempValue.Text.Length - 3);
            var _svigradovi = _gradRepository.getGradovi();
            var _izmjerenetemperature = PovijestMjerenjaa();
            string poruka = "";
            for (int i = 0; i < _izmjerenetemperature.Count(); i = i + 1)
            {

                if (maxtempval == Convert.ToString(Convert.ToDouble(_izmjerenetemperature[i].sMjerenje_Iznos.Replace(".", ",")) - 273.15))
                {
                    string imegrada = "";
                    for (int j = 0; j < _svigradovi.Count(); j++)
                    {
                        if (_izmjerenetemperature[i].nMjerenje_IdGrada == _svigradovi[j].nGrad_Id)
                        {
                            imegrada = _svigradovi[j].sGrad_Naziv;
                        }
                    }
                    poruka += $"Izmjerena temperatura: {lblMaxTempValue.Text}" + Environment.NewLine + $"Ime grada: {imegrada}" + Environment.NewLine + $"Datum mjerenja: {_izmjerenetemperature[i].sMjerenje_Datum}" + Environment.NewLine;
                }
            }
            MessageBox.Show(poruka);
        } // Klik na labelu i ispis svih gradova koji su imali tu najveću temperaturu
        private void lblMinTempValue_Click(object sender, EventArgs e)
        {
            var mintempval = lblMinTempValue.Text.Remove(lblMinTempValue.Text.Length - 3);
            var _svigradovi = _gradRepository.getGradovi();
            var _izmjerenetemperature = PovijestMjerenjaa();
            string poruka = "";
            for (int i=0;i<_izmjerenetemperature.Count();i=i+1)
            {

                if (mintempval == Convert.ToString(Convert.ToDouble(_izmjerenetemperature[i].sMjerenje_Iznos.Replace(".", ","))-273.15))
                {
                    string imegrada = "";
                    for (int j=0;j<_svigradovi.Count();j++)
                    {
                        if (_izmjerenetemperature[i].nMjerenje_IdGrada == _svigradovi[j].nGrad_Id)
                        {
                            imegrada = _svigradovi[j].sGrad_Naziv;
                        }
                    }
                    poruka += $"Izmjerena temperatura: {lblMinTempValue.Text}" + Environment.NewLine + $"Ime grada: {imegrada}" + Environment.NewLine + $"Datum mjerenja: {_izmjerenetemperature[i].sMjerenje_Datum}" + Environment.NewLine;
                }
            }
            MessageBox.Show(poruka);
        } // Klik na labelu i ispis svih gradova koji su imali tu najmanju temperaturu
        public List<Mjerenja> PovijestMjerenjaa()
        {
            List<Mjerenja> _povijesttmjerenja = new List<Mjerenja>();
            string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=!!!;";
            using (DbConnection oConnection = new SqlConnection(connectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())
            {
                oCommand.CommandText = $"SELECT * FROM [Stjepanovic_MjerenjaTemp]";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        _povijesttmjerenja.Add(new Mjerenja()
                        {
                            nMjerenje_Id = (int)oReader["Mjerenje_Id"],
                            sMjerenje_Iznos = (string)oReader["Mjerenje_Iznos"],
                            nMjerenje_IdGrada = (int)oReader["Mjerenje_IdGrada"],
                            sMjerenje_Datum = (string)oReader["Mjerenje_Datum"]
                        });
                    }
                }
            }
            _povijesttmjerenja.Reverse();
            return _povijesttmjerenja;
        } // Dohvaćanje povijesti mjerenja iz baze
        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=" + url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        } // Služi za učitavanje JSON-a sa APIja

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Aplikacija je izrađena u svrhu ocjenjivanja iz kolegija Programiranje u .NET okolini." + Environment.NewLine +
                "Kartica 'Gradovi' služi za prikaz svih gradova i dodavanje novih" + Environment.NewLine +
                "Kartica 'Mjerenja' služi za mjerenje i prikaz dosadašnjih izmjerenih temperatura" + Environment.NewLine +
                "Kartica 'Grafikon' služi za prikaz usporedbe gradova" + Environment.NewLine +
                "Kartica 'Karta' služi za prikaz prosječne temperature u državama" + Environment.NewLine +
                "Kartica 'O aplikaciji' služi za prikaz imena autora aplikacije");
        } // Klik na upitnik
        public bool ProvjeraGrafikon()
        {
            bool klik = true;
            if ((dateTimePicker1.Value.Date - dateTimePicker2.Value.Date).Days == 0)
            {
                MessageBox.Show("Datum za prikaz mjerenja je postavljen na isti dan!");
                klik = false;
            }
            if ((dateTimePicker1.Value.Date - dateTimePicker2.Value.Date).Days > 0)
            {
                MessageBox.Show("Datum za početak mjerenja je postavljen ranije od datuma za kraj mjerenja!");
                klik = false;
            }
            if (checkedListBoxGradovi.CheckedItems.Count == 0 || checkedListBoxGradovi.CheckedItems.Count == 1)
            {
                MessageBox.Show("Trebate odabrati najmanje 2 grada");
                klik = false;
            }
                return klik;
        } // Provjera za grafikon
        public LiveCharts.WinForms.CartesianChart cartesianChart1 = new LiveCharts.WinForms.CartesianChart(); // Kreiranje kartezijevog grafa
        private void button2_Click_1(object sender, EventArgs e) // Klik na prikaži u kartici 'Grafikon'
        {
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Clear();
            lblProsjek.Text = "------------";
            lblMinTemp.Text = "------------";
            lblMaxTemp.Text = "------------";
            if (ProvjeraGrafikon() == true)
            {
                List<String> _odabranigradovi = new List<String>();
                for (int x = 0; x < checkedListBoxGradovi.CheckedItems.Count; x++)
                {
                     _odabranigradovi.Add(checkedListBoxGradovi.CheckedItems[x].ToString());
                }
                var _svigradovi = _gradRepository.getGradovi();
                _svigradovi.RemoveAll(a => !_odabranigradovi.Exists(b => a.sGrad_Naziv == b));
                var _izmjerenetemperature = PovijestMjerenjaa();
                _izmjerenetemperature = _izmjerenetemperature.Where(x => DateTime.Parse(x.sMjerenje_Datum) >= dateTimePicker1.Value.Date && DateTime.Parse(x.sMjerenje_Datum) < dateTimePicker2.Value.Date).ToList();
                _izmjerenetemperature.RemoveAll(a => !_svigradovi.Exists(b => b.nGrad_Id == a.nMjerenje_IdGrada));
                double mjerenje = 0;
                double min = 0;
                double max = 0;
                int brojac = 0;
                bool prviput = true;
                for (int i = 0; i < _svigradovi.Count(); i++)
                {
                    for (int j = 0; j < _izmjerenetemperature.Count(); j++)
                    {
                        if (_svigradovi[i].nGrad_Id == _izmjerenetemperature[j].nMjerenje_IdGrada)
                        {
                            if (prviput == true)
                            {
                                min = Convert.ToDouble(_izmjerenetemperature[j].sMjerenje_Iznos.Replace(".", ","));
                            }
                            if (prviput == true)
                            {
                                max = Convert.ToDouble(_izmjerenetemperature[j].sMjerenje_Iznos.Replace(".", ","));
                            }
                            prviput = false;
                            if (min > Convert.ToDouble(_izmjerenetemperature[j].sMjerenje_Iznos.Replace(".", ",")))
                            {
                                min = Convert.ToDouble(_izmjerenetemperature[j].sMjerenje_Iznos.Replace(".", ","));
                            }
                            if (max < Convert.ToDouble(_izmjerenetemperature[j].sMjerenje_Iznos.Replace(".", ",")))
                            {
                                max = Convert.ToDouble(_izmjerenetemperature[j].sMjerenje_Iznos.Replace(".", ","));
                            }
                            mjerenje = mjerenje + Convert.ToDouble(_izmjerenetemperature[j].sMjerenje_Iznos.Replace(".", ","));
                            brojac = brojac + 1;
                        }
                    }
                }
                if (brojac == 0)
                {
                    MessageBox.Show("Ne postoje mjerenja za odabrano vrijeme");
                    panel2.Hide();
                }
                else
                {
                    panel2.Show();
                    lblProsjek.Text = Convert.ToString(((mjerenje / brojac) - 273.15).ToString("0.00")).Replace(",", ".") + "°C";
                    lblMinTemp.Text = Convert.ToString((min-273.15).ToString("0.00")).Replace(",", ".") + "°C";
                    lblMaxTemp.Text = Convert.ToString((max - 273.15).ToString("0.00")).Replace(",", ".") + "°C";
                    DateTime pocetak = dateTimePicker1.Value.Date;
                    DateTime kraj = dateTimePicker2.Value.Date;
                    TimeSpan sredina = kraj.Subtract(pocetak);
                    DateTime srednjevrijeme = pocetak.AddMinutes(sredina.TotalMinutes / 2);
                    TimeSpan dc = srednjevrijeme.Subtract(pocetak);
                    DateTime drugacetvrtina = pocetak.AddMinutes(dc.TotalMinutes / 2);
                    TimeSpan tc = kraj.Subtract(srednjevrijeme);
                    DateTime trecacetvrtina = srednjevrijeme.AddMinutes(tc.TotalMinutes / 2);
                    panel2.Controls.Add(cartesianChart1);
                    cartesianChart1.Dock = DockStyle.Fill;
                    _izmjerenetemperature.Reverse();
                    var dayConfig = Mappers.Xy<DateModel>()
                                         .X(dateModel => (dateModel.DateTime-pocetak).TotalDays)
                                         .Y(dateModel => dateModel.Value);
                    for (int i = 0; i < _svigradovi.Count; i++)
                    {
                        cartesianChart1.Series.Add(new LineSeries(dayConfig)
                        {
                            Title = _svigradovi[i].sGrad_Naziv,
                            Values = new ChartValues<DateModel>
                            {
                            }
                        });
                        for (int j = 0; j < _izmjerenetemperature.Count; j++)
                        {
                            if (_izmjerenetemperature[j].nMjerenje_IdGrada == _svigradovi[i].nGrad_Id)
                            {
                                double pretvoriucelzij = Convert.ToDouble(_izmjerenetemperature[j].sMjerenje_Iznos.Replace(".", ",")) - 273.15;
                                cartesianChart1.Series[i].Values.Add(new DateModel(Convert.ToDouble(pretvoriucelzij.ToString("00.00")),DateTime.Parse(_izmjerenetemperature[j].sMjerenje_Datum)));
                            }
                        }
                    }
                    cartesianChart1.AxisX.Add(new Axis
                    {
                        Title = "Datum",
                        MinValue = 0,
                        MaxValue = (kraj - pocetak).TotalDays,
                        LabelFormatter = value => pocetak.Date.AddDays(value).ToString()
                    });
                    cartesianChart1.AxisY.Add(new Axis
                    {
                        Title = "Temperatura",
                        LabelFormatter = x => x + " °C"
                    });
                    cartesianChart1.Zoom = ZoomingOptions.X;
                    cartesianChart1.DefaultLegend.Foreground = System.Windows.Media.Brushes.White;
                    cartesianChart1.LegendLocation = LegendLocation.Right;
                }
            }
        }
        private void btnSearchFilter_Click(object sender, EventArgs e)
        {
            var _gradovifilter = getGradoviii();
            if (string.IsNullOrEmpty(textBoxFilter.Text) == false)
            {
                var gradovifilter = _gradovifilter.Where(x => x.sGrad_Naziv.ToLower().Contains(textBoxFilter.Text.ToLower())).ToList();
                if (gradovifilter.Count > 0)
                {
                    dataGridView1.DataSource = null;
                    _tableBindingSource1.DataSource = gradovifilter;
                    dataGridView1.DataSource = _tableBindingSource1;
                }
                else
                {
                    MessageBox.Show("Ne postoji grad koji sadrži unutar imena uneseni tekst");
                }
            }
            else
            { 
                dataGridView1.DataSource = null;
                _tableBindingSource1.DataSource = getGradoviii();
                dataGridView1.DataSource = _tableBindingSource1;
            }
        } // Klik na pretragu

        private void btnLatLng_Click(object sender, EventArgs e)
        {
            FormLatLng FormaLatLng = new FormLatLng();
            FormaLatLng.ShowDialog();
        }
    }
}
