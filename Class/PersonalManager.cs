using System.Text.Json;

namespace HRManager.Class
{
    internal class PersonalManager : User
    {
        //
        private Dictionary<string, List<Dictionary<string, string>>> _alleBenutzer;
        public PersonalManager(string userRolle, string benutzerName, string domainName, string password) : base("personalmanager", benutzerName, domainName, password)
        {
            _alleBenutzer = base.LadenUserJs(); // gewährt zugriff auf das Dict _alleBenutzer base. nachträglcih eingefügt !
        }


        public override void Anmelden(string userRolle, string benutzerName, string domainName, string password)
        {
            Console.WriteLine(@$"
                Anmeldung erfolgreich.
                Willkommen Personalmanager {benutzerName} @{domainName}.
                Du hast Zugriff auf die Mitarbeiterliste.");
        }

        // Abgeänderte Methode für BenutzerSuchen  damit nur für "verkauf" und "IT" angezeigt werdne können

        public void ZeigeMitarbeiterListe(Dictionary<string, List<Dictionary<string, string>>> benutzerDaten)
        {
            Console.WriteLine("Mitarbeiterliste (aus IT und Verkauf):");

            foreach (var rolle in new[] { "it", "verkauf" })
            {
                if (_alleBenutzer.ContainsKey(rolle))
                {
                    Console.WriteLine(@$"
                                            Abteilung: {rolle.ToUpper()}");
                    foreach (var mitarbeiter in _alleBenutzer[rolle])
                    {
                        Console.WriteLine(@$"- Benutzername: {mitarbeiter["benutzerName"]}, Domain: @{mitarbeiter["domainName"]}");
                    }
                }
            }
        }
        public Dictionary<string, string>? BenutzerSuchen(string benutzerName, string domainName)
        {
            foreach (var rolle in new[] { "it", "verkauf" })
            {
                if (_alleBenutzer.ContainsKey(rolle))
                {
                    foreach (var benutzer in _alleBenutzer[rolle])
                    {
                        if (benutzer["benutzerName"].Equals(benutzerName, StringComparison.OrdinalIgnoreCase) &&
                            benutzer["domainName"].Equals(domainName, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("User already exists: Achtung, der Benutzer existiert bereits!");
                            return benutzer;
                        }
                    }
                }
            }
            return null;
        }
    }

}

