using IdentityAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IdentityResult> CreateUser(User user)
        {
            var result = await _userManager.CreateAsync(user, "arun@12345");

            return result;
        }

        [HttpPost("SignIn")]
        public async Task<bool> SignIn(User user)
        {
            var result = await _userManager.CheckPasswordAsync(user, "arun@12345");

            return result;
        }

        [HttpPost("CreateRole")]
        public async Task<IdentityResult> CreateRole(Role role)
        {
            var result = await _roleManager.CreateAsync(role);

            return result;
        }
    }
}
