using System;
using System.Collections.Generic;

namespace TimeTracker.Model
{
    public class UserProfile : IModelBase
    {
        public UserProfile()
        {
            this.webpages_OAuthMembership = new HashSet<webpages_OAuthMembership>();
            this.webpages_Roles = new HashSet<webpages_Roles>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public virtual webpages_Membership webpages_Membership { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}