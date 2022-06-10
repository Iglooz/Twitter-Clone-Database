using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter_Clone_ASP.NET.Models.DTO
{
    public class PostDTO
    {
        public PostDTO()
        {
            User = new User();
        }
        public int Id { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
        public int Likes { get; set; }
        public int Shares { get; set; }
        public int UserId { get; set; }
        public bool Edit { get; set; }
    }
}
