using System.Text.Json;
namespace HRManager.Class   
{
    abstract internal class User
    {
        // weil der compiler von oben nach unten arbeitet und wir falls user vorhanden sind  zuvor natprlciha brufen müssen zur kontrolle sind diese zeilen nun über die Felder 
        private static readonly string UserJSpfad = @"User.json";
        private static readonly JsonSerializerOptions jsOptions = new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true };

        protected string BenutzerName { get; private set; }
        protected string DomainName { get; private set; }

        protected string Rolle { get; private set; }
        protected string Password { get; private set; }

        /*         private string _passwordVerschlüsselung; 
         *         vorerst gelassen wegen Aes Encryption !!!
         *         Mit dem Aktuellen stand schwer ich kann das höchstens in eine JSON seriallisieren auch das ist noch schwer
         *         aber ich habe vorerfarhung durhc die Wetter app die ich mit Andrei geschrieben hatte 
         *         Das schau ich mir genau erst am Wochenende an! 
        */
        // Konstruktor
        protected User(string benutzerName, string domainName, string userRolle, string password)
        {
            BenutzerName = benutzerName;
            DomainName = domainName;
            Password = password;
            Rolle = userRolle;
            /* Verschlüsselungs Methode - auf Eis gelegt
             * Password = PasswordVerschlüsseln(password);*/
        }

        public abstract void Anmelden(string userRolle, string benutzerName, string domainName, string password);

        public void BenutzerdatenEinfügen(Dictionary<string, List<Dictionary<string, string>>> zielDict)  // MEthode um sie in der Admin klasse aufzurufen
        {
            if (!zielDict.ContainsKey(Rolle))
            {
                zielDict[Rolle] = new List<Dictionary<string, string>>();
            }
            //  Meine Struktur die später in eine Json gespeichert werden kann !
            var zielDictEintrag = new Dictionary<string, string>
            {
                ["benutzerName"] = BenutzerName,
                ["domainName"] = DomainName,
                ["rolle"] = Rolle,
                ["password"] = Password
            };
            zielDict[Rolle].Add(zielDictEintrag);
        }
        /* Methode um JSON datei in ein  Verschachteltes Dictionary zu casten
         * Grund dadurch spar ich mir viele COdezeilen und Kopfschmerz und MEthoden
         * hatten wir angesprochen der Retunr ückgabewert auch ist im Prinzip nichts anderes
         * Methoden definierungsort auf USer verschoben  DAMIT ALLE Klassen einfach auf  die JSON zugreifen könenn !
         * Hätte ich das gleich so am anfagn gemacht hätte ich zeit gesparrt*/
        protected internal Dictionary<string, List<Dictionary<string, string>>> LadenUserJs()  // Internal damit ich die MEthode Auhc in der Main Methode der Program.cs nutzen kann 
        {
            /*  ACHTUNG BUG :
             *  Das ist eine lokale Varable in meiner Methode  biem ausführen hat diese die original Globale datei des "UserJsPfad" ÜBERSCHRIEBEN deshalb kam es zu fehlern 
             *  string UserJsPfad = "User.json"; // Pfad zur JSON-Datei*/
            JsonSerializerOptions jsOptions = new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true };

            if (!File.Exists(UserJsPfad))
            {
                return new Dictionary<string, List<Dictionary<string, string>>>(StringComparer.OrdinalIgnoreCase);
            }

            var json = File.ReadAllText(UserJsPfad);

            return JsonSerializer.Deserialize<Dictionary<string, List<Dictionary<string, string>>>>(json, jsOptions)
                   ?? new Dictionary<string, List<Dictionary<string, string>>>(StringComparer.OrdinalIgnoreCase);
        }
        protected void SpeichereBenutzerDaten(Dictionary<string, List<Dictionary<string, string>>> benutzerDaten)
        {
            string json = JsonSerializer.Serialize(benutzerDaten,jsOptions);
            File.WriteAllText(UserJSpfad, json); // Speichert json in dem Pfad USerJSPfad
        }

        /* UM daten von der Main Methode abrufbar zu machenmüssen in der ELternklasse dafür  Methoden angelegt werden
         * 
         * public string GetBenutzerName() => BenutzerName;
           public string GetDomainName() => DomainName;
           public string GetRolle() => Rolle;
           public string GetPassword() => Password;
            
        ganz ehrlcih das musste ich mir asu dem Internet holen da haben wir viel zu wenig im unterricht gemacht  um effektiv get und set verwenden zu können

         */
        public string GetBenutzerName() => BenutzerName;
        public string GetDomainName() => DomainName;
        public string GetRolle() => Rolle;
        public string GetPassword() => Password;

    }
}

