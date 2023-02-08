using DwitTech.AccountService.Core.Dtos;
using DwitTech.AccountService.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DwitTech.AccountService.WebApi.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var allUsers = _userService.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpGet("{id}")]
        public ActionResult GetUserById(int id) 
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public ActionResult CreateUser(UserCreateDto user)
        {
           var createNew =  _userService.CreateUser(user);
            return Ok(createNew);
        }

        [HttpPut("{id}", Name ="GetUserById")]
        public ActionResult UpdateUser(int id, UserCreateDto userCreateDto)
        {
            var singleUser = _userService.GetUserById(id);
            if(singleUser != null)
            {
                _userService.UpdateUser(userCreateDto);
                return NoContent();
            }

            return NotFound("User Not Found");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id, UserReadDto userCreateDto) {
            var findUser = _userService.GetUserById(id);
            if(findUser != null)
            {
                _userService.DeleteUser(userCreateDto);
                return NoContent();
            }
            return NotFound();
        }

    }
}
