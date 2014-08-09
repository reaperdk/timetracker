using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Model
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual IDbSet<UserProfile> UserProfiles { get; set; }
        public virtual IDbSet<webpages_Membership> webpages_Membership { get; set; }
        public virtual IDbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public virtual IDbSet<webpages_Roles> webpages_Roles { get; set; }

        public virtual IDbSet<TypeModel> TypeModel { get; set; }
    }
}
