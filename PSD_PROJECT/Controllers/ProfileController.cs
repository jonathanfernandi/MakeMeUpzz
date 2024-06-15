using PSD_PROJECT.Handlers;
using PSD_PROJECT.Models;
using PSD_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PSD_PROJECT.Controllers
{
    public class ProfileController
    {
        public static User CustomerData(int id)
        {
            return CustomerHandler.CustomerData(id);
        }

        public static String CheckUsername(User userInput,User userOld)
        {
            String response = "";
            if (userInput.Username.Equals(""))
            {
                response = "Username cannot be empty";
            }
            else if (userInput.Username.Length < 5 || userInput.Username.Length > 15)
            {
                response = "Username length must be between 5 and 15 alphabet";
            }
            else
            {
                if (CustomerHandler.FindbyUsername(userInput.Username) != null && userInput.Username.Equals(userOld.Username) == false)
                {
                    response = "Username must be unique.";
                }
            }
            return response;
        }

        public static String CheckEmail(User userInput)
        {
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

        public static String CheckDate(User userInput)
        {
            String response = "";
            if (userInput.UserDOB == default(DateTime))
            {
                response = "Date cannot be empty";
            }
            return response;
        }

        public static String doUpdate(User userInput,User userOld)
        {

            String response = CheckUsername(userInput,userOld);
            if (response.Equals(""))
            {
                response = CheckEmail(userInput);
            }
            if (response.Equals(""))
            {
                response = CheckGender(userInput);
            }
            if (response.Equals(""))
            {
                response = CheckDate(userInput);
            }
            if (response.Equals(""))
            {
                CustomerHandler.UpdateCustomerData(userInput);
            }
            return response;
        }

        public static String CheckOldPassword(int id, String userOldPassword)
        {
            User user = GuestHandler.FindbyID(id);
            String response = "";
            if (!user.UserPassword.Equals(userOldPassword)){
                response = "Wrong Password";
            }
            return response;
        }

        public static String CheckNewPassword(String userNewPassword)
        {
            String response = "";

            if (userNewPassword.Equals(""))
            {
                response = "Password cannot be empty";
            }
            return response;
        }

        public static String ChangePassword(int id, String userOldPassword, String userNewPassword)
        {
            String response = CheckOldPassword(id, userOldPassword);
            if (response.Equals(""))
            {
                response = CheckNewPassword(userNewPassword);
            }
            if (response.Equals(""))
            {
                GuestHandler.ChangePassword(id, userNewPassword);   
            }
            return response;
        }
    }
}