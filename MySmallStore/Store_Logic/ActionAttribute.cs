using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySmallStore.DAL;
using MySmallStore.Models;
using System.Web.Mvc;

namespace MySmallStore.Store_Logic
{
    public class ActionAttribute : FilterAttribute, IActionFilter
    {
        StoreContext db = new StoreContext();
        Log log = new Log();

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var date = DateTime.Now;
            var route = filterContext.RouteData.Values["controller"] + "/" + filterContext.RouteData.Values["action"];

            log.LogDateTime = date;
            log.LogText = route;

            db.Logs.Add(log);
            db.SaveChanges();
        }
    }
}