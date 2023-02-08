using AutoMapper;
using DwitTech.AccountService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Core.Dtos
{
    [AutoMap(typeof(User), ReverseMap =true)]
    public class UserCreateDto:UserDto
    {
        public DateTime ModifiedOnUtc { get; set;  }
        public DateTime CreatedOnUtc { get; } = DateTime.UtcNow;
    }
}
