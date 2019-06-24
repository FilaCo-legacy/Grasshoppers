using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Grasshoppers.Areas.Administration.Models
{
    public class EditUserModel
    {
        public ICollection<string> UserIds { get; set; }
        
        [DisplayName("Username")]
        public string UserName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public IDictionary<string, CheckboxState> UsersRoles { get; set; }

        public EditUserModel()
        {
            UserIds = new List<string>();
            UsersRoles = new SortedDictionary<string, CheckboxState>();
        }
    }
}