using Suites.DataBase;
using Suites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suites.Serveres
{
    public class ShopService
    {
        #region Singleton
        public static ShopService Instance
        {
            get
            {
                if (instance == null) instance = new ShopService();

                return instance;
            }
        }
        private static ShopService instance { get; set; }

        private ShopService()
        {
        }


        #endregion

        public int SaveOrder(Order order)
        {
            using (var context = new SuitDBContext())
            {
                context.Orders.Add(order);
                return context.SaveChanges();
            }
        }
    }
}