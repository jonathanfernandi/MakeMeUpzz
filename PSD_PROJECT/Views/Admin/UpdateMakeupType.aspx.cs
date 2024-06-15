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
    public partial class UpdateMakeupType : System.Web.UI.Page
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
                    MakeupType makeuptype = ManageMakeupController.FindMakeupTypeByID(UpdateID);
                    if (!IsPostBack)
                    {
                        if (passingid != null)
                        {
                           MakeupTypeNameTxt.Text = makeuptype.MakeupTypeName;
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

        protected void UpdateMakeupTypeBtn_Click(object sender, EventArgs e)
        {
            String passingid = Request.QueryString["id"];
            int UpdateID = Convert.ToInt32(passingid);
            MakeupType makeuptype = new MakeupType();
            makeuptype.MakeupTypeID = UpdateID;
            makeuptype.MakeupTypeName = MakeupTypeNameTxt.Text;
            error.Text = ManageMakeupController.doUpdateMakeupType(makeuptype);
            if (error.Text.Equals(""))
            {
                Response.Redirect("~/Views/Admin/ManageMakeup.aspx");
            }
        }

        protected void BackManageMakeup_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/ManageMakeup.aspx");
        }

    }
}