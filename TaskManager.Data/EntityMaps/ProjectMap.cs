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
    public class ProjectMap : EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            HasKey(x => x.Id);

            Property(pr => pr.Name).HasMaxLength(100).IsRequired();
            Property(pr => pr.Description).IsMaxLength().IsRequired();
            Property(pr => pr.Status).IsRequired();
            Property(pr => pr.CreatedAt).IsRequired();
            Property(pr => pr.UpdatedAt).IsRequired();
            Property(pr => pr.UserId).IsRequired();

            HasMany(pr => pr.Checklists)
                .WithRequired(cl => cl.Project);

            HasRequired(pr => pr.User)
                .WithMany(us => us.Projects);
        }
    }
}
