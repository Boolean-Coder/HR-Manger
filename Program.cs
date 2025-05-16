using HRManager.Class;
using System.Dynamic;
namespace HRManager
{
    internal class Program
    {
        /* Globale Variablen
         *
         * das  private static Dictionary<string, List<Dictionary<string, string>>>_alleBenutzer=  new Dictionary<string, List<Dictionary<string, string>>>();
         * steht hier weil:
         * _alleBenutzer ein Dictionary ist und wir das global aufrufen müssen um damit arbeiten zu können  der speicherort der inhalte dieses Dictionars ist die "User.json"
         * und verwalten tun wir das in der entsprechenden klassse mit entpsrechenden methoden ums kurz zu halten ich muss ste nachträglich 
         * diese Werte hier fest deklarieren um sie ind er Main MEthode nutzen zu können       */
        static bool sysEx = false;
        static int fehlVersuche = 0;
        private static Dictionary<string, List<Dictionary<string, string>>> _alleBenutzer = new Dictionary<string, List<Dictionary<string, string>>>();
        private const string UserJsPfad = @"User.json"; // Konstante für den Dateipfad
        static void Main(string[] args)
        {
            LadenBenutzerDaten();

            // Main-Loop als Fußgesteuerte do-while
            do
            {

                Console.Clear();

                // Ladeanimation
                LadeBalken(1, 10);

                // Anmelde Methode
                User? benutzer = TerminalAnmeldung();

                if (benutzer != null) { BenutzerOberfläche(benutzer); }
                else
                {
                    Console.WriteLine(" Terminal Anmeldung fehlgeschlagen ");
                    fehlVersuche++;
                    if (fehlVersuche >= 3)
                    {
                        Console.WriteLine("ERROR: Zu viele Anmeldeversuche das Programm wird beendet");
                        sysEx = true;
                    }
                }

                // Methode: Programm-Beenden 
                sysEx = ProgrammExit();

            } while (!sysEx);
        }
        private static void LadeBalken(int startPunktDerIteration, int endPunktderIteration)
        {
            Console.Clear();

            for (int i = startPunktDerIteration; i < endPunktderIteration; i++)
            {

                if (i == startPunktDerIteration) Console.WriteLine("===={ Ladesequenz  }====\n");
                for (int j = 0; j < i; j++)
                {
                    Console.Write("|".PadRight(2));   // LadeAnimation !!! 
                    Thread.Sleep(50);
                }
                if (i == endPunktderIteration - 1) Console.WriteLine("\n\n===={ Ladesequenz beendet }====");
                Thread.Sleep(10);
            }
        }
        private static bool ProgrammExit()
        {
            Console.Write("Möchten sie das Programm beenden? (Ja/Nein)");
            sysEx = Console.ReadLine()?.Trim().ToLower() == "j";
            Environment.Exit(0);
            /* Neuere Cleanere und Kürzere Schreibweise!!!
             * Console.Write("Möchten sie das Programm beenden? (Ja/Nein)");
             * Durch drücken der J Taste wird dadurch diese Bedingung auf True gesetzt !
             * if (Console.ReadKey(true).Key == ConsoleKey.J) { Environment.Exit(0); }
             * Dann wird Enviroment.Exit(0) ausgeführt 
             * Exit(0) ist immer eine durchführung der Exit Funktion ohne Fehler
             * mit dem Code "0", Code "0" ist wie OK
             */
            return sysEx;
        }
        // Methode für Anzeige Logik 
        private static void BenutzerOberfläche(User benutzer) {
            Console.Clear();
            /*  Get MEthdoen 
                Greift auf die Eigenschaft des User-Objekts zu ich lasse die "()" hinter der 
                MEthode um zu verdeutlichen das es eine Methode ist die den Wert abruft*/
            Console.WriteLine($"Willkommen, {benutzer.GetBenutzerName()}!");

            // Anzeigen der Anmelden(); Methode je benutzer Klasse
            benutzer.Anmelden(benutzer.GetRolle(), benutzer.GetBenutzerName(), benutzer.GetDomainName(), benutzer.GetPassword());
            Console.WriteLine("Drücken Sie eine beliebige Taste, um zum Hauptmenü zurückzukehren.");
            Console.ReadKey();
        }
        // MEthoden BenutzernameLoginFenster Password LoginFenster BenutzterOberflächePasswordAnzeige etc alle auf eis gelegt wegen zeitdruck!!
        private static User? TerminalAnmeldung() // Gibt später einen User zurück
        {
            Console.Write("Benutzername:");
            string benutzerName = Console.ReadLine()?.Trim() ?? "";
            Console.Write("Domainname:");
            string domainName = Console.ReadLine()?.Trim() ?? "";
            Console.Write("Password:");
            string password = Console.ReadLine()?.Trim() ?? "";

            string rolle = DomainRolle(domainName); // je nach input des domainNamens wird die Domäne zugewiesen pder diese kleine Methode... xd  Merke die Komplette DOKU HÄTTE ICH AM WOCHENENDE MACHEN SOLLEN
            if (rolle == null) {
                Console.WriteLine("Es wurde keine gültige Rolle angegeben.");
                return null;
            }
            if (!_alleBenutzer.ContainsKey(rolle)) {
                Console.WriteLine("Falsche Anmeldedaten: Rolle nix da");
                return null;
            }
            User benutzer=null;
            /* Ich hatte ein Problem mit User benutzer */

            var benutzerListe = _alleBenutzer[rolle];
            foreach (var benutzerElement in benutzerListe) {
                if (benutzerElement["benutzerName"].Equals(benutzerName, StringComparison.OrdinalIgnoreCase) &&
                    benutzerElement["domainName"].Equals(domainName, StringComparison.OrdinalIgnoreCase) &&
                    benutzerElement["password"] == password)
                {
                    /* Die Switch für die Fallunterscheidung rolle 
                     * muss jetzt in die If abfrage der foreach zur kontrolle
                     */ 
                    switch (rolle) {

                        case "verkauf":
                            benutzer = new VerkaufsBereich(rolle, benutzerName, domainName, password);  // über die in den klassen definieren Konstruktoren werden  dann neue Objekte mit dem variablenNamen neuerUser vergeben
                            break;
                        case "it":
                            benutzer = new ITBereich(rolle, benutzerName, domainName, password);
                            break;
                        case "personalmanager":
                            benutzer = new PersonalManager(rolle, benutzerName, domainName, password);
                            break;
                        case "admin":
                            benutzer = new Admin(rolle, benutzerName, domainName, password);
                            break;
                        default:
                            Console.WriteLine("User Rolle Error: So eine Rolle ist nicht zu vergeben!");
                            return null;
                    }
                    if (benutzer != null) {
                        benutzer.Anmelden(rolle, benutzerName, domainName, password);
                        return benutzer;
                    }
                }
            }
            // Außerhalb der foreach!!!!   
            Console.WriteLine("Falsche Anmeldedaten.");
            return null;
        }
        /* Hier hab ich mich entschieden  keinen switch cae zu nutzen um leserlich 
         * UND zeitsparender UND effizienter zu werden hat vor und nachteile
         * aber ich habe keine zeit mehr um genau darüber nachzudenken 
         * ich hätte die Doku erst am Wochenende anfagnen sollen!!! und hier nur Kmmentare wie ich es sowieso schon gemacht habe 
         * das alles frisst zu viel zeit kalr liegt es auch an meiner Praktischen Erfahrung die = null ist xd hab extra null geschrieben  anstatt 0 =)  */
        private static string DomainRolle(string domainName)
        {
            domainName = domainName.ToLower();
            string rolle = "";
            if (domainName.Contains("admin")) { return "admin"; }
            if (domainName.Contains("verkauf")) { return "verkauf"; }
            if (domainName.Contains("it")) { return "it"; }
            if (domainName.Contains("manager")) { return "manager"; }
            return null;

        }
        
        /* genereieren einer temp Admin instanz
         * NUR fürs updaten der json damit ich in der
         * Main drauf zugreifen kann  Später Mcihael Fragen 
         * sit das so überhaupt nötig ? sosnt muss ich LadenUserJs´() auf public setzten
         * da hab ich jetzt auch keine Zeit dafür weil ichdann ncoha dnere sachen abänern 
         * muss und macht keinen sinn ICh will ja das die methode protected internal ist !*/
        private static void LadenBenutzerDaten()
        {
            User temporärInstanz = new Admin("","","","");
            _alleBenutzer = temporärInstanz.LadenUserJs();
        }
    }
}
