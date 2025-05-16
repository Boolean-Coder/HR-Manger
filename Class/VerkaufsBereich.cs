namespace HRManager.Class
{
    internal class VerkaufsBereich: User
    {
        public VerkaufsBereich(string userRolle, string benutzerName, string domainName, string password) : base("verkauf", benutzerName, domainName, password) { }// Erbt die base von User Klasse

        // Anmelden override  der abstract Klasse Anmelden Da Sich jede KLasse anmelden muss ist diese mein Grund für das Erstellen einer abstract Methode die der User Class angehört ALLE Klassend er USer Klass MÜSSEN diese Funktion haben
        public void Verkaufen() { Console.WriteLine("Ich Verkaufe Dinge"); } // Wird später evtl noch weitergeführt
        public override void Anmelden(string userRolle, string benutzerName, string domainName, string password)
        {
            Console.WriteLine(@$"
            Anmeldung erfolgreich.
            Willkommen Verkäufer: {benutzerName} @{domainName}.
            Du hast aktuell auf keinen Zugriff.");
        }
    }
}
