using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager.Data.EntityMaps
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            Property(te => te.GivenName).HasMaxLength(50).IsRequired();
            Property(te => te.Surname).HasMaxLength(50).IsRequired();
            Property(te => te.CreatedAt).IsRequired();
            Property(te => te.UpdatedAt).IsRequired();

            HasMany(user => user.Projects)
                .WithRequired(project => project.User);

            HasMany(user => user.Checklists)
                .WithRequired(checklist => checklist.User);

            HasMany(user => user.ChecklistItems)
                .WithRequired(checklistItem => checklistItem.User);

            HasMany(user => user.Teams)
                .WithMany(team => team.Users);
        }
    }
}
