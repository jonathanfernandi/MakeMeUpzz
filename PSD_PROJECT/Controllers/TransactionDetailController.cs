using PSD_PROJECT.Handlers;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_PROJECT.Controllers
{
    public class TransactionDetailController
    {
        public static TransactionDetail FindTransactionDetailbyID(int transactionID)
        {
            return AdminHandler.FindTransactionDetailbyID(transactionID);
        }
    }
}