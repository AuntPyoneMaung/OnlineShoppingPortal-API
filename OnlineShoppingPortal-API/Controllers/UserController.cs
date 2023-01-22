using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShoppingPortal_API.Data;
using OnlineShoppingPortal_API.Helpers;
using OnlineShoppingPortal_API.Models;

namespace OnlineShoppingPortal_API.Controllers
{
    [EnableCors("ShoppingOrigins")]
    [Route("api/[controller]")]
    // you can also specify [action] for all in controller
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext dataContext;

        public UserController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // get all users
        // access allowed only with authentication 
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }

            // check if user with give username exist
            var user = await dataContext.Users
                .FirstOrDefaultAsync(u => u.UserName == userObj.UserName);
            if (user == null) 
            { 
                return NotFound(new { Message = "User Not Found" });
            }
            // check if user's given password matches for login
            // uses helpers service to match doc object and database password
            if (!HashedPassword.VerifyPass(userObj.Password, user.Password))
            {
                return BadRequest(new { Messsage = "Incorrect Password!" });
            }

            // else produce token and send w response
            user.Token = CreateJwtToken(user); 


            {
                // using jwt, backend should send token as well
                return Ok(new {
                    Token = user.Token,
                    Message = "Login successful" });
            }
        }

        // to create a user when front-end signs up for a new user 
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            // ensure that usernames and emails are unique with AnyAsync 
            if (await UserNameCheck(userObj.UserName)) 
            {
                return BadRequest(new {Message = "This username already exist"});
            }
            if (await EmailCheck(userObj.EmailId))
            {
                return BadRequest(new { Message = "This e-mail has already been used to register" });
            }

            // else hash the password input, set all new sign up roles as user, add to database
            userObj.Password = HashedPassword.HashedPass(userObj.Password);
            userObj.Role = "user";
            userObj.Token = "";
            // add object from web BODY
            await dataContext.Users.AddAsync(userObj);
            await dataContext.SaveChangesAsync();

            return Ok(new { Message = "User Registered Successfully" });
        }

        private async Task<bool> EmailCheck(string email)
        {
            return await dataContext.Users.AnyAsync(u => u.EmailId == email);
        }
        private async Task<bool> UserNameCheck(string username)
        {
            return await dataContext.Users.AnyAsync(u => u.UserName == username);   
        }

        private string CreateJwtToken(User userObj)
        {
            // header payload/identity signature
            var tokenHandler = new JwtSecurityTokenHandler();
            // convert key into bytes
            var key = Encoding.ASCII.GetBytes("this%^is!@$a$random(*99");
            // set user role and fullname as its unique identity
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, userObj.Role),
                new Claim(ClaimTypes.Name, $"{userObj.FirstName} {userObj.LastName}")
            });
            // pass in the key to create signature + algo
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                // validity, user will be logged out after this set period
                // during this period, the token can be intercepted so consider using refresh tokens (future implementation)
                Expires = DateTime.Now.AddDays(1),  
                SigningCredentials = credentials,
            };

            // finally create a token with all components ready
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }




        // scaffolded 
        // GET: api/User
        [Authorize] // interceptor
        [HttpGet]
        [Route("getAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await dataContext.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await dataContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest("User ID mistmatch");
            }

            dataContext.Entry(user).State = EntityState.Modified;

            try
            {
                await dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            dataContext.Users.Add(user);
            await dataContext.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await dataContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            dataContext.Users.Remove(user);
            await dataContext.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return dataContext.Users.Any(e => e.UserId == id);
        }
    }
}
