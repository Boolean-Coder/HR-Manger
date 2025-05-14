using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Class
{
    internal class VerkaufsBereich: User
    {
        public VerkaufsBereich(string benutzerName, string domainName, string password) : base(benutzerName, domainName, password)  // Erbt die base von User Klasse
        {

        }
        public void Verkaufen() { Console.WriteLine("Ich Verkaufe Dinge"); } // Wird später evtl noch weitergeführt
    }
}
