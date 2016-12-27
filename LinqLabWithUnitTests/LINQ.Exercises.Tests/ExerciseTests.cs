using System.Collections.Generic;
using System.Text;
using Linq.Helpers;
using Linq.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linq.Exercises.Tests
{
    [TestClass]
    public class ExerciseTests
    {
        /// <summary>
        /// Print all products.
        /// </summary>
        [TestMethod]
        public void TestExample1()
        {
            List<Product> actual = Exercise.Example1();
            List<Product> expected = Helper.FromXmlFile<List<Product>>("Example1.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print all numbers in NumbersA.
        /// </summary>
        [TestMethod]
        public void TestExample2()
        {
            List<int> actual = Exercise.Example2();
            List<int> expected = Helper.FromXmlFile<List<int>>("Example2.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        [TestMethod]
        public void TestExercise1WithoutLinq()
        {
            List<Product> actual = Exercise.Exercise1WithoutLinq();
            List<Product> expected = Helper.FromXmlFile<List<Product>>("Exercise1.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        [TestMethod]
        public void TestExercise1()
        {
            List<Product> actual = Exercise.Exercise1();
            List<Product> expected = Helper.FromXmlFile<List<Product>>("Exercise1.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        /// 
        [TestMethod]
        public void TestExercise2()
        {
            List<Product> actual = Exercise.Exercise2();
            List<Product> expected = Helper.FromXmlFile<List<Product>>("Exercise2.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        [TestMethod]
        public void TestExercise3()
        {
            List<Customer> actual = Exercise.Exercise3();
            List<Customer> expected = Helper.FromXmlFile<List<Customer>>("Exercise3.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        [TestMethod]
        public void TestExercise4()
        {
            StringBuilder stringBuilder = Exercise.Exercise4();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise4.txt");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        [TestMethod]
        public void TestExercise5()
        {
            StringBuilder stringBuilder = Exercise.Exercise5();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise5.txt");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        [TestMethod]
        public void TestExercise6()
        {
            StringBuilder stringBuilder = Exercise.Exercise6();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise6.txt");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        [TestMethod]
        public void TestExercise7()
        {
            StringBuilder stringBuilder = Exercise.Exercise7();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise7.txt");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        [TestMethod]
        public void TestExercise8()
        {
            StringBuilder stringBuilder = Exercise.Exercise8();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise8.txt");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        [TestMethod]
        public void TestExercise9()
        {
            List<int> actual = Exercise.Exercise9();
            List<int> expected = Helper.FromXmlFile<List<int>>("Exercise9.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        [TestMethod]
        public void TestExercise10()
        {
            List<Customer> actual = Exercise.Exercise10();
            List<Customer> expected = Helper.FromXmlFile<List<Customer>>("Exercise10.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        [TestMethod]
        public void TestExercise11()
        {
            List<int> actual = Exercise.Exercise11();
            List<int> expected = Helper.FromXmlFile<List<int>>("Exercise11.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        [TestMethod]
        public void TestExercise12WithoutLinq()
        {
            List<int> actual = Exercise.Exercise12WithoutLinq();
            List<int> expected = Helper.FromXmlFile<List<int>>("Exercise12.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        [TestMethod]
        public void TestExercise12()
        {
            List<int> actual = Exercise.Exercise12();
            List<int> expected = Helper.FromXmlFile<List<int>>("Exercise12.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        [TestMethod]
        public void TestExercise13()
        {
            StringBuilder stringBuilder = Exercise.Exercise13();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise13.txt");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        [TestMethod]
        public void TestExercise14WithoutLinq()
        {
            List<int> actual = Exercise.Exercise14WithoutLinq();
            List<int> expected = Helper.FromXmlFile<List<int>>("Exercise14.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        [TestMethod]
        public void TestExercise14()
        {
            List<int> actual = Exercise.Exercise14();
            List<int> expected = Helper.FromXmlFile<List<int>>("Exercise14.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        [TestMethod]
        public void TestExercise15WithoutLinq()
        {
            List<int> actual = Exercise.Exercise15WithoutLinq();
            List<int> expected = Helper.FromXmlFile<List<int>>("Exercise15.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        [TestMethod]
        public void TestExercise15()
        {
            List<int> actual = Exercise.Exercise15();
            List<int> expected = Helper.FromXmlFile<List<int>>("Exercise15.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        [TestMethod]
        public void TestExercise16WithoutLinq()
        {
            List<Product> actual = Exercise.Exercise16WithoutLinq();
            List<Product> expected = Helper.FromXmlFile<List<Product>>("Exercise16.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        [TestMethod]
        public void TestExercise16()
        {
            List<Product> actual = Exercise.Exercise16();
            List<Product> expected = Helper.FromXmlFile<List<Product>>("Exercise16.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        [TestMethod]
        public void TestExercise17WithoutLinq()
        {
            List<Product> actual = Exercise.Exercise17WithoutLinq();
            List<Product> expected = Helper.FromXmlFile<List<Product>>("Exercise17.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        [TestMethod]
        public void TestExercise17()
        {
            List<Product> actual = Exercise.Exercise17();
            List<Product> expected = Helper.FromXmlFile<List<Product>>("Exercise17.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        [TestMethod]
        public void TestExercise18WithoutLinq()
        {
            List<Product> actual = Exercise.Exercise18WithoutLinq();
            List<Product> expected = Helper.FromXmlFile<List<Product>>("Exercise18.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        [TestMethod]
        public void TestExercise18()
        {
            List<Product> actual = Exercise.Exercise18();
            List<Product> expected = Helper.FromXmlFile<List<Product>>("Exercise18.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        [TestMethod]
        public void TestExercise19WithoutLinq()
        {
            List<int> actual = Exercise.Exercise19WithoutLinq();
            List<int> expected = Helper.FromXmlFile<List<int>>("Exercise19.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        [TestMethod]
        public void TestExercise19()
        {
            List<int> actual = Exercise.Exercise19();
            List<int> expected = Helper.FromXmlFile<List<int>>("Exercise19.xml");
            CollectionAssert.AreEqual(expected, actual);
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
        [TestMethod]
        public void TestExercise20()
        {
            StringBuilder stringBuilder = Exercise.Exercise20();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise20.txt");
            Assert.AreEqual(expected, actual);
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
        [TestMethod]
        public void TestExercise21()
        {
            StringBuilder stringBuilder = Exercise.Exercise21();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise21.txt");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        [TestMethod]
        public void TestExercise22WithoutLinq()
        {
            List<string> actual = Exercise.Exercise22WithoutLinq();
            List<string> expected = Helper.FromXmlFile<List<string>>("Exercise22.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        [TestMethod]
        public void TestExercise22()
        {
            List<string> actual = Exercise.Exercise22();
            List<string> expected = Helper.FromXmlFile<List<string>>("Exercise22.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        [TestMethod]
        public void TestExercise23WithoutLinq()
        {
            bool actual = Exercise.Exercise23WithoutLinq();
            const bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        [TestMethod]
        public void TestExercise23()
        {
            bool actual = Exercise.Exercise23();
            const bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        [TestMethod]
        public void TestExercise24()
        {
            List<string> actual = Exercise.Exercise24();
            
            List<string> expected = Helper.FromXmlFile<List<string>>("Exercise24.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        [TestMethod]
        public void TestExercise25()
        {
            List<string> actual = Exercise.Exercise25();
            List<string> expected = Helper.FromXmlFile<List<string>>("Exercise25.xml");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        [TestMethod]
        public void TestExercise26WithoutLinq()
        {
            int actual = Exercise.Exercise26WithoutLinq();
            const int expected = 2;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        [TestMethod]
        public void TestExercise26()
        {
            int actual = Exercise.Exercise26();
            const int expected = 2;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        [TestMethod]
        public void TestExercise27()
        {
            StringBuilder stringBuilder = Exercise.Exercise27();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise27.txt");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        [TestMethod]
        public void TestExercise28()
        {
            StringBuilder stringBuilder = Exercise.Exercise28();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise28.txt");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        [TestMethod]
        public void TestExercise29()
        {
            StringBuilder stringBuilder = Exercise.Exercise29();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise29.txt");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        [TestMethod]
        public void TestExercise30()
        {
            StringBuilder stringBuilder = Exercise.Exercise30();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise30.txt");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        [TestMethod]
        public void TestExercise31()
        {
            StringBuilder stringBuilder = Exercise.Exercise31();
            string actual = stringBuilder.ToString();
            string expected = FileLoader.GetExpectedResults("Exercise31.txt");
            Assert.AreEqual(expected, actual);
        }
    }
}
