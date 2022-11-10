namespace SEMS.Domain
{
    public class User
    {
        public User(string id, string password)
        {
            Id = id;
            Password = password;
        }

        public string Id { get; set; }

        public string Password { get; set; }
    }
}