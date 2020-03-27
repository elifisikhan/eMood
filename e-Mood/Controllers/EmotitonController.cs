using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace e_Mood.Controllers
{
    public class EmotitonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}