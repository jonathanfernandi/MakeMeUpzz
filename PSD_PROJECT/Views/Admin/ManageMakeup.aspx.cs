using PSD_PROJECT.Controllers;
using PSD_PROJECT.Models;
using PSD_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Views
{
    public partial class ManageMakeup : System.Web.UI.Page
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
                    if (user.UserRole.Equals("Admin")==false)
                    {
                        Response.Redirect("~/Views/Admin/Home.aspx");
                    }
                    
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
            }

            if (!IsPostBack)
            {
                List<Makeup> makeup = ManageMakeupController.ListMakeup();
                MakeupGridView.DataSource = makeup;
                MakeupGridView.DataBind();

                List<MakeupType> makeupType = ManageMakeupController.ListMakeupType();
                MakeupTypeGridView.DataSource = makeupType;
                MakeupTypeGridView.DataBind();

                List<MakeupBrand> makeupBrand = ManageMakeupController.ListMakeupBrand();
                MakeupBrandGridView.DataSource = makeupBrand;
                MakeupBrandGridView.DataBind();
            }
        }

        protected void InsertMakeup_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/InsertMakeup.aspx");
        }

        protected void InsertMakeupType_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/InsertMakeupType.aspx");
        }

        protected void InsertMakeupbrand_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/InsertMakeupBrand.aspx");
        }

        protected void UpdateMakeupRow(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupGridView.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());
            Response.Redirect("~/Views/Admin/UpdateMakeup.aspx?ID=" + id);
        }

        protected void DeleteMakeupRow(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupGridView.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());
            ManageMakeupController.doDeleteMakeup(id);
            Response.Redirect("~/Views/Admin/ManageMakeup.aspx");
        }

        protected void UpdateMakeupTypeRow(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupTypeGridView.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());
            Response.Redirect("~/Views/Admin/UpdateMakeupType.aspx?ID=" + id);
        }

        protected void UpdateMakeupBrandRow(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupBrandGridView.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());
            Response.Redirect("~/Views/Admin/UpdateMakeupBrand.aspx?ID=" + id);
        }
    }
}