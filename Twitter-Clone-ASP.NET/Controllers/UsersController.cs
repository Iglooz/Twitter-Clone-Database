using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter_Clone_ASP.NET.Data;
using Twitter_Clone_ASP.NET.Models;
using Twitter_Clone_ASP.NET.Models.DTO;

namespace Twitter_Clone_ASP.NET.Controllers
{
    [Route("api/users")]
    [Controller]
    public class UsersController : ControllerBase
    {
        private readonly IRepository _repository;

        public UsersController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetAllUsers()
        {
            try
            {
                List<UserDTO> users = await _repository.GetAllUsersAsync();

                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            

            try
            {
                UserDTO us = await _repository.GetUserByIdAsync(id);
                if (us == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(us);
                }

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateUserAsync(user);
                    return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            

            
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task <ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                bool deleteSuccess = await _repository.DeleteUserAsync(id);
                if (deleteSuccess == false)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
               return StatusCode(500);
            }
        }

    }
}
