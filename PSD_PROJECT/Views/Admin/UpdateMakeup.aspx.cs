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
    public partial class UpdateMakeup : System.Web.UI.Page
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

                    String passingid= Request.QueryString["id"];
                    int UpdateID = Convert.ToInt32(passingid);
                    Makeup makeup = ManageMakeupController.FindMakeupByID(UpdateID);
                    if (!IsPostBack)
                    {
                        if(passingid != null)
                        {
                            MakeupNameTxt.Text = makeup.MakeupName;
                            MakeupPriceTxt.Text = Convert.ToString(makeup.MakeupPrice);
                            MakeupWeightTxt.Text = Convert.ToString(makeup.MakeupWeight);
                            MakeupTypeIDTxt.Text = Convert.ToString(makeup.MakeupTypeID);
                            MakeupBrandIDTxt.Text = Convert.ToString(makeup.MakeupBrandID);
                        }
                        else
                        {
                            Response.Redirect("~/Views/Admin/ManageMakeup.aspx");
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
            }
        }


        protected void BackManageMakeup_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/ManageMakeup.aspx");
        }

        protected void UpdateMakeupBtn_Click(object sender, EventArgs e)
        {
            String passingid = Request.QueryString["id"];
            int UpdateID = Convert.ToInt32(passingid);
            Makeup makeup = new Makeup();
            makeup.MakeupID = UpdateID;
            makeup.MakeupName = MakeupNameTxt.Text;
            makeup.MakeupPrice = Convert.ToInt32(MakeupPriceTxt.Text);
            makeup.MakeupWeight = Convert.ToInt32(MakeupWeightTxt.Text);
            makeup.MakeupTypeID = Convert.ToInt32(MakeupTypeIDTxt.Text);
            makeup.MakeupBrandID = Convert.ToInt32(MakeupBrandIDTxt.Text);

            error.Text = ManageMakeupController.doUpdateMakeup(makeup);
            if (error.Text.Equals(""))
            {
                Response.Redirect("~/Views/Admin/ManageMakeup.aspx");
            }
        }

    }
}