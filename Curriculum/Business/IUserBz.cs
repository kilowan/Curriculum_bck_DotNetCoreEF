using curriculum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Business
{
    public interface IUserBz
    {
        public User getUserById(int UserId);
    }
}
