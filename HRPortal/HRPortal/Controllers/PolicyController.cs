using BLL;
using Data;
using HRPortal.Controllers;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPortal.Controllers
{
    public class PolicyController : Controller
    {
        PolicyManager manager = ManagerFactory.Create();

        [HttpGet]
        public ActionResult DeleteCategoryCont(int id)//finish
        {
            PolicyVM model = new PolicyVM();
            model.Category = manager.ListCategories().Categories.FirstOrDefault(c => c.CategoryId == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteCategoryCont(PolicyVM model)//finish
        {
            manager.DeleteCategory(model.Category.CategoryId);

            return RedirectToAction("ManageCategories");
        }

        [HttpGet]
        public ActionResult DeletePolicyCont(int id)
        {
            PolicyVM policyVm = new PolicyVM();
            policyVm.Policy = manager.List().Policies.FirstOrDefault(i => i.PolicyNumber == id);
            return View(policyVm);//values are correct
        }

        [HttpPost]
        public ActionResult DeletePolicyCont(PolicyVM model)//values lost before being passed
        {
            manager.DeletePolicy(model.Policy.PolicyNumber);

            return RedirectToAction("ManagePolicies");
        }

        [HttpGet]
        public ActionResult ViewOnePolicy(int id)
        {
            PolicyVM policyVm = new PolicyVM();
            policyVm.Policy = manager.List().Policies.SingleOrDefault(p => p.PolicyNumber == id);
            

            return View(policyVm);
        }

        [HttpGet]
        public ActionResult ViewPolicies()
        {
            PolicyVM viewModel = new PolicyVM();
            viewModel.Policies = manager.List().Policies;
            viewModel.SetCategoryItems(manager.ListCategories().Categories);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ViewPolicies(PolicyVM policyVm)
        {
            PolicyVM viewModel = new PolicyVM();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult ManageCategories()//finish
        {
            PolicyVM viewModel = new PolicyVM();
            viewModel.Categories = manager.ListCategories().Categories;
            viewModel.SetCategoryItems(manager.ListCategories().Categories);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ManageCategories(PolicyVM policyVm)//finish
        {
            return View(policyVm);
        }

        [HttpGet]
        public ActionResult Index()//finish
        {
            return View();
        }

        [HttpGet]
        public ActionResult ManagePolicies()
        {
            PolicyVM viewModel = new PolicyVM();
            viewModel.Policies = manager.List().Policies;
            viewModel.SetCategoryItems(manager.ListCategories().Categories);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ManagePolicies(PolicyVM policyVm)
        {//do not allow active categories to be deleted
            PolicyVM model = new PolicyVM();

            return View(model);
        }



        [HttpGet]
        public ActionResult AddPolicy()
        {
            var viewModel = new PolicyVM();
            viewModel.SetCategoryItems(manager.ListCategories().Categories);
            
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult AddPolicy(PolicyVM policyVm)
        {
            //if (!string.IsNullOrWhiteSpace(policyVm.NewCategory))
            if (ModelState.IsValid)
            {
                Policy newPolicy = new Policy();
                if (!string.IsNullOrEmpty(policyVm.NewCategory))
                {
                    
                    manager.AddCategory(policyVm.NewCategory);
                    var categoryId = manager.ListCategories().Categories.Max(c => c.CategoryId);
                    newPolicy.CategoryId = categoryId;
                    newPolicy.PolicyName = policyVm.Policy.PolicyName;
                    newPolicy.PolicyContent = policyVm.Policy.PolicyContent;

                    manager.AddPolicy(newPolicy);

                    return RedirectToAction("ManagePolicies");
                }
                
                
                    newPolicy.PolicyName = policyVm.Policy.PolicyName;
                    newPolicy.PolicyContent = policyVm.Policy.PolicyContent;
                newPolicy.CategoryId = policyVm.Policy.CategoryId;
                manager.AddPolicy(newPolicy);

                   return RedirectToAction("ManagePolicies");
                
            }
           

            policyVm.SetCategoryItems(manager.ListCategories().Categories);
            return View(policyVm);

        }


    }
}