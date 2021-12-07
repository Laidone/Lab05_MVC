using MvcMovie.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcMovie.Models
{
    public class DateActionFilter : ActionFilterAttribute, IActionFilter
    {
        public int _Id { get; set; }
        
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            MovieDBContext log_data_DBContext = new MovieDBContext();
            Log log_data = new Log();
            log_data.Dataatualizacao = DateTime.Now;
            log_data.Name = filterContext.HttpContext.User.Identity.Name;
            log_data.Operacao = filterContext.ActionDescriptor.ActionName;
            log_data_DBContext.Logs.Add(log_data);
            log_data_DBContext.SaveChanges();
        }
    }
}