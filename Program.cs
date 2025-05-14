using System.Xml.Linq;

namespace HRManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Globale Variablen
            bool sysEx = false;
            string benutzerName="", domainName="", password="";
            string name = $"{benutzerName}@{domainName}";
            Console.WriteLine("Hallo, Manager!");

            // Main-Loop als Fußgesteuerte do-while

            do
            {
                Console.Clear();


                LadeBalken(1,10); // Methode um Ladeanimation zu simulieren ^^

                // Begrüßungs Methode


                // EingabeFeld für Benutzername 
                




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
            sysEx = Console.ReadLine()?.Trim().ToLower() == "j" ;
            return sysEx;
        }

        // Methode für Anzeige Logik 
        private void BenutzterOberfläche(string benutzername,string domainName, string password)
        {

            string name = $"{benutzername}@{domainName}";
            // BenutzernameLoginFenster
            BenutzterOberflächeAnmeldeNameAnzeige(benutzername, domainName);
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
                                    |                                                         Password:  {password,-30}                                                                          |
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
            return password;
        }
        private string BenutzterOberflächeAnmeldeNameAnzeige(string benutzterName, string domainName)
        {
            string name = $"{benutzterName}@{domainName}";
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
    }
}
