namespace MySmallStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using MySmallStore.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MySmallStore.DAL.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MySmallStore.DAL.StoreContext context)
        {
            context.Products.AddOrUpdate(x => x.ProductID,
            
                new Product { ProductID = 1,ProductName = "Computer",Price = 2500m,Desc = "I7,SSD,GTX1080",Active = true},
                new Product { ProductID = 2,ProductName = "TV",Price = 1200m,Desc = "Sony OLED",Active = true},
                new Product { ProductID = 3,ProductName = "HeadPhones",Price = 500m,Desc = "Razer HeadSet",Active = true},
                new Product { ProductID = 4,ProductName = "SSD",Price = 350m,Desc = "Samsung SSD 256gb",Active = false},
                new Product { ProductID = 5,ProductName = "KeyBoard",Price = 150m,Desc = "SteelSeries Gaming KeyBoard",Active = true},
                new Product { ProductID = 6,ProductName = "Mouse",Price = 120m,Desc = "SteelSeries Gaming Mouse",Active = false}
            );

            context.SaveChanges();

            context.Customers.AddOrUpdate(x => x.Passport,
            
                new Customer { Passport = 5489965001,FirstName = "Asi",LastName = "Mon",BirthDate = Convert.ToDateTime("12.05.88"),Active = true},
                new Customer { Passport = 5480066513,FirstName = "Avi",LastName = "Cohen",BirthDate = Convert.ToDateTime("02.12.91"),Active = true},
                new Customer { Passport = 5587006352,FirstName = "Barak",LastName = "Dahan",BirthDate = Convert.ToDateTime("15.02.66"),Active = true},
                new Customer { Passport = 5022398015,FirstName = "Dana",LastName = "Rut",BirthDate = Convert.ToDateTime("13.10.89"),Active = false},
                new Customer { Passport = 5998006315,FirstName = "Moshe",LastName = "Peretz",BirthDate = Convert.ToDateTime("28.11.75"),Active = true},
                new Customer { Passport = 5336004922,FirstName = "Rivka",LastName = "Levi",BirthDate = Convert.ToDateTime("02.09.78"),Active = true},
                new Customer { Passport = 5339210051,FirstName = "Yossi",LastName = "Kadosh",BirthDate = Convert.ToDateTime("12.03.94"),Active = false}
            );

            context.SaveChanges();

            context.Orders.AddOrUpdate(x => x.OrderID,
            
                new Order { OrderID = 1,CustomerPassport = 5489965001,ProductID = 1 },
                new Order { OrderID = 2,CustomerPassport = 5489965001,ProductID = 6 },
                new Order { OrderID = 3,CustomerPassport = 5489965001,ProductID = 4 },
                new Order { OrderID = 4,CustomerPassport = 5480066513,ProductID = 2 },
                new Order { OrderID = 5,CustomerPassport = 5480066513,ProductID = 3 },
                new Order { OrderID = 6,CustomerPassport = 5480066513,ProductID = 5 },
                new Order { OrderID = 7,CustomerPassport = 5587006352,ProductID = 6 },
                new Order { OrderID = 8,CustomerPassport = 5587006352,ProductID = 4 },
                new Order { OrderID = 9,CustomerPassport = 5587006352,ProductID = 1 },
                new Order { OrderID = 10,CustomerPassport = 5022398015,ProductID = 3 },
                new Order { OrderID = 11,CustomerPassport = 5022398015,ProductID = 2 },
                new Order { OrderID = 12,CustomerPassport = 5022398015,ProductID = 6 },
                new Order { OrderID = 10,CustomerPassport = 5998006315,ProductID = 1 },
                new Order { OrderID = 11,CustomerPassport = 5998006315,ProductID = 4 },
                new Order { OrderID = 12,CustomerPassport = 5998006315,ProductID = 5 },
                new Order { OrderID = 13,CustomerPassport = 5336004922,ProductID = 2 },
                new Order { OrderID = 14,CustomerPassport = 5336004922,ProductID = 3 },
                new Order { OrderID = 15,CustomerPassport = 5336004922,ProductID = 1 },
                new Order { OrderID = 16,CustomerPassport = 5336004922,ProductID = 5 },
                new Order { OrderID = 17,CustomerPassport = 5339210051,ProductID = 1 },
                new Order { OrderID = 18,CustomerPassport = 5339210051,ProductID = 2 },
                new Order { OrderID = 19,CustomerPassport = 5339210051,ProductID = 6 }
            );

            context.SaveChanges();
        }
    }
}
