using PSD_PROJECT.Controllers;
using PSD_PROJECT.Handlers;
using PSD_PROJECT.Models;
using PSD_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Views.Customer
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    var id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                    user = LoginController.FindbyID(id);
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }
                
                if (user != null)
                {
                    if (!IsPostBack)
                    {
                        UsernameTxt.Text = user.Username;
                        EmailTxt.Text = user.UserEmail;
                        if (user.UserGender.Equals("Male"))
                        {
                            MaleBtn.Checked = true;
                        }
                        else
                        {
                            FemaleBtn.Checked = true;
                        }
                        DOBCalendar.SelectedDate = user.UserDOB;
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }   
            }
          
        }

        protected void UpdateProfileBtn_Click(object sender, EventArgs e)
        {

            User userSession;
            if (Session["user"] == null)
            {
                var id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                userSession = LoginController.FindbyID(id);
                Session["user"] = userSession;
            }
            else
            {
                userSession = (User)Session["user"];
            }
            int userID = userSession.UserID;
            User userOld = ProfileController.CustomerData(userID);
            User user = new User();
            user.UserID = userID;
            user.Username = UsernameTxt.Text;
            user.UserEmail = EmailTxt.Text;
            if (MaleBtn.Checked)
            {
                user.UserGender = "Male";
            }
            else
            {
                user.UserGender = "Female";
            }
            user.UserDOB = DOBCalendar.SelectedDate;
            errorLbl.Text= ProfileController.doUpdate(user,userOld);
           
            if (errorLbl.Text.Equals(""))
            {
                Response.Redirect("~/Views/Profile.aspx");
            }
        }

        protected void ChangePasswordBtn_Click(object sender, EventArgs e)
        {
            User user;
            if (Session["user"] == null)
            {
                var id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                user = LoginController.FindbyID(id);
                Session["user"] = user;
            }
            else
            {
                user = (User)Session["user"];
            }
            String userOldPassword = OldPasswordTxt.Text;
            String userNewPassword = NewPasswordTxt.Text;
            errorPasswordLbl.Text = ProfileController.ChangePassword(user.UserID, userOldPassword,userNewPassword);
            if (errorPasswordLbl.Text.Equals(""))
            {
                Response.Redirect("~/Views/Profile.aspx");
            }
        }
    }
}