using curriculum.Models.Employee;

namespace curriculum.Business
{
    public interface ICredentialsBz
    {
        public bool CheckCredentials(string username, string password);
        public string Login(string username, string password);
        public bool CheckUsername(string username);
        public bool UpdatePassword(CredentialsDto creds, string code);
    }
}
