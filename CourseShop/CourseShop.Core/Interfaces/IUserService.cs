using CourseShop.Core.DTOs;
using CourseShop.DataLayer.Entity;

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

        User Login(LoginViewModel viewModel);

        User GetUserByEmail(string Email);

        User GetUserById(int id);
        #endregion

        #region UserPanel

        UserPanelViewModel GetUserInformation(string username);

        EditProfileViewModel GetUserInfForEdit(string username);

        void EditProfile(string username, EditProfileViewModel profile);
        bool ChangePassword(string username, ChangePasswordViewModel changePassword);

        #endregion

    }
}
