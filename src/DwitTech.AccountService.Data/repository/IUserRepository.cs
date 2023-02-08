using DwitTech.AccountService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Data.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User CreateUser(User user);

        User GetUserById(int id);

        void UpdateUser(User user);

        void DeleteUser(User user);

    }
}
