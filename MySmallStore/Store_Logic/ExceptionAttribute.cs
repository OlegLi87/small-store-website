using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using MySmallStore.DAL;
using MySmallStore.Models;

namespace MySmallStore.Store_Logic
{
    public class ExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        StoreContext db = new StoreContext();
        Log log = new Log();

        public void OnException(ExceptionContext filterContext)
        {
            var date = DateTime.Now;
            var exception = filterContext.Exception.Message;

            log.LogDateTime = date;
            log.LogText = "Error / " + exception;

            db.Logs.Add(log);
            db.SaveChanges();
        }
    }
}