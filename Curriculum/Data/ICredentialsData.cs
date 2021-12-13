using curriculum.Models.Employee;

namespace curriculum.Data
{
    public interface ICredentialsData
    {
        public bool CheckCredentials(string username, string password);
        public bool CheckUsername(string username);
        public bool UpdatePassword(CredentialsDto creds);

    }
}
