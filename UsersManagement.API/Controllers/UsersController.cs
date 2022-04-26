using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersManagement.API.Fake;
using UsersManagement.API.Models;

namespace UsersManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(200);
        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        [HttpPost]
        public User Post([FromBody]User user)
        {
            _users.Add(user);
            return user;
        }

        [HttpPut]
        public User Put([FromBody] User user)
        {
            var editUser = _users.FirstOrDefault(x => x.Id == user.Id);
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            editUser.Address = user.Address;
            
            return editUser;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deletedUser);
        }
    }
}
