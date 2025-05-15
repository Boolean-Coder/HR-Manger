using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HRManager.Class   
{       
    abstract internal class User
    {
        protected string BenutzerName { get; private set; }
        protected string DomainName { get; private set; }

        protected string Rolle {  get; private set; }
        protected string Password { get; private set; }

        /*         private string _passwordVerschlüsselung; 
         *         vorerst gelassen wegen Aes Encryption !!!
         *         Mit dem Aktuellen stand schwer ich kann das höchstens in eine JSON seriallisieren auch das ist noch schwer
         *         aber ich habe vorerfarhung durhc die Wetter app die ich mit Andrei geschrieben hatte 
         *         Das schau ich mir genau erst am Wochenende an! 
        */

        // Konstruktor

        protected User(string benutzerName, string domainName,string userRolle, string password)
        {
            BenutzerName = benutzerName;
            DomainName = domainName;
            Password = password;
            Rolle = userRolle;
            /* Verschlüsselungs Methode - auf Eis gelegt
             * Password = PasswordVerschlüsseln(password);*/
        }
        
        public abstract void Anmelden(string userRolle, string benutzerName, string domainName, string password);

        public void BenutzerdatenEinfügen(Dictionary<string, List<Dictionary<string, string>>> zielDict)
        {
            if (!zielDict.ContainsKey(Rolle))
            {
                zielDict[Rolle] = new List<Dictionary<string, string>>();
            }
            var zielDictEintrag = new Dictionary<string, string> {
                ["benutzerName"] = BenutzerName,
                ["domainName"] = DomainName,
                ["rolle"] = Rolle,
                ["password"] = Password
            };
            zielDict[Rolle].Add(zielDictEintrag);
        }
    }

    // Methoden die NUR von der User Klasse  und Admin klasse Vorhanden sind und demnach ausgeführt werden können!!

    /* VerschlüsselungsMethode - auf Eis gelget
     * private string PasswordVerschlüsseln(string password, byte[] _passwprdVerschlüsselung, byte[] _) 
    {

    }*/
}
