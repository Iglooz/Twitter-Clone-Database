using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter_Clone_ASP.NET.Models;
using Twitter_Clone_ASP.NET.Models.DTO;

namespace Twitter_Clone_ASP.NET.Data
{
    public class MockRepository : IRepository
    {


         List<UserDTO> Users = new List<UserDTO>()
            {
                new UserDTO() { Id = 1, UserName = "Bob3939", TwitterHandle = "BigBobx", ImageUrl = "coolimg.com/img/1"},
                new UserDTO() { Id = 2, UserName = "katiejones94", TwitterHandle = "KateLuvs2sk8", ImageUrl = "coolimg.com/img/2"},
                new UserDTO() { Id = 3, UserName = "blueskies12", TwitterHandle = "BlueSkiez", ImageUrl = "coolimg.com/img/3"}, 
            };
         List<Post> Posts = new List<Post>()
         {
             new Post(){Id = 1, },
             new Post(){Id = 2, },
             new Post(){Id = 3, },
        
         };

        

        public MockRepository()
        {
            
        }
        public Task<List<UserDTO>> GetAllUsersAsync()
        {
            return null;
        }
        public Task<UserDTO> GetUserByIdAsync(int id)
        {
            return null;
        }
        public Task<List<PostDTO>> GetAllPostsAsync()
        {
            return null; //FIX LATER IDK WHO CARES ITS JUST MOCK REPO
        }
        public Task<PostDTO> GetPostByIdAsync(int id)
        {
            return null; //FIX LATER MAYBE IDK
        }

        public Task CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task CreatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdatePostAsync(int id, PostDTO post)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(int id, User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
