using PSD_PROJECT.Handlers;
using PSD_PROJECT.Models;
using PSD_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Caching;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Controllers
{
    public class LoginController
    {
        public static String CheckUsername(User userInput)
        {
            String response = "";
            if (userInput.Username.Equals(""))
            {
                response = "Must be filled";
            }
            return response;
        }

        public static String CheckPassword(User userInput)
        {
            String response = "";
            if (userInput.UserPassword.Equals(""))
            {
                response = "Must be filled";
            }
            return response;
        }

        public static String CheckUser(User userInput)
        {
            String response = "";
            if (GuestHandler.doLogin(userInput) == null)
            {
                response = "Invalid Credential";
            }
            return response;
        }
        public static String doLogin(User userInput)
        {
            String response = CheckUsername(userInput);
            if (response.Equals(""))
            {
                response = CheckPassword(userInput);
            }
            if (response.Equals(""))
            {
                response = CheckUser(userInput);
            }
            return response;
        }
        public static User FindbyID(int id)
        {
            return GuestHandler.FindbyID(id);
        }
        public static User UserSession(User userInput)
        {
            User user = GuestHandler.doLogin(userInput);
            return user;
        }
 
        public static HttpCookie UserCookies(User user)
        {
            HttpCookie cookie = new HttpCookie("user_cookie");
            cookie.Value = Convert.ToString(user.UserID);
            cookie.Expires = DateTime.Now.AddHours(1);
            return cookie;
        }


        

    }
}