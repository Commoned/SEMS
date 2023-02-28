using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Domain
{
    public class Privilege
    {

        public Privilege(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        //todo Privileges (Userrechte ex. personalabteilung oder mitarbeiter)
    }
}
