using DwitTech.AccountService.Data.Context;
using DwitTech.AccountService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Data.Repository
{
    

    
    public class UserRepository : IUserRepository
    {
        private readonly AccountDbContext _accountDbContext;

        List<User> MockUsers = new List<User>(); //Using this as the database


    }
}
