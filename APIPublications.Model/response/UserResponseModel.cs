namespace APIPublications.Model.response
{
    public class UserResponseModel
    {
        public UserResponseModel(int id, string names, string surnames, string email, bool newUser)
        {
            Id = id;
            Names = names;
            Surnames = surnames;
            Email = email;
            NewUser = newUser;
        }

        public int Id { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public bool NewUser { get; set; }
    }
}