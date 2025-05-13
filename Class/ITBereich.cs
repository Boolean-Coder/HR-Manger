using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Class
{
    internal class ITBereich : User
    {
        public ITBereich(string benutzerName, string domainName, string password) : base(benutzerName, domainName, password) { }  // Erbt die base von User Klass

        public void ITzeugs() { Console.WriteLine("Ich mache IT ZEUGS"); } // Ich hoffe ich hab später genug zeit 
    }
}
