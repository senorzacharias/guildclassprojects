using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Data;
using BLL;
using Models;
using Models.Reponses;

namespace Tests
{
    [TestFixture]
    public class TestRepo
    {
        
        private PolicyManager manager = ManagerFactory.Create();

        [Test]
        public void CanLoadPolicyTestRepo()
        {
            var load = manager.List();

            Assert.IsNotNull(load);
            Assert.AreEqual(8, load.Policies.Count);

        }

        [TestCase(9, "Flagellation", "I love coding so much",1, true)]
        [TestCase(9, "",  "I love coding.",1, false)]
        [TestCase(9, "Flagellation", "I love coding much",1, false)]
        [TestCase(9, "Flagellation", "",1, false)]

        [Test]
        public void CanAddPolicyTestRepo(int number, string name, string content, int categoryId, bool expected)
        {
            PolicyAddResponse response = new PolicyAddResponse();
            Policy newPolicy = new Policy();

            newPolicy.PolicyNumber = number;
            newPolicy.PolicyName = name;
            newPolicy.PolicyContent = content;
            newPolicy.CategoryId = categoryId;

            response = manager.AddPolicy(newPolicy);

            Assert.AreEqual(expected, response.Success);
        }

        [Test]
        public void DeletePolicy()
        {
            var policies = manager.List();
            var selected = policies.Policies.FirstOrDefault(i => i.PolicyNumber == 1);
            var remove = manager.DeletePolicy(selected.PolicyNumber);

            Assert.AreEqual(true, remove.Success);
        }

        [TestCase("Existentialism", true)]
        [TestCase("", false)]
        [Test]
        public void CategoryAdd(string name, bool expected)
        {
            CategoryAddResponse response = new CategoryAddResponse();
            Category newCategory = new Category();

            newCategory.CategoryName = name;

            response = manager.AddCategory(newCategory.CategoryName);

            Assert.AreEqual(expected, response.Success);
        }

        [Test]
        public void DeleteCategory()
        {
            var categories = manager.ListCategories();
            var selected = categories.Categories.FirstOrDefault(i => i.CategoryId == 1);
            var remove = manager.DeleteCategory(selected.CategoryId);

            Assert.AreEqual(true, remove.Success);
        }

    }
}
