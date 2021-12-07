using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Http;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public abstract class BaseController : ApiController
    {
        public BaseController()
        {
            SettingsContext = new ContextController();
        }

        protected ContextController SettingsContext { get; set; }

        protected override void Dispose(bool disposing)
        {
            SettingsContext.Dispose();
            base.Dispose(disposing);
        }
    }
}