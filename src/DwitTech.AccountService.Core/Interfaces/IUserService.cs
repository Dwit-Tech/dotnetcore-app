using DwitTech.AccountService.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Core.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserReadDto> GetAllUsers();
        UserReadDto CreateUser(UserCreateDto user);
        UserReadDto GetUserById(int id);
        void UpdateUser(UserCreateDto user);
        void DeleteUser(UserReadDto user);
    }
}
