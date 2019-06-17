using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Grasshoppers.Areas.Administration.Models
{
    public class EditUserModel
    {
        public string Id { get; set; }
        
        [DisplayName("Username")]
        public string UserName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}