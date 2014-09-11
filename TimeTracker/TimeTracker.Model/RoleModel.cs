using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Model
{
    [Table("webpages_Roles")]
    public class RoleModel
    {
        public RoleModel()
        {
            this.UserProfiles = new HashSet<UserModel>();
        }
    
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    
        public virtual ICollection<UserModel> UserProfiles { get; set; }
    }
}
