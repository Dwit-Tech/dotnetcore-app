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

        public UserRepository(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public User CreateUser(User user)
        {
           
            MockUsers.Add(user);
            
            return user; //Returning the user inserted

            
           
        }

        public void DeleteUser(User user)
        {
            
          var findUser =  MockUsers.FirstOrDefault(o => o.Id == user.Id);
            if(findUser != null)
            {
                MockUsers.Remove(findUser);
            }
            
        }

        public IEnumerable<User> GetAll()
        {
            return MockUsers.ToList();
        }

        public User GetUserById(int id)
        {
            var getUserById = MockUsers.FirstOrDefault(o => o.Id == id);
            return getUserById;

        }

        public void UpdateUser(User user)
        {
            
        }
    }
}
