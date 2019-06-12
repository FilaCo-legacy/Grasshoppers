using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Grasshoppers.Data
{
    public class User : IdentityUser
    {
        public ICollection<Character> Characters { get; set; }

        public User()
        {
            Characters = new List<Character>();
        }
    }
}