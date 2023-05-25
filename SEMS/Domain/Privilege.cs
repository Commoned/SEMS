
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
