using CourseShop.Core.Convertors;
using CourseShop.Core.DTO;
using CourseShop.Core.Interfaces;
using CourseShop.Core.Security;
using CourseShop.DataLayer.Context;
using CourseShop.DataLayer.Entity;
using System.Linq;

namespace CourseShop.Core.Services
{
    public class UserService : IUserService
    {
        private readonly CourseShopContext _context;

        public UserService(CourseShopContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool EmailIsExist(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return false;

            return true;
        }



        public bool UserIsExist(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return false;

            return true;
        }

        public User UserByActivateCode(string ActiveCode)
        {
            return _context.Users.FirstOrDefault(u => u.ActivateCode == ActiveCode);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public User Login(LoginViewModel login)
        {
            string hashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
            string email = FixedText.FixedEmail(login.Email);
            return _context.Users.SingleOrDefault(u => u.Email == email && u.PasswordHash == hashPassword);
        }

        public User GetUserByEmail(string Email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == Email);
        }
    }
}
