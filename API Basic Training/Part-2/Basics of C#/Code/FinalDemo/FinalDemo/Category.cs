using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDemo
{
    public class Category
    {
        // Properties with private setters for encapsulation
        public int CategoryId { get; private set; }
        public string CategoryName { get; private set; }

        // Constructor
        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        // Method for updating category name
        public void SetCategoryName(string newCategoryName)
        {
            // Basic validation: ensure the new category name is not empty
            if (!string.IsNullOrWhiteSpace(newCategoryName))
            {
                CategoryName = newCategoryName;
            }
            else
            {
                Console.WriteLine("Invalid category name. Please provide a non-empty name.");
            }
        }
    }

}
