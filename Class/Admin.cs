﻿using System.Text.Json;
namespace HRManager.Class
{
    internal class Admin: User
    {
        /* UserInfo enthält den Dateipfad von der User.json
           HARDCODE WEG
           private static readonly string UserJsPfad = @"**\%UserProfile%\source\repos\HRManager\HRManager\bin\Debug\net9.0\User.json\";
           Für spezifische dateipfade welche immer gleich bleiben sollen !!!
           Achtung die "User.json" MUSS später in den Release Ordner
         
        
           Der Variable Weg: 
           private static readonly string UserJsPfad=@"User.json";
           
           WAS ICH aus einem Youtube Short gelernt hab:
           Der Variable Weg um den Pfad anzugeben falls sich die datei in der Seleben OrdnerStruktur befindet !!
           also glecihe POrojektmappe dort wo standartmäßig alle Alle .json dateien aufbewahrt werden   */
        private static readonly string UserJsPfad = @"User.json";
        
        /*  JSON readonly als KlassenFeld 
         *  JASON JsonSerialize options ebim Serriallisierne und deseriallisieren 
         *  müssen glecih sein im Aktuellen Code wurden sie bei jeder insanz neugesetzt das war dumm,
         *  nach tieferer überlegung und einer guten Auszeit habe ich gemerkt das es intelligenter und schneller sowie ressourcensparender, sauberer
         *  werde wenn ich die JasonSeriallizeOptions einfach in eine Varible Zuweise und dann immer dammit aufrufe
          
            private static readonly JsonSerializerOptions jsOptions = new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true };  */
        private static readonly JsonSerializerOptions jsOptions = new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true };

        /* Dictionary der als Schlüssen Rollen & eine Liste als wertpaar
         * die wiederumm die User Klasse beinhaltet!!!!!!
         * einfach nur die Bezeichnung  für verschachtelte dict auf private weil nur admin soll dazugreifen können 
           
           private Dictionary<string, List<Dictionary<string,string>>> _alleBenutzer;   */
        private Dictionary<string, List<Dictionary<string,string>>> _alleBenutzer;
         
        // Unser Konstruktor ich nenne  Ihn liebevoll Bob 
        public Admin(string userRolle,string benutzerName,string domainName,string password):base( "admin", benutzerName,domainName,password) 
        {
            _alleBenutzer = base.LadenUserJs();
        }
        // Alle Methoden der Admin Klasse
        public override void Anmelden(string userRolle, string benutzerName, string domainName, string password)
        {
            /* Ich habe die Anmelde Eingaben weider rausgelöscht und die
             * abstract anmelden Klasse abgeändert weil  hat wenig sinn gemacht 
             * das hat bereits der Konstruktor für mcih erledigt meine klasse erbt hier 
             * ja von User methode weiter ausführen und dnUR EINMAL  da ist ja auch der SInn
             * dahinter so verhindere ich redundanz !!  */
            Console.WriteLine(@$"
                Anmeldeprozess durchgeführt
                Du bist der ÜBER Admin Alle Niederen Klassen unterstehen dir....
                Wir reden hier natürlich nur von Klassen im Sinne von OOP^^
                Dein Name {BenutzerName} wird gefürchtet\n Deine Domäne ist: @{DomainName} ");
        }

        // BenutzerSuchen
        private Dictionary<string,string>? BenutzerSuchen(string userRolle, string benutzerName, string domainName)
        {
            if ( _alleBenutzer == null || !_alleBenutzer.ContainsKey(userRolle)) { 
                Console.WriteLine("User not Found Error: Solch ein Benutzer existiert nicht"); 
                return null;
            }
            foreach(var benutzer in _alleBenutzer[userRolle]) { 
                if(benutzer.ContainsKey("benutzerName")&& benutzer.ContainsKey("domainName")){
                    if (benutzer["benutzerName"].Equals(benutzerName,StringComparison.OrdinalIgnoreCase) &&  // Vergleich ob der benutzername  der angegeben wurde übereinstimmt mit dem benutzterNamen  das  2. Methoden aufruf Argument der Equals(,StringComparison.OrdinalIgnoreCase) Methode StringComparison.OrdinalIgnoreCase sorgt dafür das nicht Case Sensitive nachd em Namen gesucht wird nach dem Wert der dem schlüssel zugewiesen wurde
                        benutzer["domainName"].Equals(domainName,StringComparison.OrdinalIgnoreCase)) {       // Vergleich ob der domainnName der angegeben wurde übereinstimmt mit dem benutzterNamen
                         
                        Console.WriteLine("User already Exists: Achtung der Benutzter Existiert bereits!");
                        return benutzer;    // Hier wird nicht nur der benutzer retunred sondern im Format des Dictionarys
                    }
                }
            }
            Console.WriteLine("User not Found Error: Solch ein Benutzer existiert nicht"); 
            return null;
        }
        public void BenutzerErstellen(string userRolle, string benutzerName, string domainName, string password) {

            string[] erlaubteRollen = { "verkauf", "it", "personalmanager", "admin" };
            /* Rollen Chek über einem String[] aus erlaubtenRollen 
             * ist der Wert der  userRolle.ToLower != nicht in mindestens einem der werte, der indexfelder aus dem string[] erlaubteRollen so
             * wird die ausgabe "User Rolle Error: So eine Rolle ist nicht zu vergeben!" erscheinen
             * Neuer Zusatz von am Tag 4 */
            if (!erlaubteRollen.Contains(userRolle.ToLower())) {
                Console.WriteLine("User Rolle Error: So eine Rolle ist nicht zu vergeben!");
                return;
            }

            var checkBenutzer = BenutzerSuchen(userRolle, benutzerName, domainName);  
            if (checkBenutzer != null) {
                Console.WriteLine("User Erstellen Error: Benutzter Existiert Bereits.");
                return;  // Bricht die schleife bzw den Codeblock ab Falls der User bereits in der json auffindbar ist 
            }
            User neuerUser; // damit  neuerUser den Datentyp "User" erhält  je nach Rolle wird dann  ein Konstruktor der jeweiligen Klasse genutzt da ich die User klasse als abstracte definiert habe geht das !!
            switch (userRolle.ToLower()){

                case "verkauf":
                    neuerUser = new VerkaufsBereich(userRolle, benutzerName, domainName, password);  // über die in den klassen definieren Konstruktoren werden  dann neue Objekte mit dem variablenNamen neuerUser vergeben
                    break;
                case "it":
                    neuerUser = new ITBereich(userRolle, benutzerName, domainName, password);
                    break;
                case "personalmanager":
                    neuerUser = new PersonalManager(userRolle, benutzerName, domainName, password);
                    break;
                case "admin":
                    neuerUser = new Admin(userRolle, benutzerName, domainName, password);
                    break;
                default:
                    Console.WriteLine("User Rolle Error: So eine Rolle ist nicht zu vergeben!");
                    return;
            }
            neuerUser?.BenutzerdatenEinfügen(_alleBenutzer);  // Neuer Dude wird in die Liste geaddet wird aktuell einfach an die letzte Position des Index Feldes angefügt 
            SpeichereBenutzer();
            Console.WriteLine("Benutzer wurde erfolgreich erstellt.");
        }
        private void SpeichereBenutzer() {
            base.SpeichereBenutzerDaten(_alleBenutzer);               // Das Richtige einsetzten von base.Methodex (Wert  x) spart mehr zeit !!! aber ich hätte mehr Unterrichtszeit gebraucht um das vollends zu meistern
        }
        /*  UserBearbeiten MEthode wird weggelassen
         *  public void UserBearbeiten(string userRolle, string benutzerName, string domainName, string password) {}   
        */
        public void BenutzerLöschen(string userRolle, string benutzerName, string domainName, string password) {
            
            Console.Write("Geben sie den Benutzernamen  des zu löschenden Benutzters an: ");
            benutzerName = Console.ReadLine() ?? "Leere Eingabe";

            Console.Write("Geben sie den Domainnamen  des zu löschenden Benutzters an: ");
            domainName = Console.ReadLine()?? "Leere Eingabe";

            Console.Write("Geben sie die Abteilung  des zu löschenden Benutzters an: ");
            userRolle = Console.ReadLine() ?? "Leere Eingabe";

            Console.Write("Geben sie das Password  des zu löschenden Benutzters an: ");
            password = Console.ReadLine() ?? "Leere Eingabe";


            // Prüfen ob Benutzer existiert über die Methode benutzer suchen
            var benutzer = BenutzerSuchen(userRolle, benutzerName, domainName);
            if (benutzer != null && _alleBenutzer[userRolle].Remove(benutzer)) {
                Console.WriteLine("Benutzer erfolgreich gelöscht");
                // User.json wird Aktualisiert
                SpeichereBenutzer();
            }
            else { Console.WriteLine("Fehler Beim löschen des Benutzers... Haben sie Keine \"User.json\" ?"); }

        }

    }
}
