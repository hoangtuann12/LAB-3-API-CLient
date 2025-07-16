using BusinessObjects.Data;
using BusinessObjects.Entities;
using System.Linq;

namespace DataAccess.DAO
{
    public class LoginDAO
    {
        private readonly MyDbContext _context;

        public LoginDAO(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Kiểm tra thông tin đăng nhập.
        /// </summary>
        /// <param name="email">Email của tài khoản.</param>
        /// <param name="password">Mật khẩu của tài khoản.</param>
        /// <returns>Trả về tài khoản nếu thông tin đúng, ngược lại trả về null.</returns>
        public Account Login(string email, string password)
        {
            return _context.Accounts
                .FirstOrDefault(a => a.Email == email && a.Password == password);
        }

        /// <summary>
        /// Kiểm tra xem email đã tồn tại hay chưa.
        /// </summary>
        /// <param name="email">Email cần kiểm tra.</param>
        /// <returns>True nếu email đã tồn tại, ngược lại false.</returns>
        public bool IsEmailExists(string email)
        {
            return _context.Accounts.Any(a => a.Email == email);
        }

        /// <summary>
        /// Đăng ký tài khoản mới.
        /// </summary>
        /// <param name="account">Thông tin tài khoản cần đăng ký.</param>
        public void Register(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}
