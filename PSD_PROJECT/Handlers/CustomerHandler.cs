using PSD_PROJECT.Models;
using PSD_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace PSD_PROJECT.Handlers
{
    public class CustomerHandler
    {   
        public static User CustomerData(int id)
        {
            User user = UserRepository.FindbyID(id);
            return user;
        }

        public static void UpdateCustomerData(User userUpdate)
        {
            UserRepository.UpdateUser(userUpdate);
        }

        public static String FindbyUsername(string username)
        {
            return UserRepository.FindbyUsername(username);
        }
        public static Makeup FindMakeupbyNameTypeBrand(Makeup makeup,MakeupType makeuptype, MakeupBrand makeupbrand)
        {
            return MakeupRepository.FindMakeupbyNameTypeBrand(makeup,makeuptype,makeupbrand);
        }
        public static void InsertOrderToCart(Cart cart)
        {
            TransactionRepository.InsertOrderToCart(cart);
        }
        public static List<Cart> ListCart(int id )
        {
            return TransactionRepository.GetCartList(id);
        }
        public static void DeleteCart(int userID)
        {
            TransactionRepository.DeleteCart(userID);
        }
        public static void CheckOut(int userID)
        {
            TransactionRepository.CheckoutTransaction(userID);
        }
        public static List<TransactionDetail> GetCustomerTransactionList()
        {
            return TransactionRepository.GetCustomerTransactionList();
        }
    }
}