namespace curriculum.Data
{
    public interface IPasswordRecoveryData
    {
        public bool RecoverPassword(string username);
        public bool CheckRecoverCode(string code, string username);
    }
}
