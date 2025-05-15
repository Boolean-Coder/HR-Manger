using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Class
{
    internal class PersonalManager : User
    {
        public PersonalManager(string userRolle, string benutzerName, string domainName, string password) : base("personalmanager", benutzerName, domainName, password) { }
        public override void Anmelden(string userRolle, string benutzerName, string domainName, string password)
        {
            Console.WriteLine(@$"
            Anmeldung erfolgreich.
            Willkommen Personalmanager {benutzerName} @{domainName}.
            Du hast Zugriff auf die Mitarbeiterliste .");
        }
        public void ZeigeMitarbeiterListe(Dictionary<string, List<Dictionary<string, string>>> benutzerDaten)
        {
            Console.WriteLine("Mitarbeiterliste (aus IT und Verkauf):");
            
            foreach(var rolle in new[] { "it", "verkauf" }) {
                if (benutzerDaten.ContainsKey(rolle)) {
                    Console.WriteLine(@$"
                                        Abteilung: {rolle.ToUpper()}");
                    foreach(var mitarbeiter in benutzerDaten[rolle])
                    {
                        Console.WriteLine(@$"- Benutzername: {mitarbeiter["benutzerName"]}, Domain: @{mitarbeiter["domainName"]}");
                    }
                }
            }
        }

    }
}
