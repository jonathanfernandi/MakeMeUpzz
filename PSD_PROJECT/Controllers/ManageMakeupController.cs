using PSD_PROJECT.Handlers;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Controllers
{
    public class ManageMakeupController
    {
        public static List<Makeup> ListMakeup()
        {
            return AdminHandler.ListMakeup();
        }
        public static List<MakeupType> ListMakeupType()
        {
            return AdminHandler.ListMakeupType();
        }
        public static List<MakeupBrand> ListMakeupBrand()
        {
            return AdminHandler.ListMakeupBrand();
        }
        public static String CheckMakeupName(Makeup makeup)
        {
            String response = "";
            if (makeup.MakeupName.Length < 1 || makeup.MakeupName.Length > 99)
            {
                response = "Name must be between 1-99 characters";
            }
            return response;
        }
        public static String CheckMakeupPrice(Makeup makeup)
        {
            String response = "";
            if(makeup.MakeupPrice < 1)
            {
                response = "Price must be greater than or equals than 1";
            }
            return response;
        }
        public static String CheckMakeupWeight(Makeup makeup)
        {
            String response = "";
            if(makeup.MakeupWeight > 1500)
            {
                response = "Weight Cannot be greater than 1500 (grams)";
            }
            return response;
        }
        public static String CheckTypeID(Makeup makeup)
        {
            String response = "";
            if (AdminHandler.FindMakeupTypebyID(makeup.MakeupTypeID) == null)
            {
                response = "No such Makeup Type ID";
            }
            return response;
        }

        public static String CheckBrandID(Makeup makeup)
        {
            String response = "";
            if (AdminHandler.FindMakeupBrandbyID(makeup.MakeupBrandID) == null)
            {
                response = "No such Makeup Brand ID";
            }
            return response;
        }

        public static String doInsertMakeup(Makeup makeup)
        {
            String response = CheckMakeupName(makeup);
            if (response.Equals(""))
            {
                response = CheckMakeupPrice(makeup);
            }
            if (response.Equals(""))
            {
                response = CheckMakeupWeight(makeup);
            }
            if (response.Equals(""))
            {
                response = CheckTypeID(makeup);
            }
            if (response.Equals(""))
            {
                response = CheckBrandID(makeup);
            }
            if (response.Equals(""))
            {
                AdminHandler.InsertMakeup(makeup);
            }
            return response;
        }

        public static String CheckMakeupTypeName(MakeupType makeuptype)
        {
            String response = "";
            if(makeuptype.MakeupTypeName.Length <1 || makeuptype.MakeupTypeName.Length > 99)
            {
                response = "Name must be between 1-99 characters";
            }
            return response;
        }
        public static String doInsertMakeupType(MakeupType makeuptype)
        {
            String response = CheckMakeupTypeName(makeuptype);
            if (response.Equals(""))
            {
                AdminHandler.InsertMakeupType(makeuptype);
            }
            return response;
        }

        public static String CheckMakeupBrandName(MakeupBrand makeupbrand)
        {
            String response = "";
            if(makeupbrand.MakeupBrandName.Length <1 || makeupbrand.MakeupBrandName.Length > 99)
            {
                response = "Name must be between 1-99 characters";
            }
            return response;
        }
        public static String CheckMakeupBrandRating(MakeupBrand makeupbrand)
        {
            String response = "";
            if(makeupbrand.MakeupBrandRating <0 ||  makeupbrand.MakeupBrandRating > 100)
            {
                response = "Rating must be between 0-100";
            }
            return response;
        }
        public static String doInsertMakeupBrand(MakeupBrand makeupbrand)
        {
            String response = CheckMakeupBrandName(makeupbrand);
            if (response.Equals(""))
            {
                response = CheckMakeupBrandRating(makeupbrand);
            }
            if (response.Equals(""))
            {
                AdminHandler.InsertMakeupbrand(makeupbrand);
            }
            return response;
        }
        public static Makeup FindMakeupByID(int id)
        {
            return AdminHandler.FindMakeupbyID(id);
        }

        public static MakeupType FindMakeupTypeByID(int id)
        {
            return AdminHandler.FindMakeupTypebyID(id);
        }
        public static MakeupBrand FindMakeupBrandByID(int id)
        {
            return AdminHandler.FindMakeupBrandbyID(id);
        }
        public static String doUpdateMakeup(Makeup makeup)
        {
            String response = CheckMakeupName(makeup);
            if (response.Equals(""))
            {
                response = CheckMakeupPrice(makeup);
            }
            if (response.Equals(""))
            {
                response = CheckMakeupWeight(makeup);
            }
            if (response.Equals(""))
            {
                response = CheckTypeID(makeup);
            }
            if (response.Equals(""))
            {
                response = CheckBrandID(makeup);
            }
            if (response.Equals(""))
            {
                AdminHandler.UpdateMakeup(makeup);
            }
            return response;
        }

        public static void doDeleteMakeup(int id)
        {
            AdminHandler.DeleteMakeup(id);
        }

        public static String doUpdateMakeupType(MakeupType makeuptype)
        {
            String response = CheckMakeupTypeName(makeuptype);
            if (response.Equals(""))
            {
                AdminHandler.UpdateMakeupType(makeuptype);
            }
            return response;
        }
        public static String doUpdateMakeupBrand(MakeupBrand makeupbrand)
        {
            String response = CheckMakeupBrandName(makeupbrand);
            if (response.Equals(""))
            {
                response = CheckMakeupBrandRating(makeupbrand);
            }
            if (response.Equals(""))
            {
                AdminHandler.UpdateMakeupBrand(makeupbrand);
            }
            return response;
        }
        public static bool checkInputMakeup(TextBox makeupname,TextBox makeupprice,TextBox makeupweight,TextBox makeuptype,TextBox makeupbrand)
        {
            if(makeupname.Text == null)
            {
                return false;
            }
            if(makeupprice.Text.ToString() == "")
            {
                return false;
            }
            if(makeupweight.Text.ToString() == "")
            {
                return false;
            }
            if(makeuptype.Text.ToString() == "")
            {
                return false;
            }
            if(makeupbrand.Text.ToString() == "")
            {
                return false;
            }

            return true;   
        }

        public static bool checkInputMakeupBrand(TextBox makeupbrandrating)
        {
            if (makeupbrandrating.Text == "")
            {
                return false;
            }

            return true;
        }
    }
}