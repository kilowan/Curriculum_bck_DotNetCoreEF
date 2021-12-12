using curriculum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Data
{
    public class UserData : IUserData
    {
        private readonly CurriculumContext _context;
        public UserData(CurriculumContext context)
        {
            _context = context;
        }

        public User getUserById(int UserId)
        {
            try
            {
                return _context.User
                    .Include(User => User.phoneNumber)
                    .ThenInclude(pn => pn.phone)
                    .Include(User => User.emailList)
                    .Where(User => User.id == UserId)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public User getUserByUserName(string username)
        {
            try
            {
                return _context.User
                    .Include(user => user.credentials)
                    .Include(User => User.phoneNumber)
                    .ThenInclude(pn => pn.phone)
                    .Include(User => User.emailList)
                    .Where(User => User.credentials.username == username)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
