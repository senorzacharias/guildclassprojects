using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models.Interfaces;

namespace BLL
{
    public class ManagerFactory
    {

        public static string CATEGORY_PATH = @"C:\Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\HRPortal\CategoryIO\Categories.txt";
        public static string POLICY_PATH = @"C:\Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\HRPortal\PolicyIO\Policies.txt";
        public static PolicyManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "Test":
                    PolicyRepository policy = new PolicyRepository();
                    CategoryRepository category = new CategoryRepository();
        
                    return new PolicyManager(policy, category);
                case "Prod":
                    FileCategoryRepository fileCategory = new FileCategoryRepository(CATEGORY_PATH);
                    FilePolicyRepository filePolicy = new FilePolicyRepository(POLICY_PATH);
                    return new PolicyManager(filePolicy, fileCategory);
                default:
                    throw new Exception("Check your mode! Greetings from the factory.");
            }
}
    }
}

