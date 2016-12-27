using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Flooring.Data;

namespace Flooring.BLL
{
    public class OrderManagerFactory
    {//Need to add product path
        public static string PRODUCT_PATH = @"C:\Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\FlooringMastery.CLI\ProductList\Products.txt";
        public static string FILE_PATH = @"C: \Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\FlooringMastery.CLI\SystemIO\";
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "Test":
                    OrderTestRepository orderTest = new OrderTestRepository();
                    ProductTestRepository productTest = new ProductTestRepository();
                    return new OrderManager(orderTest, productTest);
                case "Prod":
                    FileProductRepository fileProduct = new FileProductRepository(PRODUCT_PATH);
                    return new OrderManager(new FileOrderRepository(FILE_PATH, fileProduct), fileProduct);
                default:
                    throw new Exception("Check your mode! Greetings from the factory.");
            }
        }
    }
}
