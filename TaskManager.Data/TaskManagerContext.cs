using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskManager.Data.EntityMaps;
using TaskManager.Data.Seeders;
using TaskManager.Entities;
using TaskManager.Entities.Interfaces;

namespace TaskManager.Data
{
    public class TaskManagerContext : IdentityDbContext
    {
        public TaskManagerContext()
            : base("TaskManagerConnection")
        {
            Database.SetInitializer(new DefaultInitialiser());

            Database.Log = s => Debug.WriteLine(s);
        }

        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }

        public static TaskManagerContext Create()
        {
            return new TaskManagerContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ChecklistItemMap());
            modelBuilder.Configurations.Add(new ChecklistMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new TeamMap());
            modelBuilder.Configurations.Add(new UserMap());
        }

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;

            foreach (var entry in (this as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {
                if (entry.IsRelationship) continue;

                var record = entry.Entity as IHasTimeStamps;

                if (record == null) continue;

                if (entry.State == EntityState.Added)
                    record.CreatedAt = now;

                record.UpdatedAt = now;
            }

            return base.SaveChanges();
        }
    }
}
