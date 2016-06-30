using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models.Projects;

namespace TaskManager.Controllers
{
    public class ProjectsController : BaseController
    {
        // GET: Projects
        public ActionResult Index()
        {
            var projects = Context.Projects.OrderBy(pr => pr.CreatedAt).ToList();
            var viewModel = new ProjectsIndexViewModel
            {
                Projects = projects
            };
            return View(viewModel);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            var viewModel = new ProjectsCreateViewModel();
            return View(viewModel);
        }
    }
}