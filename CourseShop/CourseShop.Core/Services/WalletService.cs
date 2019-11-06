using CourseShop.Core.DTOs;
using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Context;
using CourseShop.DataLayer.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CourseShop.Core.Services
{
    public class WalletService : IWalletService
    {
        private readonly CourseShopContext _context;

        public WalletService(CourseShopContext context)
        {
            _context = context;
        }



        public IList<WalletViewModel> GetUserWallet(int userId)
        {
            return _context.Wallets.Where(w => w.UserId == userId && w.IsPay == true)
                .Select(w => new WalletViewModel
                {
                    Amount = w.Amount,
                    CreateDate = w.CreateDate,
                    Description = w.Description,
                    TypeId = w.TypeId,
                }).ToList();
        }

        public int WallateBalance(int userId)
        {
            var deposits = _context.Wallets
                 .Where(u => u.UserId == userId && u.IsPay == true && u.TypeId == 1)
                 .Sum(w => w.Amount);

            var removal = _context.Wallets
                 .Where(u => u.UserId == userId && u.IsPay == true && u.TypeId == 2)
                 .Sum(w => w.Amount);

            return deposits - removal;
        }

        public int ChargeWallet(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return wallet.WalletId;
        }

        public Wallet GetWalletById(int walletId)
        {
            return _context.Wallets.Find(walletId);
        }

        public void UpdateWallet(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            _context.SaveChanges();
        }


    }
}
