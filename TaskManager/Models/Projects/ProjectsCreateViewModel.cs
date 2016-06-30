using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Entities;

namespace TaskManager.Models.Projects
{
    public class ProjectsCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}