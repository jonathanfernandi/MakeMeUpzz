using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Factories
{
    public class UserFactory
    {
        public static User CreateUser(User userInput)
        {
            User user = new User();
            user.UserID = userInput.UserID;
            user.Username = userInput.Username;
            user.UserEmail = userInput.UserEmail;
            user.UserPassword = userInput.UserPassword;
            user.UserRole = "Customer";
            user.UserDOB = userInput.UserDOB;
            user.UserGender = userInput.UserGender;
            return user;
        }
    }
}