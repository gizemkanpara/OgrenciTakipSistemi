using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBUFirstApi.Controllers
{

    public abstract class BaseApiController : ControllerBase
    {
        protected int UserID
        {
            get { return int.Parse(Request.HttpContext.User.Claims.First(c => c.Type == "userId").Value); }
        }
        protected int GetUserId()
        {
            return int.Parse(Request.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
        }
    }
}
