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
        public string _name { get; set; }
        public DateTime _date { get; set; }
        public string _operacao { get; set; }
        /*private void Log(RouteData routedata)
        {
            var nome = routedata.Values["controller"];
            var actioname = routedata.Values["action"];

            Debug.WriteLine("Data e hora: {0}\nUsuário: {1}\nOperação realizada: {2}", _date, _name, _operacao);
        }*/
        /*public DateActionFilter()
        {
           _name = _dbContext.Name;
            _operacao = _dbContext.Operacao;
            _id = _dbContext.Id;
            _date = _dbContext.Dataatualizacao;
        }*
        /*public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("Data e hora: {0}\nUsuário: {1}\nOperação realizada: {3}", DateTime.Now.ToLongTimeString(), filterContext.HttpContext.User.Identity.Name,
            filterContext.ActionDescriptor.ActionName);
            //base.OnActionExecuting(filterContext); ;
        }*/
        
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string _date_time;
            base.OnActionExecuted(filterContext);
            _name = filterContext.Controller.ValueProvider.GetValue("director").AttemptedValue;
            _operacao = filterContext.ActionDescriptor.ActionName;
            _date_time = filterContext.Controller.ValueProvider.GetValue("releaseDate").AttemptedValue;
            _date = Convert.ToDateTime(_date_time);
            MovieDBContext log_data = new MovieDBContext();
            Log log_data_log = new Log();
            log_data_log.Name = _name;
            log_data_log.Dataatualizacao = _date;
            log_data_log.Operacao = _operacao;
            log_data.Logs.Add(log_data_log);
            //_name = filterContext.ActionDescriptor.ActionName;
            Debug.WriteLine("Data e hora: {0}\nUsuário: {1}\nOperação realizada: {2}", _date, _name, _operacao);
            //var controllerUsingThisAttribute = ((MovieController)filterContext.Controller);
            /*Debug.WriteLine("Data e hora: {0}\nUsuário: {1}\nOperação realizada: {3}", DateTime.Now.ToLongTimeString(), filterContext.HttpContext.User.Identity.Name,
            filterContext.ActionDescriptor.ActionName);*/
            //base.OnActionExecuted(filterContext);
        }
    }
}