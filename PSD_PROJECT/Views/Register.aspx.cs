using PSD_PROJECT.Controllers;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            User userInput = new User();
            userInput.Username = UsernameTxt.Text;
            userInput.UserEmail = EmailTxt.Text;
            if (MaleBtn.Checked == true)
            {
                userInput.UserGender = "Male";
            }
            else if(FemaleBtn.Checked == true)
            {
                userInput.UserGender = "Female";
            }
            else if(!FemaleBtn.Checked && !MaleBtn.Checked )
            {
                userInput.UserGender = "";
            }
            
            userInput.UserPassword = PasswordTxt.Text;
            string passwordConfirmation = ConfirmationPasswordTxt.Text;
            userInput.UserDOB = DOBcalendar.SelectedDate;
            
            errorLbl.Text= RegisterController.doRegister(userInput, passwordConfirmation);
            if (errorLbl.Text.Equals("")){
                Response.Redirect("~/Views/Login.aspx");
            }
        }
    }
}