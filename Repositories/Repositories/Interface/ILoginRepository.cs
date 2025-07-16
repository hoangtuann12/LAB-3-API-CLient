using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Interface
{
    public interface ILoginRepository
    {
        Account Login(string email, string password);
    }

}
