using System.Security.Cryptography;
using System.Text;

namespace curriculum.Models
{
    public class Credentials
    {
        public string username { get; }
        public string password { get; }

        public Credentials(string username, string password)
        {
            this.username = username;
            this.password = GetMD5(password);
        }
        public Credentials(Data.Models.Credentials credentials)
        {
            this.username = credentials.username;
            this.password = credentials.password;
        }
        private static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
