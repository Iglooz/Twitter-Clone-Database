using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter_Clone_ASP.NET.Models.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            Posts = new List<PostDTO>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string TwitterHandle { get; set; }
        public string ImageUrl { get; set; }
        public List<PostDTO> Posts { get; set; }
    }
}
