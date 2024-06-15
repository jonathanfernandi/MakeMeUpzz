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
    public partial class InsertMakeup : System.Web.UI.Page
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
                        Response.Redirect("~/Views/Admin/Home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
            }
        }

        protected void InsertMakeupBtn_Click(object sender, EventArgs e)
        {
            if(ManageMakeupController.checkInputMakeup(MakeupNameTxt,MakeupPriceTxt,MakeupWeightTxt,MakeupTypeIDTxt,MakeupBrandIDTxt) == true)
            {
                Makeup makeup = new Makeup();
                makeup.MakeupName = MakeupNameTxt.Text;
                makeup.MakeupPrice = Convert.ToInt32(MakeupPriceTxt.Text.ToString());
                makeup.MakeupWeight = Convert.ToInt32(MakeupWeightTxt.Text.ToString());
                makeup.MakeupTypeID = Convert.ToInt32(MakeupTypeIDTxt.Text.ToString());
                makeup.MakeupBrandID = Convert.ToInt32(MakeupBrandIDTxt.Text.ToString());

                error.Text = ManageMakeupController.doInsertMakeup(makeup);
                if (error.Text.Equals(""))
                {
                    Response.Redirect("~/Views/Admin/ManageMakeup.aspx");
                }
            }
            else
            {
                error.Text = "Input Cannot be Empty";
            }
        }

        protected void BackManageMakeup_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/ManageMakeup.aspx");
        }
    }
}