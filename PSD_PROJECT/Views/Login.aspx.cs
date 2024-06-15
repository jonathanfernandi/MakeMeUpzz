using PSD_PROJECT.Controllers;
using PSD_PROJECT.Models;
using PSD_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null || Session["user"] != null)
            {
                Response.Redirect("~/Views/Admin/Home.aspx");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {;
            String username = UsernameTxt.Text;
            String password = PasswordTxt.Text;
            Boolean isRememberMe = RememberMeCheckBox.Checked;

            User userInput = new User();
            userInput.Username = username;
            userInput.UserPassword = password;
            error.Text = LoginController.doLogin(userInput);

            User userLogin = LoginController.UserSession(userInput);

            if(userLogin!= null)
            {
                Session["user"] = userLogin;

                if (isRememberMe)
                {
                    HttpCookie cookie = LoginController.UserCookies(userLogin);
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("~/Views/Admin/Home.aspx");
            }

        }
    }
}