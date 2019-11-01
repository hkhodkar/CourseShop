using CourseShop.Core.DTO;
using CourseShop.DataLayer.Entity;

namespace CourseShop.Core.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);

        bool UserIsExist(string username);

        bool EmailIsExist(string email);

        User UserByActivateCode(string ActiveCode);

        void UpdateUser(User user);

        User Login(LoginViewModel viewModel);

        User GetUserByEmail(string Email);

    }
}
