using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTracker.Model
{
    [Table("UserProfile")]
    public class UserProfile
    {
        public UserProfile()
        {
            //this.webpages_OAuthMembership = new HashSet<webpages_OAuthMembership>();
            this.webpages_Roles = new HashSet<RoleModel>();
        }

        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        //public virtual ICollection<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public virtual MembershipModel webpages_Membership { get; set; }
        public virtual ICollection<RoleModel> webpages_Roles { get; set; }

        public virtual ICollection<ProjectModel> Projects { get; set; }
        public virtual ICollection<TaskModel> AssignedTasks { get; set; }
        public virtual ICollection<TaskModel> AssigningTasks { get; set; }
    }
}