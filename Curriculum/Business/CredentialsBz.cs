using curriculum.Data;
using System;

namespace curriculum.Business
{
    public class CredentialsBz : ICredentialsBz
    {
        private readonly ICredentialsData credentialsData;
        public CredentialsBz(ICredentialsData credentialsData)
        {
            this.credentialsData = credentialsData;
        }

        public bool CheckCredentials(string username, string password)
        {
            try
            {
                return credentialsData.CheckCredentials(username, password);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool CheckUsername(string username)
        {
            try
            {
                return credentialsData.CheckUsername(username);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
