using curriculum.Data;
using System;

namespace curriculum.Business
{
    public class PasswordRecoveryBz : IPasswordRecoveryBz
    {
        IPasswordRecoveryData passwordRecoveryData;
        public PasswordRecoveryBz(IPasswordRecoveryData passwordRecoveryData)
        {
            this.passwordRecoveryData = passwordRecoveryData;
        }

        public bool CheckRecoverCode(string code, string username)
        {
            try
            {
                return passwordRecoveryData.CheckRecoverCode(code, username);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool RecoverPassword(string username)
        {
            try
            {
                return passwordRecoveryData.RecoverPassword(username);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
