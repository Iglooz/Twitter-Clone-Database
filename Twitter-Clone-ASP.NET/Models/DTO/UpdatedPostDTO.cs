using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter_Clone_ASP.NET.Models.DTO
{
    public class UpdatedPostDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int Likes { get; set; }
        public int Shares { get; set; }

    }
}
