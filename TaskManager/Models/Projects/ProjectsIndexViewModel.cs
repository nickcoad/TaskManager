using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Entities;

namespace TaskManager.Models.Projects
{
    public class ProjectsIndexViewModel
    {
        public List<Project> Projects { get; set; }
    }
}