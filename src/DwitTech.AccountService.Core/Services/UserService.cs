using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DwitTech.AccountService.Core.Dtos;
using DwitTech.AccountService.Core.Interfaces;
using DwitTech.AccountService.Data.Entities;
using DwitTech.AccountService.Data.Repository;

namespace DwitTech.AccountService.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserReadDto CreateUser(UserCreateDto user)
        {

            if(user != null)
            {
               /*var newUser = new UserCreateDto
               {
                   AddressLine1 = user.AddressLine1,
                   AddressLine2 = user.AddressLine2,
                   City = user.City,
                   Country = user.Country,
                   Email = user.Email,
                   Firstname = user.Firstname,
                   Lastname = user.Lastname,
                   PhoneNumber = user.PhoneNumber,
                   PostalCode = user.PostalCode,
                   
               };*/

               var userModel =  _mapper.Map<User>(user);

                _userRepository.CreateUser(userModel);

                return _mapper.Map<UserReadDto>(userModel);
            }

            return null;
            
            /*var userCreateDto = new UserCreateDto
            { 
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2, 
                City = user.City, 
                Country = user.Country, 
                Email = user.Email, 
                Firstname = user.Firstname, 
                Lastname = user.Lastname, 
                PhoneNumber = user.PhoneNumber, 
                PostalCode = user.PostalCode

            };

            var createDb = _userService.CreateUser(userCreateDto);

            return createDb;*/

        }


        public void DeleteUser(UserReadDto user)
        {
            var readDto = _mapper.Map<User>(user);
           _userRepository.DeleteUser(readDto);
        }

        public IEnumerable<UserReadDto> GetAllUsers()
        {
            var allUser = _userRepository.GetAll();
           return _mapper.Map<IEnumerable<UserReadDto>>(allUser);
        }


        public UserReadDto GetUserById(int id)
        {
            var foundUser  =  _userRepository.GetUserById(id);

            if (foundUser == null)
            {

                return null;
                /* return new UserReadDto
                 {
                     AddressLine1 = foundUser.AddressLine1,
                     AddressLine2 = foundUser.AddressLine2,
                     City = foundUser.City,
                     Country = foundUser.Country,
                     Email = foundUser.Email,
                     Firstname = foundUser.Firstname,
                     Lastname = foundUser.Lastname,
                     PhoneNumber = foundUser.PhoneNumber,
                     PostalCode = foundUser.PostalCode
                 };*/
            }

            return _mapper.Map<UserReadDto>(foundUser);
            
  
        }


        public void UpdateUser(UserCreateDto user)
        {
            var userUpdateDto = new UserCreateDto
            {
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                PhoneNumber = user.PhoneNumber,
                PostalCode = user.PostalCode,
                ModifiedOnUtc = DateTime.UtcNow
            };

            var updateDto = _mapper.Map<User>(userUpdateDto);

            _userRepository.UpdateUser(updateDto);

        }
    }
}
