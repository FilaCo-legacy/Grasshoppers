using System.ComponentModel;

namespace Grasshoppers.Models
{
    public class EditUserModel
    {
        public string Id { get; set; }
        
        [DisplayName("Username")]
        public string UserName { get; set; }
        
    }
}