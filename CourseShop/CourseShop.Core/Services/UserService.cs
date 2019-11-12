using CourseShop.Core.Convertors;
using CourseShop.Core.DTOs;
using CourseShop.Core.Generators;
using CourseShop.Core.Interfaces;
using CourseShop.Core.Security;
using CourseShop.DataLayer.Context;
using CourseShop.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CourseShop.Core.Services
{
    public class UserService : IUserService
    {
        private readonly CourseShopContext _context;

        public UserService(CourseShopContext context)
        {
            _context = context;
        }

        #region Account
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

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public User GetUserByUserName(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }


        public int GetUserIdByUserName(string username)
        {
            return _context.Users.Where(u => u.Username == username).Select(u => u.UserId).Single();
        }

        #endregion

        #region UserPanel

        public UserPanelViewModel GetUserInformation(string username)
        {
            return _context.Users
                .Where(u => u.Username == username)
                .Select(u => new UserPanelViewModel
                {
                    Username = u.Username,
                    Email = u.Email,
                    AvatarName = u.AvatarName,
                    RegisterDate = u.RegisterDate
                }).Single();
        }

        public EditProfileViewModel GetUserInfForEdit(string username)
        {
            return _context.Users.Where(u => u.Username == username)
                .Select(u => new EditProfileViewModel
                {
                    AvatarName = u.AvatarName,
                }).Single();
        }

        public void EditProfile(string username, EditProfileViewModel profile)
        {
            string imagePath = "";
            if (profile.UserAvatar != null)
            {
                if (profile.AvatarName != "default.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);

                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                profile.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(profile.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    profile.UserAvatar.CopyTo(stream);
                }

            }
            var user = GetUserByUserName(username);
            user.AvatarName = profile.AvatarName;
            UpdateUser(user);
        }

        public bool ChangePassword(string username, ChangePasswordViewModel changePassword)
        {
            var user = GetUserByUserName(username);

            var oldPassHash = PasswordHelper.EncodePasswordMd5(changePassword.OldPassword);

            if (user.PasswordHash == oldPassHash)
            {
                var newPassHash = PasswordHelper.EncodePasswordMd5(changePassword.NewPassword);
                user.PasswordHash = newPassHash;
                UpdateUser(user);
                return true;
            }
            else
            {
                return false;

            }
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        #endregion

        #region AdminPanel
        public IList<User> GetUsersList()
        {
            return _context.Users.ToList();
        }

        public async Task<int> AddUserInAdminPanel(CreateUserForAdminViewModel user)
        {
            string imagePath = "";
            if (user.UserAvatar != null)
            {
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar",user.AvatarName);
                user.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(user.UserAvatar.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UserAvatar.CopyTo(stream);
                }
            }

            User newUser = new User
            {
                ActivateCode = NameGenerator.GenerateUniqCode(),
                AvatarName = user.AvatarName,
                Email = FixedText.FixedEmail(user.Email),
                IsActive = true,
                PasswordHash = PasswordHelper.EncodePasswordMd5(user.Password),
                RegisterDate = DateTime.Now,
                Username = user.Username,
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return await Task.Run(() => newUser.UserId);
        }



        #endregion
    }
}
