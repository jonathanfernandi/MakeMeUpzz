using PSD_PROJECT.Handlers;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_PROJECT.Controllers
{
    public class HomeController
    {
        public static List<User> ListCustomer()
        {
            return AdminHandler.ListCustomer();
        } 
    }
}