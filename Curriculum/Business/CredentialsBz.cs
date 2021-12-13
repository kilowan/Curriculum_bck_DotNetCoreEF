using curriculum.Data;
using curriculum.Models.Employee;
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

        public bool UpdatePassword(CredentialsDto creds)
        {
            try
            {
                return credentialsData.UpdatePassword(creds);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
