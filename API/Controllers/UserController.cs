using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.DTO;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;

    public UserController(UserService datafromService)
    {
        _data = datafromService;
    }

// Add a user

[HttpPost("AddUsers")]

public bool AddUser(CreateAccountDTO UserToAdd)
{
    return _data.AddUser(UserToAdd);
}

// getAllUsers endpoint

[HttpGet("GetAllUsers")]

public IEnumerable<UserModel> GetAllUsers()
{
    return _data.GetAllUsers();
}

// GetUserByUsername
[HttpGet("GetUserByUserName/{username}")]

public UserIdDTO GetUserIdDTOByUserName(string username)
{
    return _data.GetUserIdDTOByUserName(username);
}


// Login
[HttpPost("Login")]

public IActionResult Login([FromBody] LoginDTO User)
{
    return _data.Login(User);
}


// Delete user account

[HttpPost("DeleteUser/{UserToDelete}")]
public bool DeleteUser(string UserToDelete)
{
    return _data.DeleteUser(UserToDelete);
}

// Update user account

[HttpPost("UpdateUser")]

public bool UpdateUser(int id, string username)
{
    return _data.UpdateUser(id,username);
}
    

    }
}