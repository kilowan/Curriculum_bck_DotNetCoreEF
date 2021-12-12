namespace curriculum.Business
{
    public interface ICredentialsBz
    {
        public bool CheckCredentials(string username, string password);
        public bool CheckUsername(string username);
    }
}
