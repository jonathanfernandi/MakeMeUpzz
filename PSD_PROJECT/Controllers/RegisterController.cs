using PSD_PROJECT.Handlers;
using PSD_PROJECT.Models;
using PSD_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace PSD_PROJECT.Controllers
{
    public class RegisterController
    {

        public static String CheckUsername(User userInput)
        {
            String response = "";
            if(userInput.Username.Equals(""))
            {
                response = "Username cannot be empty";
            }
            else if (userInput.Username.Length <5 || userInput.Username.Length >15)
            {
                response = "Username length must be between 5 and 15 alphabet";
            }
            else
            {
                if (CustomerHandler.FindbyUsername(userInput.Username) != null)
                {
                    response = "Username must be unique.";
                }
            }
            return response;
        }
        public static String CheckEmail(User userInput) {
            String response = "";

            if (userInput.UserEmail.Equals(""))
            {
                response = "Email cannot be empty.";
            }
            else if (!userInput.UserEmail.Contains(".com"))
            {
                response = "Must end with .com";
            }
            return response;
        }

        public static String CheckGender(User userInput)
        {
            String response = "";
            if (userInput.UserGender.Equals(""))
            {
                response = "Gender Must be chosen and cannot be empty.";
            }
            return response;
        }

        public static String CheckPassword(User userInput, String passwordConfirmation)
        {
            
            String response = "";

            if(userInput.UserPassword.Equals(""))
            {
                response = "Password cannot be empty";
            }

            else if(userInput.UserPassword != passwordConfirmation)
            {
                response = "Password must be the same with confirm password";
            }
            return response;
        }

        public static String CheckConfirmationPassword(User userInput, String passwordConfirmation)
        {
            String response = "";
            if (passwordConfirmation.Equals(""))
            {
                response = "Confirmation Password cannot be empty";
            }
            else if (userInput.UserPassword != passwordConfirmation)
            {
                response = "Confirmation Password must be the same with password";
            }
            return response;
        }

        public static String CheckDate(User userInput)
        {
            String response = "";
            if (userInput.UserDOB == default(DateTime))
            {
                response = "Date cannot be empty";
            }
            return response;
        }

        public static String doRegister(User userInput,String passwordConfirmation) { 
        
            String response = CheckUsername(userInput);
            if(response.Equals(""))
            {
                response = CheckEmail(userInput);
            }
            if (response.Equals(""))
            {
                response = CheckGender(userInput);
            }
            if (response.Equals(""))
            {
                response = CheckPassword(userInput,passwordConfirmation);
            }
            if (response.Equals(""))
            {
                response = CheckConfirmationPassword(userInput,passwordConfirmation);
            }
            if (response.Equals(""))
            {
                response = CheckDate(userInput);
            }
            if (response.Equals(""))
            {
                GuestHandler.doRegister(userInput);
            }
            return response;
        }
    }
}