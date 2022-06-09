using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter_Clone_ASP.NET.Models
{
    public class User
    {
        public User()
        {
            Posts = new List<Post>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string TwitterHandle { get; set; }
        public string ImageUrl { get; set; }
        public List<Post> Posts { get; set; }
    }
}
