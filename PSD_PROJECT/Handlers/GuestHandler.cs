using PSD_PROJECT.Models;
using PSD_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Handlers
{
    public class GuestHandler
    {
        public static void doRegister(User userInput)
        {
            UserRepository.InsertUser(userInput);
        }

        public static User doLogin(User userInput)
        {
            return UserRepository.LoginUser(userInput);
        }

        public static User FindbyID(int id)
        {
            return UserRepository.FindbyID(id);
        }
        
        public static String FindbyUsername(String username)
        {
            return UserRepository.FindbyUsername(username);
        }
        
        public static void ChangePassword(int id, String userNewPassword)
        {
            UserRepository.ChangePassword(id, userNewPassword);
        }
    }
}