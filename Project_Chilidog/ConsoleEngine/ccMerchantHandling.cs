using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Chilidog.ConsoleEngine
{
    public static class ccMerchantHandling
    {
        #region Object Handling Methods



        #endregion

        #region Merchant Console AI Methods

        static public void ConsoleAIEntry(Merchants.IMerchant Merchant)
        {
            switch (Merchant.CurrentStatus)
            {
                case "Empty":
                    break;
                case "Full":
                    break;
                case "Travelling":
                    break;
                case "Resting":
                    break;
                default:
                    throw new ArgumentException(
                        String.Format("The CurrentStatus property on Merchant {0}:{1} is improperly set.", Merchant.ID, Merchant.Name)
                        );
            }
        }

        static void FindGoods(Merchants.IMerchant Merchant)
        {

        }

        static void FindMarket(Merchants.IMerchant Merchant)
        {

        }

        #endregion
    }
}
