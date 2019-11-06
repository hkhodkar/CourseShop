using CourseShop.Core.DTOs;
using CourseShop.DataLayer.Entity;
using System.Collections.Generic;

namespace CourseShop.Core.Interfaces
{
    public interface IWalletService
    {
        IList<WalletViewModel> GetUserWallet(int userId);
        int WallateBalance(int userId);
        int ChargeWallet(Wallet wallet);
        Wallet GetWalletById(int walletId);
        void UpdateWallet(Wallet wallet);
    }
}
