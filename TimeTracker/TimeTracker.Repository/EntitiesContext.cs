﻿using System;
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
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual IDbSet<UserModel> UserProfiles { get; set; }
        public virtual IDbSet<MembershipModel> Memberships { get; set; }
        public virtual IDbSet<RoleModel> Roles { get; set; }

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

            modelBuilder.Entity<ProjectModel>()
                .HasMany(p => p.Users).WithMany(u => u.Projects)
                .Map(
                    association =>
                    {
                        association.MapLeftKey("ProjectId");
                        association.MapRightKey("UserId");
                        association.ToTable("UsersProjects");
                    }
                );
            modelBuilder.Entity<RoleModel>()
                .HasMany(r => r.UserProfiles).WithMany(u => u.webpages_Roles)
                .Map(
                    association =>
                    {
                        association.MapLeftKey("RoleId");
                        association.MapRightKey("UserId");
                        association.ToTable("webpages_UsersInRoles");
                    }
                );
        }
    }
}
