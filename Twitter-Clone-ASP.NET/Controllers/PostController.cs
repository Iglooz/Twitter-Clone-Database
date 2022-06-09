using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter_Clone_ASP.NET.Models;
using Twitter_Clone_ASP.NET.Models.DTO;

namespace Twitter_Clone_ASP.NET.Data
{
    [Route("api/posts")]
    [Controller]
    public class PostController : ControllerBase
    {
        private readonly IRepository _repository;

        public PostController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<PostDTO>> GetAllPostsAsync()
        {
            try
            {
                List<PostDTO> posts = await _repository.GetAllPostsAsync();
                return Ok(posts);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PostDTO>> GetPostByIdAsync(int id)
        {
            try
            {
                PostDTO pos = await _repository.GetPostByIdAsync(id);
                if (pos == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(pos);
                }
                
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody]Post post)
        {

            
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreatePostAsync(post);
                    return CreatedAtAction(nameof(GetPostByIdAsync), new { id = post.Id }, post);

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

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostDTO post)
        {
            try
            {
                Post updatedPost = await _repository.UpdatePostAsync(id, post);
                if (updatedPost == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction( nameof(GetPostByIdAsync), new { id = updatedPost.Id }, updatedPost);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            try
            {
                bool deleteSuccess = await _repository.DeletePostAsync(id);
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
