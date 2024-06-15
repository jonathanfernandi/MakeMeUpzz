using PSD_PROJECT.Controllers;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Layouts
{
    public partial class AdminMaster : System.Web.UI.MasterPage
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
                    if (user.UserRole.Equals("Admin"))
                    {
                        OrderMakeupPage.Visible = false;
                        HistoryPage.Visible = false;
                    }
                    else
                    {
                        HomePage.Visible = false;
                        ManageMakeupPage.Visible = false;
                        OrderQueuePage.Visible = false;
                        TransactionReportPage.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
            }
        }

        protected void HomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/Home.aspx?");
        }

        protected void OrderMakeupPage_Click(object sender, EventArgs e)
        { 
           
            Response.Redirect("~/Views/Customer/OrderMakeup.aspx");
        }

        protected void HistoryPage_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Views/Customer/History.aspx");
        }

        protected void ManageMakeupPage_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Views/Admin/ManageMakeup.aspx");
        }

        protected void OrderQueuePage_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Views/Admin/OrderQueue.aspx");
        }

        protected void ProfilePage_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Views/Profile.aspx");
        }

        protected void TransactionReportPage_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Views/Admin/TransactionReport.aspx");
        }

        protected void LogoutPage_Click(object sender, EventArgs e)
        {
            string[] cookies = Request.Cookies.AllKeys;

            foreach(string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Remove("user");
            Response.Redirect("~/Views/Login.aspx");
            
        }
    }
}