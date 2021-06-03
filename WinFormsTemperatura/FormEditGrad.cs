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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace WinFormsTemperatura
{
    public partial class FormEditGrad : Form
    {
        DrzavaRepository _drzavarepository = new DrzavaRepository();
        GradRepository _gradrepository = new GradRepository();
        Temperatura form;
        public FormEditGrad(Temperatura f)
        {
            InitializeComponent();
            form = f;
        }
        public string NadiDrzavu(string drzava)
        {
            var _imenadrzava = _drzavarepository.getDrzave();
            string oznakadrzave = "";
            for (int i = 0; i < _imenadrzava.Count(); i++)
            {
                if (drzava == _imenadrzava[i].sImeDrzave)
                {
                    oznakadrzave = _imenadrzava[i].sOznakaDrzave;
                }
            }
            return oznakadrzave;
        }
        private void btnUredi_Click(object sender, EventArgs e)
        {
            if (ProvjeraSvih() == true)
            {
                string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=!!!;";
                using (DbConnection oConnection = new SqlConnection(connectionString))
                using (DbCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandText = "UPDATE Stjepanovic_Gradovi SET Grad_Id = '" + txtboxEditGradID.Text + "', Grad_Naziv = '" + txtBoxEditGrad_Naziv.Text + "', Grad_Lat = '" + txtBoxEditGrad_Latituda.Text + "', Grad_Lng = '" + txtBoxEditGrad_Longituda.Text + "', Grad_Drzava = '" + NadiDrzavu(comboBoxEditGrad_Drzava.SelectedItem.ToString()) + "' WHERE Grad_Id = " + lblstariID.Text;
                    oConnection.Open();
                    using (DbDataReader reader = oCommand.ExecuteReader())
                    {
                    }
                }
                MessageBox.Show($"{txtBoxEditGrad_Naziv.Text} je uspješno uređen!");
                form.OsvjeziPodatke();
                Close();
            }
            else
            {
                ProvjeraZasebno();
            }
        }
        public bool ProvjeraPostojecegID(int idgrada)
        {
            var _gradovii = _gradrepository.dajGradove();
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
        public void ProvjeraZasebno()
        {
            if (!String.IsNullOrEmpty(txtboxEditGradID.Text) == true)
            {
                if (IsDigitsOnly(txtboxEditGradID.Text) == true && ProvjeraPostojecegID(Convert.ToInt32(txtboxEditGradID.Text)) == true && lblstariID.Text != txtboxEditGradID.Text)
                {
                    MessageBox.Show("Uneseni ID grada već postoji u bazi podataka!");
                }
            }
            if (IsDigitsOnly(txtboxEditGradID.Text) == false)
            {
                MessageBox.Show("Uneseni ID grada nije broj!");
            }
            if (String.IsNullOrEmpty(txtboxEditGradID.Text) == true)
            {
                MessageBox.Show("Obavezan je unos ID grada!");
            }
            if (String.IsNullOrEmpty(txtBoxEditGrad_Naziv.Text) == true)
            {
                MessageBox.Show("Obavezan je unos naziva grada!");
            }
            if (String.IsNullOrEmpty(txtBoxEditGrad_Latituda.Text) == true)
            {
                MessageBox.Show("Obavezan je unos latitude grada!");
            }
            else
            {
                if (IsDigitsOnlyLatitudaLongituda(txtBoxEditGrad_Latituda.Text, 0) == false)
                {
                    MessageBox.Show("Latituda nije u dobrom formatu ili  nije u rasponu od -90 do 90!");
                }
            }
            if (String.IsNullOrEmpty(txtBoxEditGrad_Longituda.Text))
            {
                MessageBox.Show("Obavezan je unos longitude grada!");
            }
            else
            {
                if (IsDigitsOnlyLatitudaLongituda(txtBoxEditGrad_Longituda.Text, 1) == false)
                {
                    MessageBox.Show("Longituda nije u dobrom formatu ili  nije u rasponu od -180 do 180");
                }
            }
        }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        bool IsDigitsOnlyLatitudaLongituda(string str, int deg)
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
        public bool ProvjeraSvih()
        {
            bool provjera = true;
            if (String.IsNullOrEmpty(txtboxEditGradID.Text) == true || String.IsNullOrEmpty(txtBoxEditGrad_Naziv.Text) == true || String.IsNullOrEmpty(txtBoxEditGrad_Latituda.Text) == true || String.IsNullOrEmpty(txtBoxEditGrad_Longituda.Text) == true || IsDigitsOnly(txtboxEditGradID.Text) == false)
            {
                provjera = false;
            }
            if (!String.IsNullOrEmpty(txtboxEditGradID.Text) == true)
            {
                if (IsDigitsOnly(txtboxEditGradID.Text) == true && ProvjeraPostojecegID(Convert.ToInt32(txtboxEditGradID.Text)) == true && lblstariID.Text != txtboxEditGradID.Text)
                {
                    provjera = false;
                }
            }
            else
            {
                provjera = false;
            }
            if (!String.IsNullOrEmpty(txtBoxEditGrad_Latituda.Text) == true)
            {
                if (IsDigitsOnlyLatitudaLongituda(txtBoxEditGrad_Latituda.Text, 0) == false)
                {
                    provjera = false;
                }
            }
            if (!String.IsNullOrEmpty(txtBoxEditGrad_Longituda.Text) == true)
            {
                if (IsDigitsOnlyLatitudaLongituda(txtBoxEditGrad_Longituda.Text, 1) == false)
                {
                    provjera = false;
                }
            }
            return provjera;
        }
    }
}
