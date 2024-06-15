using PSD_PROJECT.Controllers;
using PSD_PROJECT.Models;
using PSD_PROJECT.Repositories;
using PSD_PROJECT.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Views
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ListCustomerGridView.Visible = false;
            CustomerHome.Visible = false;
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
                }else
                {
                    user= (User) Session["user"];
                }

                if(user != null)
                {
                    if (user.UserRole.Equals("Admin"))
                    {
                        ListCustomerGridView.Visible = true;
                        List<User> ListUser = HomeController.ListCustomer();
                        ListCustomerGridView.DataSource = ListUser;
                        ListCustomerGridView.DataBind();
                    }
                    else
                    {

                        CustomerHome.Visible = true;
                        UsernameTxt.Text = user.Username;
                        RoleTxt.Text = user.UserRole;
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
            }
        }
    }
}