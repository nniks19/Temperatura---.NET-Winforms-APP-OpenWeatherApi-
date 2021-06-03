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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Grad
    {
        public int nGrad_Id { get; set; }
        public string sGrad_Naziv { get; set; }
        public string sGrad_Lat { get; set; }
        public string sGrad_Lng { get; set; }
        public string sGrad_Drzava { get; set; }
    }
}
