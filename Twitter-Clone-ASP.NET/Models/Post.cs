using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter_Clone_ASP.NET.Models
{
    public class Post
    {
        public Post()
        {
            //User = new User();
        }
        [Key]
        public int Id { get; set; }
        public virtual User User { get; set; }
        [Required]
        [MaxLength(280)]
        public string Message { get; set; }
        public int Likes { get; set; }
        public int Shares { get; set; }
        [Required]
        public int UserId { get; set; }
        public bool Edit { get; set; }
        


    }
}
