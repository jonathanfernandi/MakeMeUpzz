using PSD_PROJECT.Controllers;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Views.Admin
{
    public partial class OrderQueue : System.Web.UI.Page
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
                    if (user.UserRole.Equals("Admin") == false)
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
                    List<TransactionHeader> transactionHeader = OrderQueueController.GetTransactionHeaderList();
                    TransactionHandleGridView.DataSource = transactionHeader;
                    TransactionHandleGridView.DataBind();

                    List<TransactionHeader> transactionHandled = OrderQueueController.GetTransactionHandledList();
                    AllTransactionGridView.DataSource = transactionHandled;
                    AllTransactionGridView.DataBind();
                }
            }

        }

        protected void HandleTransactionRow(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = TransactionHandleGridView.Rows[e.NewEditIndex];
            int transactionID = Convert.ToInt32(row.Cells[0].Text);
            OrderQueueController.HandleTransaction(transactionID);
            Response.Redirect("~/Views/Admin/OrderQueue.aspx");
        }

        protected void DetailTransactionRow(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = AllTransactionGridView.Rows[e.NewSelectedIndex];
            int transactionDetailID = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/TransactionDetail.aspx?ID="+transactionDetailID);
        }
    }
}