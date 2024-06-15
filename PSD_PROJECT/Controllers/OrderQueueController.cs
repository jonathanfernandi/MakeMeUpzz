using PSD_PROJECT.Handlers;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_PROJECT.Controllers
{
    public class OrderQueueController
    {
        public static List<TransactionHeader> GetTransactionHeaderList()
        {
            return AdminHandler.GetTransactionHeaderList();
        }
        public static void HandleTransaction(int transactionID) 
        {
            AdminHandler.HandleTransaction(transactionID);
        }
        public static List<TransactionHeader> GetTransactionHandledList()
        {
            return AdminHandler.GetTransactionHandledList();
        }
    }
}