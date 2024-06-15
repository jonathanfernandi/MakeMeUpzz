using PSD_PROJECT.Factories;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_PROJECT.Repositories
{
    public class TransactionRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static List<Cart> GetCartList(int id)
        {
            return (from cart in db.Carts where(cart.UserID == id) select cart).ToList();
        }
        public static List<TransactionHeader> GetTransactionHeaderList()
        {
            return(from th in db.TransactionHeaders select th).ToList();
        }

        public static List<TransactionHeader> GetTransactionHandledList()
        {
            return (from th in db.TransactionHeaders where th.Status.Equals("Handled") select th).ToList();
        }
        public static List<TransactionDetail> GetCustomerTransactionList()
        {
            return (from td in db.TransactionDetails select td).ToList();
        }
        public static int GenerateCartId()
        {
            int newID = 1;
            int lastID = db.Carts.Select(x => x.CartID).ToList().LastOrDefault();

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
        public static int GenerateTransactionHeaderID()
        {
            int newID = 1;
            int lastID = db.TransactionHeaders.Select(x => x.TransactionID).ToList().LastOrDefault();

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
        public static TransactionHeader FindTransactionbyID(int transactionID)
        {
            return (from transaction in db.TransactionHeaders where transaction.TransactionID == transactionID select transaction).FirstOrDefault();
        }
        public static TransactionDetail FindTransactionDetailbyID(int transactionID)
        {
            return (from transactiondetail in db.TransactionDetails where transactiondetail.TransactionID == transactionID select transactiondetail).FirstOrDefault();
        }
        public static void InsertOrderToCart(Cart cart)
        {
            int id = GenerateCartId();
            cart.CartID = id;
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public static Cart SelectCart(int userID)
        {
            Cart cart = GetCartList(userID).FirstOrDefault();
            return cart;
        }
        public static void DeleteCart(int userID)
        {
            Cart selectedCart = TransactionRepository.SelectCart(userID);

            while (selectedCart != null)
            {   
                db.Carts.Remove(selectedCart);
                db.SaveChanges();
                selectedCart = TransactionRepository.SelectCart(userID);
            }
        }
        public static void CheckoutTransaction(int userID)
        {
            Cart selectedCart = TransactionRepository.SelectCart(userID); 

            while(selectedCart != null)
            {
                int thID = GenerateTransactionHeaderID();

                TransactionHeader th = TransactionFactory.TransactionHeaderFactory(thID, userID);
                db.TransactionHeaders.Add(th);
                db.SaveChanges();
                TransactionDetail td = TransactionFactory.TransactionDetailFactory(th.TransactionID, selectedCart);
                db.TransactionDetails.Add(td);
                db.SaveChanges();
                db.Carts.Remove(selectedCart);
                db.SaveChanges();
                selectedCart = TransactionRepository.SelectCart(userID);
            }
        }
        public static void HandleTransaction(int transactionID)
        {
            TransactionHeader transaction = TransactionRepository.FindTransactionbyID(transactionID);
            transaction.Status = "Handled";
            db.SaveChanges();
        }

        public static List<TransactionHeader> GetTransactionHeaders()
        {
            DatabaseEntities db = new DatabaseEntities();
            return db.TransactionHeaders.ToList();
        }
        
    }
}