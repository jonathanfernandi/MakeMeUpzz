using PSD_PROJECT.Handlers;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_PROJECT.Controllers
{
    public class HistoryController
    {
        public static List<TransactionDetail> GetCustomerTransactionList()
        {
            return CustomerHandler.GetCustomerTransactionList();
        }
    }
}