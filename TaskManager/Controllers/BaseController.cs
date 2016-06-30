using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Data;

namespace TaskManager.Controllers
{
    public class BaseController : Controller
    {
        protected readonly TaskManagerContext Context;

        public BaseController()
        {
            Context = new TaskManagerContext();
        }
    }
}