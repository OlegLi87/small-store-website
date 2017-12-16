using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySmallStore.Models;
using MySmallStore.DAL;

namespace MySmallStore.Store_Logic
{
    public static class HomePage
    {
        private static StoreContext db = new StoreContext();

        public static Customer GetYoungestCustomer()
        {
            Customer youngest = db.Customers.First();

            for (int i = 1; i < db.Customers.ToList<Customer>().Count; i++)
            {
                if (youngest.Age > db.Customers.ToList<Customer>()[i].Age)
                {
                    youngest = db.Customers.ToList<Customer>()[i];
                }
            }
            return youngest;
        }
    }
}