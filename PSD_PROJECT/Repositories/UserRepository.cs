using PSD_PROJECT.Factories;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Repositories
{
    public class UserRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static int generateID()
        {
            int newID = 1;
            int lastID = db.Users.OrderByDescending(x => x.UserID).Select(x => x.UserID).FirstOrDefault();

            if (lastID == null)
            {
                return newID;
            }
            else
            {
                lastID++;
            }
            return lastID;
        }

        public static void InsertUser(User userInput)
        {
            int id = generateID();
            userInput.UserID = id;
            User user = UserFactory.CreateUser(userInput);
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static User LoginUser(User userInput)
        {
            return (from users in db.Users where users.Username == userInput.Username && users.UserPassword == userInput.UserPassword select users).FirstOrDefault();
        }
       public static String FindbyUsername(string username)
        {
          return (from users in db.Users where users.Username == username select users.Username).FirstOrDefault();
        }

       public static User FindbyID(int id)
        {
            return (from x in db.Users where x.UserID == id select x).FirstOrDefault();
        }
        
        public static List<User> ListCustomer()
        {
            return (from users in db.Users where users.Username != "Admin" select users).ToList();
        }

        public static void UpdateUser(User userUpdate)
        {
            User user = UserRepository.FindbyID(userUpdate.UserID);
            user.Username = userUpdate.Username;
            user.UserEmail = userUpdate.UserEmail;
            user.UserGender = userUpdate.UserGender;
            user.UserDOB = userUpdate.UserDOB;
            db.SaveChanges();
        }

        public static void ChangePassword(int id, String userNewPassword)
        {
            User user = UserRepository.FindbyID(id);
            user.UserPassword = userNewPassword;
            db.SaveChanges();
            
        }

    }
}