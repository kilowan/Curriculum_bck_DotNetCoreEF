using curriculum.Models;
using System;
using System.Linq;

namespace curriculum.Data
{
    public class CredentialsData : ICredentialsData
    {
        private readonly CurriculumContext _context;
        public CredentialsData(CurriculumContext context)
        {
            _context = context;
        }

        public bool CheckCredentials(string username, string password)
        {
            try
            {
                Credentials cred = new Credentials(username, password);
                int? id = _context.Credentials
                    .Where(creds => creds.username == cred.username && creds.password == cred.password)
                    .Select(creds => creds.id)
                    .FirstOrDefault();
                return id != null ? true : false;
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
                int? id = _context.Credentials
                    .Where(creds => creds.username == username)
                    .Select(creds => creds.id)
                    .FirstOrDefault();
                return id != null ? true : false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
