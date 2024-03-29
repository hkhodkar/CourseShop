﻿using CourseShop.Core.DTOs;
using CourseShop.DataLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseShop.Core.Interfaces
{
    public interface IUserService
    {
        #region Account
        void AddUser(User user);

        bool UserIsExist(string username);

        bool EmailIsExist(string email);

        User UserByActivateCode(string ActiveCode);

        void UpdateUser(User user);

        Task<User> Login(LoginViewModel viewModel);

        User GetUserByEmail(string Email);

        User GetUserByUsername(string username);

        User GetUserById(int id);

        int GetUserIdByUserName(string username);




        #endregion

        #region UserPanel

        UserPanelViewModel GetUserInformation(string username);

        EditProfileViewModel GetUserInfForEdit(string username);

        void EditProfile(string username, EditProfileViewModel profile);
        bool ChangePassword(string username, ChangePasswordViewModel changePassword);

        #endregion

        #region AdminPanel

        IList<User> GetUsersList();

        IList<User> GetDeleteUsersList();

        Task<int> AddUserInAdminPanel(UserForAdminViewModel user);

        Task<UserForAdminViewModel> GetUserForEditMode(int id);

        Task<int> EditUserAdminPanel(UserForAdminViewModel user);

        void DeleteUser(int id);

        void RestoreUser(int id);

        #endregion

    }
}
