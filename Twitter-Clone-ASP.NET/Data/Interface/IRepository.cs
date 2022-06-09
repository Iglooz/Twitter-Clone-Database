using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter_Clone_ASP.NET.Models;
using Twitter_Clone_ASP.NET.Models.DTO;

namespace Twitter_Clone_ASP.NET.Data
{
    public interface IRepository
    {
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<List<PostDTO>> GetAllPostsAsync();
        Task<PostDTO> GetPostByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task CreatePostAsync(Post post);
        Task<Post> UpdatePostAsync(int id, PostDTO post);
        Task<bool> DeletePostAsync(int id);
        Task<User> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);

    }
}
