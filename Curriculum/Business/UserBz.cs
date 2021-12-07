using curriculum.Data;
using curriculum.Models;

namespace curriculum.Business
{
    public class UserBz : IUserBz
    {
        IUserData userData;
        public UserBz(IUserData userData)
        {
            this.userData = userData;
        }

        public User getUserById(int UserId) 
        {
            return new User(userData.getUserById(UserId));
        }
    }
}
