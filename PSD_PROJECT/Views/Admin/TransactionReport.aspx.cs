using PSD_PROJECT.Controllers;
using PSD_PROJECT.Datasets;
using PSD_PROJECT.Handlers;
using PSD_PROJECT.Models;
using PSD_PROJECT.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Views.Admin
{
    public partial class TransactionReport : System.Web.UI.Page
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
                    if (user.Username.Equals("Admin") == false)
                    {
                        Response.Redirect("~/Views/Unauthorized.aspx");
                    }

                    CrystalReport report = new CrystalReport();
                    PSD_PROJECT.Datasets.DataSet data = getData(AdminHandler.GetTransactionHeaders());

                    if (data.Tables["Transactions"].Rows.Count > 0)
                    {
                        CalculateGrandTotals(data.Tables["Transactions"]);
                        report.SetDataSource(data);
                        CrystalReportViewer1.ReportSource = report;
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
            }
        }

        private void CalculateGrandTotals(DataTable transactionHeaders)
        {
            foreach (DataRow headerRow in transactionHeaders.Rows)
            {
                decimal grandTotal = CalculateGrandTotalForHeader(headerRow);
                headerRow["GrandTotal"] = grandTotal;
            }
        }

        private decimal CalculateGrandTotalForHeader(DataRow headerRow)
        {
            decimal grandTotal = 0;
            foreach (DataRow detailRow in headerRow.GetChildRows("Transactions_TransactionDetails"))
            {
                grandTotal += Convert.ToDecimal(detailRow["Subtotal"]);
            }
            return grandTotal;
        }

        private PSD_PROJECT.Datasets.DataSet getData(List<TransactionHeader> transactions)
        {
            PSD_PROJECT.Datasets.DataSet data = new PSD_PROJECT.Datasets.DataSet();
            var headertable = data.Transactions;
            var detailtable = data.TransactionDetails;

            foreach (TransactionHeader t in transactions)
            {
                var hrow = headertable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["CustomerName"] = t.User.Username;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["TransactionStatus"] = t.Status;
                headertable.Rows.Add(hrow);

                foreach (PSD_PROJECT.Models.TransactionDetail d in t.TransactionDetails)
                {
                    var drow = detailtable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["MakeupID"] = d.Makeup.MakeupID;
                    drow["MakeupName"] = d.Makeup.MakeupName;
                    drow["Quantity"] = d.Quantity;
                    drow["Price"] = d.Makeup.MakeupPrice;
                    drow["Subtotal"] = d.Quantity * d.Makeup.MakeupPrice;
                    detailtable.Rows.Add(drow);
                }
            }
            return data;
        }
    }
}