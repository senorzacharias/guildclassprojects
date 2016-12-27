using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models.Interfaces;
using Models.Reponses;

namespace BLL
{
    public class PolicyManager
    {
        
        private IPolicyRepository _policyRepository;
        private ICategoryRepository _categoryRepository;
        public PolicyManager(IPolicyRepository policyRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _policyRepository = policyRepository;
        }

       


        public PolicyLookupResponse List()
        {
            PolicyLookupResponse response = new PolicyLookupResponse();
            response.Policies = _policyRepository.GetAll();

            if (response.Policies == null || response.Policies.Count < 1)
            {
                response.Success = false;
                response.Message = $"Error loading orders.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public PolicyAddResponse AddPolicy(Policy policy)
        {
            PolicyAddResponse response = new PolicyAddResponse();
            var allPolicies = _policyRepository.GetAll();//use response
            var policyLookup = _policyRepository.GetAll().FirstOrDefault(i => i.PolicyName == policy.PolicyName);


            if (policyLookup == null && !string.IsNullOrWhiteSpace(policy.PolicyName) && !string.IsNullOrWhiteSpace(policy.PolicyContent))
            {
                
                _policyRepository.Add(policy);

                var newList = _policyRepository.GetAll();
                if (allPolicies.Count <= newList.Count)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Policy {policy} valid, but there was an error adding.";
                }

            }
            else
            {
                response.Success = false;
                response.Message = $"{policy} already exists or is missing information. Policy not saved.";
            }
            
            return response;
        }

        public PolicyDeleteResponse DeletePolicy(int policyNumber)
        {
            PolicyDeleteResponse response = new PolicyDeleteResponse();

            var all = _policyRepository.GetAll();//use response
            var policy = all.FirstOrDefault(i => i.PolicyNumber == policyNumber);

            if (policy != null)
            {
                _policyRepository.Delete(policy.PolicyNumber);

                if (_policyRepository.GetAll().FirstOrDefault(i => i.PolicyNumber == policyNumber) != null) 
                {
                    response.Success = false;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Error deleting policy.";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Policy number does not exist.";
            }
            return response;
        }

        public IEnumerable<Policy> GetPoliciesByCategoryId(int categoryId)
        {
            return _policyRepository.GetAll().Where(c => c.CategoryId == categoryId);
        }

        public CategoryLookupResponse ListCategories()
        {
            CategoryLookupResponse response = new CategoryLookupResponse();
            response.Categories = _categoryRepository.GetAll();

            if (response.Categories == null || response.Categories.Count < 1)
            {
                response.Success = false;
                response.Message = $"Error loading categories.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public CategoryAddResponse AddCategory(string categoryName)
        {
            CategoryAddResponse response = new CategoryAddResponse();
            var categoryCompare = _categoryRepository.GetAll();
            var categoryLookup = _categoryRepository.GetAll().Where(c => c.CategoryName == categoryName).ToList();

            if (categoryLookup.Count < 1 && !string.IsNullOrEmpty(categoryName))
            {
                response.Category = _categoryRepository.Add(categoryName);
                var count = _categoryRepository.GetAll().Count;
                var selected = _categoryRepository.GetAll().FirstOrDefault(i => i.CategoryName == categoryName);
                if ( selected != null)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Category {categoryName} is new and valid, but there was an error saving.";
                }
            }
            else
            {
                response.Success = false;
                response.Message = $"{categoryName} either already exists or is missing information.";
            }

            return response;
        }

        public GetCategoryResponse GetCategory(int categoryId)
        {
            GetCategoryResponse response = new GetCategoryResponse();
            var allCategories = _categoryRepository.GetAll();
            response.Category = allCategories.FirstOrDefault(c => c.CategoryId == categoryId);
            

            if (response.Category == null)
            {
                response.Success = false;
                response.Message = $"Error loading categories.";
            }
            else
            {
                response.Success = true;
            }

            return response;

        }

        public CategoryDeleteResponse DeleteCategory(int id)
        {
            CategoryDeleteResponse response = new CategoryDeleteResponse();
            var all = _categoryRepository.GetAll();
            var category = _categoryRepository.GetAll().Where(i => i.CategoryId == id).ToList();
            
            

            if (category.Count < 1)
            {
                response.Success = false;
                response.Message = "Cannot delete active or non-existant categories.";
                return response;
            }

            _categoryRepository.Delete(id);

            if (_categoryRepository.GetAll().Count <= all.Count)
            {
                response.Success = true;

            }
            else
            {
                response.Success = false;
                response.Message = "Error deleting policy.";
            }
            return response;
        }


    }
}
