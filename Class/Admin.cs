using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Class
{
    internal class Admin: User
    {
        public Admin(string userRolle,string benutzerName,string domainName,string password):base( userRolle, benutzerName,domainName,password) { }

        public override void Anmelden()
        {
            Console.WriteLine("Du bist der ÜBER Admin Alle Niederen Klassen unterstehen dir....\n Wir reden hier natürlich nur von Klassen im Sinne von OOP^^ "); ;
        }
        // bekommt noch Methoden Benutzer hinzufügen, löschen anzeigen bearbeiten etc. 
        public void UserErstellen(string userRolle,string benutzerName,string domainName, string password) 
        {
            User neuerUser; // damit  neuerUser den Datentyp "User" erhält  je nach Rolle wird dann  ein Konstruktor der jeweiligen Klasse genutzt da ich die User klasse als abstracte definiert habe geht das !!
            switch (userRolle.ToLower())
            {

                case "verkauf":
                    neuerUser=new VerkaufsBereich(userRolle, benutzerName, domainName,password);  // über die in den klassen definieren Konstruktoren werden  dann neue Objekte mit dem variablenNamen neuerUser vergeben
                    break;
                case "it":
                    neuerUser=new ITBereich(userRolle, benutzerName, domainName, password);   
                    break;
                case "personal":
                    neuerUser=new PersonalManager(userRolle, benutzerName,domainName, domainName);
                    break;
                case "admin":
                    neuerUser=new Admin(userRolle, benutzerName,domainName,password);
                    break;
                default:
                    Console.WriteLine("So eine Rolle ist nicht zu vergeben!");
                    return;
            }
        }

        public void UserBearbeiten(string userRolle, string benutzerName, string domainName, string password)
        {
            User neuerUser;


        }

        public void UserLöschen(string userRolle, string benutzerName, string domainName, string password)
        {
            User neuerUser;
            Console.Write("Geben sie den Benutzernamen  des zu löschenden Benutzters an: ");
            benutzerName = Console.ReadLine() ?? "Leere Eingabe";

            Console.Write("Geben sie den Domainnamen  des zu löschenden Benutzters an: ");
            domainName = Console.ReadLine()?? "Leere EIngabe";
            Console.Write("Geben sie die Abteilung  des zu löschenden Benutzters an: ");
            userRolle = Console.ReadLine() ?? "Leere Eingabe";
            Console.Write("Geben sie das Password  des zu löschenden Benutzters an: ");
            password = Console.ReadLine() ?? "Leere Eingabe";


           // ich mache erstmal Pause brauche nen klaaren Kopf 


        }
    }
}
