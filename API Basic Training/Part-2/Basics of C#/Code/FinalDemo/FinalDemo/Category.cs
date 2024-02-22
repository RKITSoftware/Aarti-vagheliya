using System;
using System.Collections.Generic;


namespace FinalDemo
{
    /// <summary>
    /// Represents a category in the inventory.
    /// </summary>
    public class Category
    {
        #region Public Properties 

        // Properties with private setters for encapsulation

        /// <summary>
        /// Gets or sets the ID of the category.
        /// </summary>
        public int CategoryId { get; private set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string CategoryName { get; private set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="categoryId">The unique identifier for the category.</param>
        /// <param name="categoryName">The name of the category.</param>
        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
        #endregion

        #region Public Methods

        #region SetCategoryName
        /// <summary>
        /// Sets a new name for the category.
        /// </summary>
        /// <param name="newCategoryName">The new name for the category.</param>
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
        #endregion

        #region Validate
        /// <summary>
        /// Validates the category's properties against existing categories.
        /// </summary>
        /// <param name="existingCategories">The list of existing categories for validation.</param>
        public void Validate(List<Category> existingCategories)
        {
            // Validate the uniqueness of Category ID
            if (!ValidationHelper.IsCategoryIdValid(CategoryId, existingCategories))
            {
                throw new ArgumentException("Invalid or duplicate Category ID.");
            }

            // Validate the Category Name
            if (!ValidationHelper.IsCategoryNameValid(CategoryName))
            {
                throw new ArgumentException("Invalid Category Name. Please provide a non-empty string.");
            }
        }
        #endregion

        #region Add Category

        /// <summary>
        /// Adds a new category to the inventory.
        /// </summary>
        /// <param name="inventory">The inventory to add the category to.</param>
        public static void AddCategory(Inventory inventory)
        {
            try
            {
                // Get category details from the user
                Console.Write("Enter Category ID: ");
                int categoryId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Category Name: ");
                string categoryName = Console.ReadLine();

                // Validate the input
                if (categoryId < 0)
                {
                    throw new ArgumentException("Invalid Category ID. Please provide a positive integer value.");
                }

                // Create a new category and add it to the inventory
                Category newCategory = new Category(categoryId, categoryName);
                inventory.AddCategory(newCategory);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid numeric value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid input. The provided value is too large.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
        #endregion

        #region Update Category

        /// <summary>
        /// Updates an existing category in the inventory.
        /// </summary>
        /// <param name="inventory">The inventory containing the category to be updated.</param>
        public static void UpdateCategory(Inventory inventory)
        {
            try
            {
                // Get updated category details from the user
                Console.Write("Enter Category ID to update: ");
                int categoryId = Convert.ToInt32(Console.ReadLine());

                Category updatedCategory = new Category(categoryId, ""); // Dummy value, will be updated

                Console.Write("Enter new Category Name: ");
                updatedCategory.SetCategoryName(Console.ReadLine());

                // Update the category in the inventory
                inventory.UpdateCategory(updatedCategory);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid numeric value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid input. The provided value is too large.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
        #endregion

        #region Remove Category

        /// <summary>
        /// Removes a category from the inventory.
        /// </summary>
        /// <param name="inventory">The inventory to remove the category from.</param>
        public static void RemoveCategory(Inventory inventory)
        {
            try
            {
                // Get category ID to remove
                Console.Write("Enter Category ID to remove: ");
                int categoryId = Convert.ToInt32(Console.ReadLine());

                // Remove the category from the inventory
                inventory.RemoveCategory(categoryId);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid numeric value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid input. The provided value is too large.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        #endregion

        #endregion
    }

}
