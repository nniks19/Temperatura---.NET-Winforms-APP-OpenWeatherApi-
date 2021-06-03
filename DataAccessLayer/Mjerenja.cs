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
    public class Mjerenja
    {
        public int nMjerenje_Id { get; set; }
        public string sMjerenje_Iznos { get; set; }
        public int nMjerenje_IdGrada { get; set; }
        public string sMjerenje_Datum { get; set; }
    }
}
