using curriculum.Models.Employee;
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
                curriculum.Models.Credentials cred = new curriculum.Models.Credentials(username, password);
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
                return id != null && id != 0 ? true : false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool UpdatePassword(CredentialsDto creds, string code)
        {
            try
            {
                bool codeExist = _context.RecoverLogs
                    .Where(log => log.code == code)
                    .FirstOrDefault()
                    != null ? true : false;
                bool result = false;

                if (codeExist)
                {
                    curriculum.Models.Credentials credenti = new curriculum.Models.Credentials(creds.username, creds.password);
                    Models.Credentials credential = _context.Credentials
                        .Where(credentials => credentials.username == creds.username)
                        .FirstOrDefault();

                    if (credential != null)
                    {
                        credential.password = credenti.password;
                        _context.Credentials.Update(credential);
                        if (_context.SaveChanges() == 1) result = true;
                    }
                }

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
