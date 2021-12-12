using curriculum.Data;
using curriculum.Models;
using System;

namespace curriculum.Business
{
    public class UserBz : IUserBz
    {
        IUserData userData;
        public UserBz(IUserData userData)
        {
            this.userData = userData;
        }

        public User GetUserById(int UserId)
        {
            try
            {
                return new User(userData.getUserById(UserId));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public User GetUserByUsername(string userName)
        {
            try
            {
                return new User(userData.getUserByUserName(userName));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
