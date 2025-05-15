using System.Xml.Linq;

namespace HRManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Globale Variablen
            bool sysEx = false;
            int fehlVersuche = 0;

            // Main-Loop als Fußgesteuerte do-while
            do
            {
                Console.Clear();
                LadeBalken(1,10); // Methode um Ladeanimation zu simulieren ^^

                // Anmelde Methode
                Console.Write("Geben sie den Benutzernamen  des zu löschenden Benutzers an: ");
                benutzerName = Console.ReadLine() ?? "Leere Eingabe";
                Console.Write("Geben sie den Domainnamen  des zu löschenden Benutzers an: ");
                domainName = Console.ReadLine() ?? "Leere Eingabe";
                Console.Write("Geben sie das Password  des zu löschenden Benutzers an: ");
                password = Console.ReadKey("*") ?? "Leere Eingabe";


                BenutzterOberfläche( benutzerName);


                // EingabeFeld für Benutzername 


                /* Anmelde logik:
                 * 
                 * 
                 */

                //bool anmeldeVersuch = AnmeldeUeberpruefung(anmeldeName, password);

                // Methode: Programm-Beenden 

                sysEx = ProgrammExit();

            } while (!sysEx);
        }
        private static void LadeBalken(int startPunktDerIteration, int endPunktderIteration)
        {
            Console.Clear();

            for (int i =startPunktDerIteration ;    i < endPunktderIteration; i++)
            {
                
                if (i == startPunktDerIteration) Console.WriteLine("===={ Ladesequenz  }====\n");
                for (int j = 0; j < i; j++){
                    Console.Write("|".PadRight(2));   // LadeAnimation !!! 
                    Thread.Sleep(50);
                    
                }
                if (i == endPunktderIteration - 1) Console.WriteLine("\n\n===={ Ladesequenz beendet }====");
                Thread.Sleep(10);
            }
        }
        private static bool ProgrammExit()
        {
            bool sysEx = false;
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
        private void BenutzterOberfläche(string benutzerName,string domainName, string password)
        {

            string anmeldeName = $"{benutzerName}@{domainName}";
            // BenutzernameLoginFenster
            BenutzterOberflächeAnmeldeNameAnzeige(benutzerName, domainName);
            // PasswordLoginFenster  
            BenutzterOberflächePasswordAnzeige(password);
        }
        private string BenutzterOberflächePasswordAnzeige(string  password)
        {
            Console.WriteLine(@$"
                                    _____________________________________________________________________________________________________________________________________________________________
                                    
                                    |                                      ==================== Menü ===============                                                                             |
                                    |                                                                                                                                                            |
                                    |                   Willkommen, um auf die Features Ihres HR-Manager zugreifen zu können, ist ein Anmelde Prozess erforderlich.                              |
                                    |                   Geben sie nun Ihr Password ein...                                                                                                        |
                                    |                                                                                                                                                            |
                                    |                                                         ===== Login ====                                                                                   |
                                    |                                                                                                                                                            | 
                                    |                                                         Password:                                                                                          |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                                                                                                                                                                                
                                    --------------------------------------------------------------------------------------------------------------------------------------------------------------
                                    ");
            Console.SetCursorPosition(13,30);
            Console.Write("TestDöner");
            return password ??"Sie müssen ein Passwort eingeben";
        }
        private string BenutzterOberflächeAnmeldeNameAnzeige(string benutzterName, string domainName)
        {
            string anmeldeName = $"{benutzterName}@{domainName}";
            string userRolle = DomänenRolle(domainName);
            // BenutzernameLoginFenster
            Console.WriteLine(@$"
                                    _____________________________________________________________________________________________________________________________________________________________
                                    
                                    |                                      ==================== Menü ===============                                                                             |
                                    |                                                                                                                                                            |
                                    |                   Willkommen, um auf die Features Ihres HR-Manager zugreifen zu können, ist ein Anmelde Prozess erforderlich.                              |
                                    |                   Geben sie nun Ihren Benutzternamen ein...                                                                                                |
                                    |                                                                                                                                                            |
                                    |                                                         ===== Login ====                                                                                   |
                                    |                                                                                                                                                            |
                                    |                                                         Benutzername:  {name,-30}                                                                          |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                    |                                                                                                                                                            |
                                                                                                                                                                                                  
                                    --------------------------------------------------------------------------------------------------------------------------------------------------------------
                                    ");
            return name;
        }
        private static string DomänenRolle(string domainName)
        {
            if (domainName.Contains("admin"))
            {
                return "admin";
            }
            if (domainName.Contains("manager"))
            {
                return "manager";
            }
            if (domainName.Contains("it"))
            {
                return "it";
            }
            if (domainName.Contains("verkauf"))
            {
                return "verkauf";
            }
            return null;
        }
    }
}
