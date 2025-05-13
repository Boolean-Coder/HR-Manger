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

        protected string Password { get; private set; }

        private string _passwordVerschlüsselung;


        // Konstruktor

        protected User(string benutzerName, string domainName, string password)
        {
            BenutzerName = benutzerName;
            DomainName = domainName;
            Password = PasswordVerschlüsseln(password);
        }
        
        public abstract void Anmelden();

        private string PasswordVerschlüsseln(string password) 
        {

        }

    }
}
