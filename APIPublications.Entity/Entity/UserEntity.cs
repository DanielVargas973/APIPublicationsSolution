namespace APIPublications.Entity.Entity
{
    public class UserEntity
    {
        public UserEntity(string userNames, string userSurnames, string userEmail, string userPassword)
        {
            UserNames = userNames;
            UserSurnames = userSurnames;
            UserEmail = userEmail;
            UserPassword = userPassword;
        }

        public int IdUser { get; set; }
        public string UserNames { get; set; }
        public string UserSurnames { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool Status { get; set; }
    }
}