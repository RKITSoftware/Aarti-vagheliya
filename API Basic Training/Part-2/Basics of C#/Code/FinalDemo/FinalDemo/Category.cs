using System;

namespace FinalDemo
{
    /// <summary>
    /// Represents a category in the inventory.
    /// </summary>
    public class CategoryModel
    {
        #region Public Properties 

        /// <summary>
        /// Gets or sets the ID of the category.
        /// </summary>
        public int CategoryId { get;  set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string CategoryName { get;  set; }

        #endregion
    }

    /// <summary>
    /// Represents methods for managing categories in the inventory.
    /// </summary>
    public class Category
    {
        #region Public Methods

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

                // Create a new category
                CategoryModel newCategory = new CategoryModel
                {
                    CategoryId = categoryId,
                    CategoryName = categoryName
                };

                // Add the category to the inventory
                inventory.AddCategory(newCategory);
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

                Console.Write("Enter new Category Name: ");
                string categoryName = Console.ReadLine();

                // Create a new category
                CategoryModel updatedCategory = new CategoryModel
                {
                    CategoryId = categoryId,
                    CategoryName = categoryName
                };

                // Update the category in the inventory
                inventory.UpdateCategory(updatedCategory);
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
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        #endregion

        #endregion
    }
}
