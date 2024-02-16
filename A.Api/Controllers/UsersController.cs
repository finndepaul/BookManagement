using Book.Api.Entities;
using Book.Api.IRepositories;
using Book.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Book.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepos _repos;
        private readonly IPasswordHasher<User> passwordHasher;

        public UsersController(IUserRepos repos, IPasswordHasher<User> passwordHasher)
        {
            _repos = repos;
            this.passwordHasher = passwordHasher;
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = new User()
            {
                FullName = request.FullName,
                Address = request.Address,
                UserName = request.UserName,
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpperInvariant(),
                NormalizedUserName = request.UserName.ToUpperInvariant(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            model.PasswordHash = passwordHasher.HashPassword(model, request.Password);

            await _repos.CreateNew(model);
            return Ok(model);
        }
    }
}
