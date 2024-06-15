using PSD_PROJECT.Controllers;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Views.Customer
{
    public partial class OrderMakeup : System.Web.UI.Page
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
                    if (user.Username.Equals("Admin"))
                    {
                        Response.Redirect("~/Views/Admin/Home.aspx");
                    }
                    if (!IsPostBack)
                    {
                        List<Makeup> makeup = ManageMakeupController.ListMakeup();
                        MakeupGridView.DataSource = makeup;
                        MakeupGridView.DataBind();

                        List<Cart> cart = OrderMakeupController.ListCart(user.UserID);
                        CartGridView.DataSource = cart;
                        CartGridView.DataBind();
                    }

                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
            }



        }

        protected void OrderMakeupRow(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = MakeupGridView.Rows[e.NewSelectedIndex];
            TextBox txtQuantity = (TextBox)row.FindControl("MakeupQuantityOrder");
            Makeup makeup = new Makeup();
            makeup.MakeupName = row.Cells[0].Text;
            MakeupType makeuptype = new MakeupType();
            makeuptype.MakeupTypeName= row.Cells[3].Text;
            MakeupBrand makeupbrand = new MakeupBrand();
            makeupbrand.MakeupBrandName= row.Cells[4].Text;
            
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
         

            int userId = user.UserID;
            OrderMakeupController.doOrderCart(txtQuantity, makeup, makeuptype, makeupbrand, userId);
            Response.Redirect("~/Views/Customer/OrderMakeup.aspx");
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
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
            int userId = user.UserID;
            OrderMakeupController.doDeleteCart(userId);
            Response.Redirect("~/Views/Customer/OrderMakeup.aspx");
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
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
            int userId = user.UserID;
            OrderMakeupController.doCheckOut(userId);
            Response.Redirect("~/Views/Customer/OrderMakeup.aspx");
        }
    }
}