using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskManager.Entities.Interfaces;

namespace TaskManager.Entities
{
    public class User : IdentityUser, IHasTimeStamps
    {
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Checklist> Checklists { get; set; }
        public virtual ICollection<ChecklistItem> ChecklistItems { get; set; }
        public virtual ICollection<Team> Teams { get; set; }

        public string GivenName { get; set; }
        public string Surname { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
