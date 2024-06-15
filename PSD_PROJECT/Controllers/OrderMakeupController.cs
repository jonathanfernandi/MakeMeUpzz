using PSD_PROJECT.Handlers;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PSD_PROJECT.Controllers
{
    public class OrderMakeupController
    {

        public static List<Cart> ListCart(int id)
        {
            return CustomerHandler.ListCart(id);
        }
        public static String doOrderCart(TextBox txtQuantity,Makeup makeup,MakeupType makeuptype,MakeupBrand makeupbrand,int userId)
        {
            String response = "";
            if (txtQuantity != null)
            {
                int quantity;
                if (int.TryParse(txtQuantity.Text, out quantity) && quantity > 0)
                {
                    Makeup findmakeup = CustomerHandler.FindMakeupbyNameTypeBrand(makeup,makeuptype,makeupbrand);
                    User user = LoginController.FindbyID(userId);
                    Cart cart = new Cart();
                    cart.MakeupID = findmakeup.MakeupID;
                    cart.UserID = user.UserID;
                    cart.Quantity = Convert.ToInt32(txtQuantity.Text);
                    CustomerHandler.InsertOrderToCart(cart);
                }
        

            }
            return response;
        }

        public static void doDeleteCart(int userID)
        {
            CustomerHandler.DeleteCart(userID);
        }
        public static void doCheckOut(int userID)
        {
            CustomerHandler.CheckOut(userID);
        }
    }
}