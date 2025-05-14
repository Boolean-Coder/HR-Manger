using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Class
{
    internal class PersonalManager : User
    {
        public PersonalManager(string benutzerName, string domainName, string password) : base(benutzerName, domainName, password)
        {

        }
        public void MitarbeiterVerwalten( ) { Console.WriteLine("Ich Verwalte Menschen der IT-Abteilung und Verkaufsabteilung"); } // Wird später evtl noch weitergeführt
    }
}
