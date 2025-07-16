using BusinessObjects.Entities;
using DataAccess.DAO;
using Repositories.Repositories.Interface;

namespace Repositories.Repositories.Implement
{
    public class LoginRepository : ILoginRepository
    {
        private readonly LoginDAO _loginDao;

        public LoginRepository(LoginDAO loginDao)
        {
            _loginDao = loginDao;
        }

        public Account Login(string email, string password)
        {
            return _loginDao.Login(email, password);
        }
    }
}
