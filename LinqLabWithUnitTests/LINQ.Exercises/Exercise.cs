using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Data;
using Linq.Models;

namespace Linq.Exercises
{
    /// <summary>
    /// Only change the methods--not the string constants.
    /// </summary>
    public static class Exercise
    {
        /// <summary>
        /// Print all products.
        /// </summary>
        public static List<Product> Example1()
        {
            return DataLoader.LoadProducts();
        }

        /// <summary>
        /// Print all numbers in NumbersA.
        /// </summary>
        public static List<int> Example2()
        {
            return DataLoader.NumbersA.ToList();
        }

        /// <summary>
        /// Print all products that are out of stock without using Linq.
        /// </summary>
        public static List<Product> Exercise1WithoutLinq()
        {//stringbuilder append

            List<Product> allProducts = DataLoader.LoadProducts();

            List<Product> outOfStockProducts = new List<Product>();

            foreach (Product product in allProducts)
            {
                if (product.UnitsInStock == 0)
                {
                    outOfStockProducts.Add(product);
                }
            }
            return outOfStockProducts;
        }
        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        public static List<Product> Exercise1()
        {//stringbuilder .ToList();
            List<Product> products = DataLoader.LoadProducts();

            IEnumerable<Product> outOfStockProducts = products.Where(product => product.UnitsInStock == 0);

            return outOfStockProducts.ToList();
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        public static List<Product> Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();

            IEnumerable<Product> outOfStock = products.Where(product => product.UnitsInStock > 0 && product.UnitPrice > 3);

            return outOfStock.ToList();
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        public static List<Customer> Exercise3()
        {
            List<Customer> customerList = DataLoader.LoadCustomers();

            IEnumerable<Customer> waRegion = customerList.Where(region => region.Region == "WA");

            return waRegion.ToList();
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        public static StringBuilder Exercise4()
        {


            List<Product> allProducts = DataLoader.LoadProducts();

            var productNameObjects = allProducts.Select(product => new
            {
                ProductName = product.ProductName
            });

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var productNameObject in productNameObjects)
            {
                stringBuilder.AppendLine(productNameObject.ProductName);
            }

            return stringBuilder;
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        public static StringBuilder Exercise5()
        {
            const string exercise5Format = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";

            List<Product> allProducts = DataLoader.LoadProducts();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(exercise5Format, "Id", "Product Name", "Category", "Unit", "Stock");
            var increasedPrices = allProducts.Select(product => new
            {
                ProductPrice = product.UnitPrice * 1.25M,
                ProductID = product.ProductID,
                Category = product.Category,
                UnitsInStock = product.UnitsInStock,
                ProductName = product.ProductName,

            });


            foreach (var increasedPrice in increasedPrices)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendFormat(exercise5Format, increasedPrice.ProductID, increasedPrice.ProductName, increasedPrice.Category, increasedPrice.ProductPrice, increasedPrice.UnitsInStock);
            }
            return stringBuilder;
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        public static StringBuilder Exercise6()
        {
            const string exercise6Format = "{0,-35} {1,-15}";
            List<Product> productsList = DataLoader.LoadProducts();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(exercise6Format, "Product Name", "Category");
            var bothCategories = productsList.Select(category => new
            {
                ProductName = category.Category.ToUpper(),
                Category = category.ProductName.ToUpper(),

            });

            foreach (var category in bothCategories)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendFormat(exercise6Format, category.ProductName, category.Category);
            }
            return stringBuilder;
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3. Hint: use a ternary expression.
        /// </summary>
        public static StringBuilder Exercise7()
        {
            const string exercise7Format = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5}";
            List<Product> products = DataLoader.LoadProducts();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(exercise7Format, "Id", "Product Name", "Category", "Unit", "Stock", "ReOrder?");

            var information = products.Select(product => new
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Category = product.Category,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                ReOrder = product.UnitsInStock < 3
            });
            foreach (var product in information)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendFormat(exercise7Format, product.ProductID, product.ProductName, product.Category, product.UnitPrice, product.UnitsInStock, product.UnitsInStock < 3);
            }
            return stringBuilder;

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        public static StringBuilder Exercise8()
        {
            const string exercise8Format = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5}";
            List<Product> list = DataLoader.LoadProducts();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(exercise8Format, "Id", "Product Name", "Category", "Unit", "Stock", "Stock Value");

            var productInfo = list.Select(product => new
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Category = product.Category,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                StockValue = product.UnitPrice * product.UnitsInStock,

            });
            foreach (var product in productInfo)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendFormat(exercise8Format, product.ProductID, product.ProductName, product.Category, product.UnitPrice, product.UnitsInStock, product.UnitPrice * product.UnitsInStock);
            }
            return stringBuilder;
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        public static List<int> Exercise9()
        {
            int[] evenArray = DataLoader.NumbersA;

            var numbers = from i in evenArray
                          where i % 2 == 0
                          select i;


            return numbers.ToList();


        }

        /// <summary>
        /// Print only customers that have an order whose total is less than $500
        /// </summary>
        public static List<Customer> Exercise10()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            IEnumerable<Customer> newCustomers = customers
                .Where(customer => customer.Orders
                                           .Any(order => order.Total < 500));

            return newCustomers.ToList();





        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        public static List<int> Exercise11()
        {
            int[] oddArray = DataLoader.NumbersC;

            var numbers = from i in oddArray
                          where i % 2 == 1
                          select i;

            return numbers.Take(3).ToList();
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3 without using Linq.
        /// </summary>
        public static List<int> Exercise12WithoutLinq()
        {
            //    int[] array = DataLoader.NumbersB;

            //    var removeThree = from i in array
            //                      where i
            //    if (array.Length > 3)
            //    {
            //        foreach (int item in array)
            //        {
            //            removeThree += item;
            //        }
            //        return removeThree.T;
            //    }
            //}
            throw new NotImplementedException();
        }
        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        public static List<int> Exercise12()
        {
            int[] numbersList = DataLoader.NumbersB;

            return numbersList.Skip(3).ToList();
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        public static StringBuilder Exercise13()
        {
            const string exercise13Format = "{0,-35} {1,-15} {2} {3}";

            List<Customer> customers = DataLoader.LoadCustomers();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(exercise13Format, "Company Name", "Order ID", "Order Date", "Order Total");

            var recentCustomers = customers.Where(customer => customer.Region == "WA")
                                                              .Where(customer => customer.Orders.Length >= 1)
                                                              .Select(customer => new
                                                              {
                                                                  CompanyName = customer.CompanyName,
                                                                  MostRecentOrder = customer.Orders.OrderByDescending(i => i.OrderDate).First(),


                                                              });

            foreach (var customer in recentCustomers)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendFormat(exercise13Format, customer.CompanyName, customer.MostRecentOrder.OrderID, customer.MostRecentOrder.OrderDate.ToString("M/d/yy h:mm:ss tt"), customer.MostRecentOrder.Total);
            }
            return stringBuilder;


        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6 without using Linq.
        /// </summary>
        public static List<int> Exercise14WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        public static List<int> Exercise14()
        {
            List<int> numbers = DataLoader.NumbersC.ToList();

            return numbers.TakeWhile(number => number <= 6).ToList();


        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3 without using Linq.
        /// </summary>
        public static List<int> Exercise15WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        public static List<int> Exercise15()
        {

            List<int> numbers = DataLoader.NumbersC.ToList();

            return numbers.SkipWhile(number => number % 3 != 0).Skip(1).ToList();
        }

        /// <summary>
        /// Print the products alphabetically by name without using Linq.
        /// </summary>
        public static List<Product> Exercise16WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        public static List<Product> Exercise16()
        {
            List<Product> products = DataLoader.LoadProducts().ToList();

            return products.OrderBy(product => product.ProductName).ToList();

        }

        /// <summary>
        /// Print the products in descending order by units in stock without using Linq.
        /// </summary>
        public static List<Product> Exercise17WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        public static List<Product> Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();

            return products.OrderByDescending(product => product.UnitsInStock).ToList();
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest without using Linq.
        /// </summary>
        public static List<Product> Exercise18WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        public static List<Product> Exercise18()
        {
            List<Product> products = DataLoader.LoadProducts();

            return products.OrderBy(i => i.Category)
                           .ThenByDescending(i => i.UnitPrice)
                           .ToList();
        }

        /// <summary>
        /// Print NumbersB in reverse order without using Linq.
        /// </summary>
        public static List<int> Exercise19WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        public static List<int> Exercise19()
        {
            int[] numbers = DataLoader.NumbersB;

            var reverse = numbers.Reverse().ToList();

            return reverse;

        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        public static StringBuilder Exercise20()
        {
            List<Product> productList = DataLoader.LoadProducts();
            StringBuilder stringBuilder = new StringBuilder();

            var groups = productList.GroupBy(product => product.Category);



            foreach (var category in groups)
            {
                stringBuilder.AppendLine(category.Key);
                foreach (var product in category)
                {
                    stringBuilder.AppendLine(product.ProductName);
                }
                stringBuilder.AppendLine();
            }


            return stringBuilder;

        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        public static StringBuilder Exercise21()
        {
            const string exercise21FormatPerMonth = "\t{0} -  {1:C2}";
            List<Customer> customers = DataLoader.LoadCustomers();
            StringBuilder stringBuilder = new StringBuilder();

            //var orders = customers.Select(customer => new
            //{
            //    Customer = customer
            //});
            //foreach (var customer in customers)
            //{
            //    stringBuilder.AppendLine(customer.CompanyName);

            //    var ordersByYear = customer.Orders.GroupBy(i => i.OrderDate.Year);
            //    foreach (var bucket in ordersByYear)
            //    {
            //        stringBuilder.AppendFormat(exercise21FormatPerMonth, bucket.Key);
            //        var ordersByMonth = customer.Orders.GroupBy(j => j.OrderDate.Month);
            //        foreach (var month in ordersByMonth)
            //        {
            //            stringBuilder.AppendFormat(exercise21FormatPerMonth, month.Key);
            //        }
            //    }

            //}
            //return stringBuilder;
            throw new NotImplementedException();

        }

        /// <summary>
        /// Print the unique list of product categories without using Linq.
        /// </summary>
        public static List<string> Exercise22WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        public static List<string> Exercise22()
        {
            List<Product> products = DataLoader.LoadProducts();

            return products.Select(product => product.Category)
                                      .Distinct().ToList();
            //return uniqueList;
            ///////////////////
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists without using Linq.
        /// </summary>
        public static bool Exercise23WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        public static bool Exercise23()
        {
            var products = DataLoader.LoadProducts();

            var result = products.Any(product => product.ProductID == 789);

            return result;

        }
        //products.Where(product => product.ProductID.
        //.Any(product => product.

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        public static List<string> Exercise24()
        {
            List<Product> products = DataLoader.LoadProducts();

            return products.Where(product => product.UnitsInStock == 0).GroupBy(categories => categories.Category).Select(groups => groups.Key).ToList();
               
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        public static List<string> Exercise25()
        {
            List<Product> products = DataLoader.LoadProducts();

            var noOutOfStock = products.Where(product => product.UnitsInStock > 0)
                            .Select(product => product.Category).ToList();
            return noOutOfStock;
           
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA without using Linq.
        /// </summary>
        public static int Exercise26WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        public static int Exercise26()
        {
            int[] numbersA = DataLoader.NumbersA;

            var oddNumbers = numbersA.Where(number => number % 2 == 0);
            return oddNumbers.Count();
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        public static StringBuilder Exercise27()
        {
            const string exercise27Format = "{0} - {1}";
            List<Customer> customers = DataLoader.LoadCustomers();
            StringBuilder builder = new StringBuilder();

            var customerOrders = customers.Select(customer => new
            {
                CustomerId = customer.CustomerID,
                Orders = customer.Orders.Count()
            });

            foreach (var customer in customerOrders)
            {
                
                builder.AppendFormat(exercise27Format, customer.CustomerId, customer.Orders).ToString();
                builder.AppendLine();
            }
            return builder;
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        public static StringBuilder Exercise28()
        {
            const string exercise28Format = "{0} - {1}";
            List<Product> productList = DataLoader.LoadProducts();
            StringBuilder builder = new StringBuilder();

            var categories = productList.GroupBy(product => product.Category)
                                        .Distinct().ToList();

            foreach (var category in categories)
            {

                builder.AppendFormat(exercise28Format, category.Key, category.Count());
                builder.AppendLine();
                
            }
            return builder;
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        public static StringBuilder Exercise29()
        {
            //    const string exercise29Format = "{0} - {1}";
            //    List<Product> products = DataLoader.LoadProducts();
            //    StringBuilder builder = new StringBuilder();

            //    var categories = products.GroupBy(product => product.Category).Distinct().ToList();



            //    foreach (var unit in categories)
            //    {
            //        builder.AppendFormat(exercise29Format, unit.Key, unit.  )
            //    }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        public static StringBuilder Exercise30()
        {
            const string exercise30Format = "{0} - {1}";
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        public static StringBuilder Exercise31()
        {
            const string exercise31Format = "{0} - {1 : C}";
            throw new NotImplementedException();
        }
    }
}
