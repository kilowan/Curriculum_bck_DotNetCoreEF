using curriculum.Data.Models;

namespace curriculum.Data
{
    public interface IUserData
    {
        public User getUserById(int UserId);
        public User getUserByUserName(string username);
    }
}
