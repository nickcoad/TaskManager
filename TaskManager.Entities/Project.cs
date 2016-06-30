using System;
using System.Collections.Generic;
using TaskManager.Common;
using TaskManager.Entities.Interfaces;

namespace TaskManager.Entities
{
    public class Project : EntityBase, IHasTimeStamps
    {
        #region Metadata

        public string Name { get; set; }
        public string Description { get; set; }
        public Constants.Status Status { get; set; }

        #endregion


        #region Auditing

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion


        #region Relationships

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Checklist> Checklists { get; set; } 

        #endregion


    }
}
