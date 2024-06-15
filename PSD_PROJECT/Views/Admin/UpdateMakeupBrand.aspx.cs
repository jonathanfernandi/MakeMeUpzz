using PSD_PROJECT.Controllers;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Views.Admin
{
    public partial class UpdateMakeupBrand : System.Web.UI.Page
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

                    String passingid = Request.QueryString["id"];
                    int UpdateID = Convert.ToInt32(passingid);
                    MakeupBrand makeupbrand = ManageMakeupController.FindMakeupBrandByID(UpdateID);
                    if (!IsPostBack)
                    {
                        if (passingid != null)
                        {
                            MakeupBrandNameTxt.Text = makeupbrand.MakeupBrandName;
                            MakeupBrandRatingTxt.Text = Convert.ToString(makeupbrand.MakeupBrandRating);
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

        protected void UpdateMakeupBrandBtn_Click(object sender, EventArgs e)
        {
            String passingid = Request.QueryString["id"];
            int UpdateID = Convert.ToInt32(passingid);
            MakeupBrand makeupbrand = new MakeupBrand();
            makeupbrand.MakeupBrandID = UpdateID;
            makeupbrand.MakeupBrandName = MakeupBrandNameTxt.Text;
            makeupbrand.MakeupBrandRating = Convert.ToInt32(MakeupBrandRatingTxt.Text);

            error.Text = ManageMakeupController.doUpdateMakeupBrand(makeupbrand);
            if (error.Text.Equals(""))
            {
                Response.Redirect("~/Views/Admin/ManageMakeup.aspx");
            }
        }
    }
}