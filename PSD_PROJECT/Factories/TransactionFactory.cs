using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_PROJECT.Factories
{
    public class TransactionFactory
    {
        public static TransactionHeader TransactionHeaderFactory(int thid,int userId)
        {
            TransactionHeader th = new TransactionHeader();
            th.TransactionID = thid;
            th.UserID = userId;
            th.TransactionDate = DateTime.Now;
            th.Status = "Unhandled";
            return th;
        }
        public static TransactionDetail TransactionDetailFactory(int thID,Cart selectedCart)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionID = thID;
            td.MakeupID = selectedCart.MakeupID;
            td.Quantity = selectedCart.Quantity;

            return td;
        }
    }
}