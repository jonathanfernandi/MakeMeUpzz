using PSD_PROJECT.Models;
using PSD_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_PROJECT.Handlers
{
    public class AdminHandler
    {
        public static List<User> ListCustomer()
        {
            return UserRepository.ListCustomer();
        }

        public static List<Makeup> ListMakeup()
        {
            return MakeupRepository.GetMakeupList();
        }

        public static List<MakeupType> ListMakeupType()
        {
            return MakeupRepository.GetMakeupTypeList();
        }
        public static List<MakeupBrand> ListMakeupBrand()
        {
            return MakeupRepository.GetMakeupBrandList();
        }
        public static void InsertMakeup(Makeup makeup)
        {
            MakeupRepository.InsertMakeup(makeup);
        }
        public static Makeup FindMakeupbyID(int id)
        {
            return MakeupRepository.FindMakeupByID(id);
        }

        public static Makeup FindMakeupbyName(string name)
        {
            return MakeupRepository.FindMakeupByName(name);
        }
        public static MakeupType FindMakeupTypebyID(int id)
        {
            return MakeupRepository.FindTypeByID(id);
        }
        public static MakeupBrand FindMakeupBrandbyID(int id)
        {
            return MakeupRepository.FindBrandByID(id);
        }

        public static void InsertMakeupType(MakeupType makeuptype)
        {
            MakeupRepository.InsertMakeupType(makeuptype);
        }
        public static void InsertMakeupbrand(MakeupBrand makeupbrand)
        {
            MakeupRepository.InsertMakeupBrand(makeupbrand);
        }
        public static void UpdateMakeup(Makeup makeup)
        {
            MakeupRepository.UpdateMakeup(makeup);
        }
        public static void DeleteMakeup(int id)
        {
            MakeupRepository.DeleteMakeup(id);
        }
        public static void UpdateMakeupType(MakeupType makeuptype)
        {
            MakeupRepository.UpdateMakeupType(makeuptype);
        }
        public static void UpdateMakeupBrand(MakeupBrand makeupbrand)
        {
            MakeupRepository.UpdateMakeupBrand(makeupbrand);
        }
        public static List<TransactionHeader> GetTransactionHeaderList()
        {
            return TransactionRepository.GetTransactionHeaderList();
        }
        public static void HandleTransaction(int transactionID)
        {
            TransactionRepository.HandleTransaction(transactionID);
        }
        public static List<TransactionHeader> GetTransactionHandledList()
        {
            return TransactionRepository.GetTransactionHandledList();
        }
        public static TransactionHeader FindTransactionbyID(int transactionID)
        {
            return TransactionRepository.FindTransactionbyID(transactionID);
        }
        public static TransactionDetail FindTransactionDetailbyID(int transactionID)
        {
            return TransactionRepository.FindTransactionDetailbyID(transactionID);
        }

        public static List<TransactionHeader> GetTransactionHeaders()
        {
            return TransactionRepository.GetTransactionHeaders();
        }
    }
}