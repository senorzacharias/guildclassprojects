using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models.Interfaces;


namespace Models
{
    public class PolicyVM
    {
        public Policy Policy { get; set; }
        public List<SelectListItem> CategoryItems { get; set; }

        
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Must be more than two letters.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$",
         ErrorMessage = "Only letters are allowed.")]
        public string NewCategory { get; set; }
        public Category Category { get; set; }// change made here
        public IEnumerable<Policy> Policies { get; set; }
        public IEnumerable<Category> Categories { get; set; }


        public PolicyVM()
        {

            CategoryItems = new List<SelectListItem>();
            Policy = new Policy();
        }

        public void SetCategoryItems(IEnumerable<Category> categories)
        {
            foreach (var category in categories)
            {
                CategoryItems.Add(new SelectListItem()
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.CategoryName
                });

            }
        }

    }
}
