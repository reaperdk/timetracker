using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Model
{
    [Table("webpages_OAuthMembership")]
    public class OAuthMembershipModel
    {
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public int UserId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
