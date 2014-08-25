using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.Repository
{
    class EntitiesContext : DbContext
    {
        public EntitiesContext()
            : base("name=DefaultConnection")
        {
        }

        //public virtual IDbSet<UserProfile> UserProfiles { get; set; }
        //public virtual IDbSet<webpages_Membership> webpages_Membership { get; set; }
        //public virtual IDbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        //public virtual IDbSet<webpages_Roles> webpages_Roles { get; set; }

        public virtual IDbSet<UserModel> Users { get; set; }
        public virtual IDbSet<ProjectModel> Projects { get; set; }
        public virtual IDbSet<TaskModel> Tasks { get; set; }
        public virtual IDbSet<SlotModel> Slots { get; set; }
        public virtual IDbSet<CategoryModel> Categories { get; set; }
        public virtual IDbSet<StatusModel> Statuses { get; set; }
        public virtual IDbSet<PriorityModel> Priorities { get; set; }
        public virtual IDbSet<TypeModel> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>()
                .HasRequired(t => t.AssignedPerson)
                .WithMany(t => t.AssignedTasks)
                .HasForeignKey(m => m.AssignedPersonId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<TaskModel>()
                .HasRequired(t => t.AssigningPerson)
                .WithMany(t => t.AssigningTasks)
                .HasForeignKey(m => m.AssigningPersonId)
                .WillCascadeOnDelete(false);
        }
    }
}
