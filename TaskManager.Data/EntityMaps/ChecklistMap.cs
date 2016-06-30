using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TaskManager.Entities;

namespace TaskManager.Data.EntityMaps
{
    public class ChecklistMap : EntityTypeConfiguration<Checklist>
    {
        public ChecklistMap()
        {
            HasKey(x => x.Id);

            Property(cl => cl.Name).HasMaxLength(100).IsRequired();
            Property(cl => cl.Description).IsMaxLength().IsRequired();
            Property(cl => cl.Status).IsRequired();
            Property(cl => cl.UserId).IsRequired();
            Property(cl => cl.ProjectId).IsRequired();
            Property(cl => cl.CreatedAt).IsRequired();
            Property(cl => cl.UpdatedAt).IsRequired();
                
            HasMany(cl => cl.Items)
                .WithRequired(cli => cli.Checklist);

            HasRequired(cl => cl.User)
                .WithMany(us => us.Checklists);

            HasRequired(cl => cl.Project)
                .WithMany(pr => pr.Checklists);
        }
    }
}
