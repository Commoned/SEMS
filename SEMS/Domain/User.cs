namespace SEMS.Domain
{
    public class User
    {
        public User(Employee employee, string password)
        {
            Employee = employee;
            Password = password;
        }

        public Employee Employee { get; set; }

        public string Password { get; set; }
    }
}