using PSD_PROJECT.Controllers;
using PSD_PROJECT.Models;
using PSD_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Views
{
    public partial class TransactionDetail : System.Web.UI.Page
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
                        string passingtransactiondetailID = Request.QueryString["ID"];
                        if (passingtransactiondetailID != null)
                        {
                            int transactionID = Convert.ToInt32(passingtransactiondetailID);

                            PSD_PROJECT.Models.TransactionDetail transactiondetail = TransactionDetailController.FindTransactionDetailbyID(transactionID);
                            TransactionIDTxt.Text = transactiondetail.TransactionID.ToString();
                            TransactionDateTxt.Text = transactiondetail.TransactionHeader.TransactionDate.ToString();
                            StatusTxt.Text = transactiondetail.TransactionHeader.Status;

                            UsernameTxt.Text = transactiondetail.TransactionHeader.User.Username;
                            EmailTxt.Text = transactiondetail.TransactionHeader.User.UserEmail;

                            MakeupNameTxt.Text = transactiondetail.Makeup.MakeupName;
                            MakeupPriceTxt.Text = transactiondetail.Makeup.MakeupPrice.ToString();
                            MakeupWeightTxt.Text = transactiondetail.Makeup.MakeupWeight.ToString();
                            MakeupTypeNameTxt.Text = transactiondetail.Makeup.MakeupType.MakeupTypeName;
                            MakeupBrandNameTxt.Text = transactiondetail.Makeup.MakeupBrand.MakeupBrandName;
                            MakeupBrandRatingTxt.Text = transactiondetail.Makeup.MakeupBrand.MakeupBrandRating.ToString();
                            QuantityTxt.Text = transactiondetail.Quantity.ToString();
                        }
                        else
                        {
                            if (user.Username.Equals("Admin"))
                            {
                                Response.Redirect("~/Views/Admin/OrderQueue.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/Views/Customer/History.aspx");
                            }
                        }
                    }

                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
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

            int userID = user.UserID;
            User userTransaction = LoginController.FindbyID(userID);
            
            if (userTransaction.Username.Equals("Admin")){
                Response.Redirect("~/Views/Admin/OrderQueue.aspx");
            }
            else
            {
                Response.Redirect("~/Views/Customer/History.aspx");
            }
        }
    }
}