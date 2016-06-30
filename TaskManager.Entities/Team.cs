using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities.Interfaces;

namespace TaskManager.Entities
{
    public class Team : EntityBase, IHasTimeStamps
    {
        #region Metadata

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        #endregion


        #region Auditing

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion


        #region Relationships

        public virtual ICollection<User> Users { get; set; }

        #endregion
    }
}
