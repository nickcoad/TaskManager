using System;
using System.Collections.Generic;
using TaskManager.Common;
using TaskManager.Entities.Interfaces;

namespace TaskManager.Entities
{
    public class ChecklistItem : EntityBase, IHasTimeStamps
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

        public string ChecklistId { get; set; }
        public virtual Checklist Checklist { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        #endregion
    }
}
