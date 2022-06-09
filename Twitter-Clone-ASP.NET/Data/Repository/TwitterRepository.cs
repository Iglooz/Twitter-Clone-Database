using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter_Clone_ASP.NET.Models;
using Twitter_Clone_ASP.NET.Models.DTO;

namespace Twitter_Clone_ASP.NET.Data
{
    public class TwitterRepository : IRepository
    {
        private readonly TwitterDbContext _dbContext;

        public TwitterRepository()
        {
            _dbContext = new TwitterDbContext();
            
        }

        // User tasks

        public async Task CreateUserAsync(User user)
        {
            using(var db = _dbContext)
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            User userToDelete;
            using (var db = _dbContext)
            {
                userToDelete = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (userToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Users.Remove(userToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {

            List<User> users;

            using (var db = _dbContext)
            {
                users = await db.Users.Include(p => p.Posts).ToListAsync();
            }
            List<UserDTO> listToReturn = new List<UserDTO>();

            foreach (User user in users)
            {
                UserDTO userToAdd = new UserDTO();

                userToAdd.Id = user.Id;
                userToAdd.ImageUrl = user.ImageUrl;
                userToAdd.Posts = null; //fix this later
                userToAdd.TwitterHandle = user.TwitterHandle;
                userToAdd.UserName = user.UserName;

                listToReturn.Add(userToAdd);
            }

            return listToReturn;
        }
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            User u;
            using (var db = _dbContext)
            {
                u = await db.Users.Include(p => p.Posts).FirstOrDefaultAsync(x => x.Id == id);

            }
            UserDTO userToReturn = new UserDTO();

            List<PostDTO> postsDTO = new List<PostDTO>();
            if (u == null)
            {
                return null;
            }
            else
            {
                foreach (Post p in u.Posts)
                {
                    PostDTO dto = new PostDTO();
                    dto.Id = p.Id;
                    dto.Likes = p.Likes;
                    dto.Message = p.Message;
                    dto.Shares = p.Shares;
                    dto.User = p.User;

                }
                userToReturn.Id = u.Id;
                userToReturn.ImageUrl = u.ImageUrl;
                userToReturn.Posts = postsDTO; //FIX LATER
                userToReturn.TwitterHandle = u.TwitterHandle;
                userToReturn.UserName = u.UserName;


                return userToReturn;
            }
        }
        public async Task<User> UpdateUserAsync(int id, User user)
        {
            User userToUpdate;
            using (var db = _dbContext)
            {
                userToUpdate = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (userToUpdate == null)
                {
                    return null;
                }
                userToUpdate.TwitterHandle = user.TwitterHandle;
                userToUpdate.UserName = user.UserName;
                userToUpdate.ImageUrl = user.ImageUrl;

                await db.SaveChangesAsync();

                return userToUpdate;
            }
        }

        // Post tasks
        public async Task CreatePostAsync(Post post)
        {
            using (var db = _dbContext)
            {
                await db.Posts.AddAsync(post);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            Post postToDelete;
            using(var db = _dbContext)
            {
                postToDelete = await db.Posts.FirstOrDefaultAsync(p => p.Id == id);
                if(postToDelete == null)
                {
                    // false = delete failed 
                    return false;
                }
                else
                {
                    // true = delete successful
                    db.Posts.Remove(postToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<List<PostDTO>> GetAllPostsAsync()
        {
            List<Post> posts;
            using (var db = _dbContext)
            {
                posts = await db.Posts.Include(x => x.User).ToListAsync();
                foreach (Post post in posts)
                {
                    post.User = await db.Users.FirstOrDefaultAsync(x => x.Id == post.UserId);
                }
            }

            
            List<PostDTO> listToReturn = new List<PostDTO>();

            foreach (Post post in posts)
            {
                PostDTO postToAdd = new PostDTO();

                
                postToAdd.Id = post.Id;
                postToAdd.Likes = post.Likes;
                postToAdd.Message = post.Message;
                
                postToAdd.Shares = post.Shares;
                postToAdd.User = post.User;

                listToReturn.Add(postToAdd);
            }
            return listToReturn;
        }

        public async Task<PostDTO> GetPostByIdAsync(int id)
        {
            Post p;
            using (var db = _dbContext)
            {
                p = await db.Posts.Include(u => u.User).FirstOrDefaultAsync(x => x.Id == id);
               
               
                p.User = await db.Users.FirstOrDefaultAsync(x => x.Id == p.UserId);
                

            }
            
            PostDTO postToReturn = new PostDTO();
            if (p == null)
            {
                return null;
            }
            else
            {
                
                postToReturn.Likes = p.Likes;
                postToReturn.Id = p.Id;
                postToReturn.Shares = p.Shares;
                postToReturn.User = p.User;

                return postToReturn;
            }

        }

        public async Task<Post> UpdatePostAsync(int id, PostDTO post)
        {
            Post postToUpdate;
            using(var db = _dbContext)
            {
                postToUpdate = await db.Posts.FirstOrDefaultAsync(x => x.Id == id);
                if(postToUpdate == null)
                {
                    return null;
                }
                postToUpdate.Message = post.Message;
                postToUpdate.Likes = post.Likes;
                postToUpdate.Shares = post.Shares;

                await db.SaveChangesAsync();

                return postToUpdate;
            }
        }




    }
}
