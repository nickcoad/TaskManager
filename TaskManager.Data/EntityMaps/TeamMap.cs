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
    public class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
        {
            HasKey(x => x.Id);

            Property(te => te.Name).HasMaxLength(100).IsRequired();
            Property(te => te.Description).IsMaxLength().IsRequired();
            Property(te => te.IsActive).IsRequired();
            Property(te => te.CreatedAt).IsRequired();
            Property(te => te.UpdatedAt).IsRequired();

            HasMany(te => te.Users)
                .WithMany(us => us.Teams);
        }
    }
}
