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
    public partial class History : System.Web.UI.Page
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
                    if (user.UserRole.Equals("Admin") == true)
                    {
                        Response.Redirect("~/Views/Admin/Home.aspx");
                    }

                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
                if (!IsPostBack)
                {
                    List<PSD_PROJECT.Models.TransactionDetail> customerTransaction = HistoryController.GetCustomerTransactionList();
                    CustomerTransactionGridView.DataSource = customerTransaction;
                    CustomerTransactionGridView.DataBind();
                }
            }
        }

        protected void DetailCustomerTransactionRow(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = CustomerTransactionGridView.Rows[e.NewSelectedIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/TransactionDetail.aspx?ID=" + id);
        }
    }
}