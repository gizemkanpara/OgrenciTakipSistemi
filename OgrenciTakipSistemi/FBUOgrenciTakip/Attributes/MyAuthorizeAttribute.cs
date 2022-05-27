using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBUOgrenciTakip.Attributes
{
    public class MyAuthorizeAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var loggedUSer = context.HttpContext.Session.GetString("username");
            //if (String.IsNullOrWhiteSpace(loggedUSer))
            //{
            //    string ct = context.HttpContext.Request.RouteValues["controller"].ToString();
            //    string ac = context.HttpContext.Request.RouteValues["action"].ToString();
            //    context.Result = new RedirectToActionResult("Login", "Home", new { cnt = ct, act = ac });
            //}
              
        }
    }
}
