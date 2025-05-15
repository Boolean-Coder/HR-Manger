using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Class
{
    internal class ITBereich : User
    {
        public ITBereich(string userRolle, string benutzerName, string domainName, string password) : base("it", benutzerName, domainName, password) { }  // Erbt die base von User Klass

        public void ITzeugs() { Console.WriteLine("Ich mache IT ZEUGS"); } // Ich hoffe ich hab später genug zeit

        public override void Anmelden(string userRolle, string benutzerName, string domainName, string password)
        {
            Console.WriteLine(@$"
            Anmeldung erfolgreich.
            Willkommen ITler {benutzerName} @{domainName}.
            Du hast aktuell auf keinen Zugriff.");
        }
    }
}
