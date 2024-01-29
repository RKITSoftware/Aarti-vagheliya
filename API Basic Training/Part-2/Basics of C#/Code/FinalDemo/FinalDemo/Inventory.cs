using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace FinalDemo
{
    /// <summary>
    /// Represents an inventory system that manages products and categories.
    /// </summary>
    public class Inventory
    {
        //Category and Product list objects
        private List<Product> _products;
        private List<Category> _categories;
       

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory"/> class.
        /// </summary>
        public Inventory()
        {
            //Initialize instances
            _products = new List<Product>();
            _categories = new List<Category>();
           
        }
        #endregion

        #region Methods for managing products
        // Methods for managing products
        #region AddProduct

        /// <summary>
        /// Adds a product to the inventory.
        /// </summary>
        /// <param name="product">The product to add.</param>
        public void AddProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product), "Product cannot be null.");
                }

                // Validate product ID including checking for duplicates
                if (!ValidationHelper.IsProductIdValid(product.ProductId, _products))
                {
                    throw new ArgumentException("Invalid or duplicate Product ID.");
                }

                ValidateProduct(product); // Validate product before adding

                _products.Add(product);

                Console.WriteLine("Product added to inventory.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
            }
        }
        #endregion

        #region UpdateProduct

        /// <summary>
        /// Updates a product in the inventory.
        /// </summary>
        /// <param name="updatedProduct">The updated product.</param>
        public void UpdateProduct(Product updatedProduct)
        {
            try
            {
                if (updatedProduct == null)
                {
                    throw new ArgumentNullException(nameof(updatedProduct), "Updated product cannot be null.");
                }

                /*ValidateProduct(updatedProduct); */// Validate product before updating

                Product existingProduct = _products.Find(p => p.ProductId == updatedProduct.ProductId);

                if (existingProduct != null)
                {
                    // Update product details
                    existingProduct.SetProductName(updatedProduct.ProductName);
                    existingProduct.SetPrice(updatedProduct.Price);
                    existingProduct.SetQuantity(updatedProduct.QuantityInStock);

                    Console.WriteLine("Product updated successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found in inventory.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
            }
        }
        #endregion

        #region RemoveProduct

        /// <summary>
        /// Removes a product from the inventory.
        /// </summary>
        /// <param name="productId">The ID of the product to remove.</param>
        public void RemoveProduct(int productId)
        {
            try
            {
                Product productToRemove = _products.Find(p => p.ProductId == productId);
                if (productToRemove != null)
                {
                  

                    _products.Remove(productToRemove);
                        Console.WriteLine("Product removed from inventory.");
                }
                else
                {
                     Console.WriteLine("Product not found in inventory.");
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing product: {ex.Message}");
            }
        }
        #endregion

        #endregion

        #region Methods for managing categories
        // Methods for managing categories
        #region AddCategory

        /// <summary>
        /// Adds a category to the inventory.
        /// </summary>
        /// <param name="category">The category to add.</param>
        public void AddCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException(nameof(category), "Category cannot be null.");
                }

                category.Validate(_categories);
                ValidateCategory(category); // Validate category before adding


                _categories.Add(category);

               

                Console.WriteLine("Category added to inventory.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding category: {ex.Message}");
            }
        }
        #endregion

        #region UpdateCategory

        /// <summary>
        /// Updates a category in the inventory.
        /// </summary>
        /// <param name="updatedCategory">The updated category.</param>
        public void UpdateCategory(Category updatedCategory)
        {
            try
            {
                if (updatedCategory == null)
                {
                    throw new ArgumentNullException(nameof(updatedCategory), "Updated category cannot be null.");
                }

                /*ValidateCategory(updatedCategory); */// Validate category before updating

                Category existingCategory = _categories.Find(c => c.CategoryId == updatedCategory.CategoryId);

                if (existingCategory != null)
                {
                    // Update category details
                    existingCategory.SetCategoryName(updatedCategory.CategoryName);

                    Console.WriteLine("Category updated successfully.");
                }
                else
                {
                    Console.WriteLine("Category not found in inventory.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating category: {ex.Message}");
            }
        }
        #endregion

        #region RemoveCategory

        /// <summary>
        /// Removes a category from the inventory.
        /// </summary>
        /// <param name="categoryId">The ID of the category to remove.</param>
        public void RemoveCategory(int categoryId)
        {
            try
            {
                Category categoryToRemove = _categories.Find(c => c.CategoryId == categoryId);

                if (categoryToRemove != null)
                {
                    
                    _categories.Remove(categoryToRemove);
                    Console.WriteLine("Category removed from inventory.");
                }
                else
                {
                    Console.WriteLine("Category not found in inventory.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing category: {ex.Message}");
            }
        }
        #endregion

        #endregion

        #region  Methods for display data
        // Display methods

        #region Displayproducts

        /// <summary>
        /// Displays the list of products in the inventory using DataTable.
        /// </summary>
        public void DisplayProducts()
        {
            //Create instance of DataTable
            DataTable productTable = new DataTable();

            //Add column name to the table
            productTable.Columns.Add("Product ID", typeof(int));
            productTable.Columns.Add("Product Name", typeof(string));
            productTable.Columns.Add("Price", typeof(decimal));
            productTable.Columns.Add("Quantity in Stock", typeof(int));

            //loop for add data to the datatable
            foreach (Product product in _products)
            {
                productTable.Rows.Add(product.ProductId, product.ProductName, product.Price, product.QuantityInStock);
            }

            //call DisplayDataTable method to print the data
            DisplayDataTable("products in Inventory:", productTable);

            // Write the DataTable to a file
            WriteDataTableToFile("products.txt", productTable);
        }
        #endregion

        #region DisplayCategories

        /// <summary>
        /// Displays the list of categories in the inventory using DataTable.
        /// </summary>
        public void DisplayCategories()
        {
            //Create instance of DataTable
            DataTable categoryTable = new DataTable();

            //Add column name to the table
            categoryTable.Columns.Add("Category ID", typeof(int));
            categoryTable.Columns.Add("Category Name", typeof(string));

            //loop for add data to the datatable
            foreach (Category category in _categories)
            {
                categoryTable.Rows.Add(category.CategoryId, category.CategoryName);
            }

            //call DisplayDataTable method to print the data
            DisplayDataTable("Categories in Inventory:", categoryTable);

            // Write the DataTable to a file
            WriteDataTableToFile("Categories.txt", categoryTable);
        }
        #endregion

        #region DisplayDataTable

        /// <summary>
        /// Display data in DataTable  formate
        /// </summary>
        /// <param name="title">Write title of the table.</param>
        /// <param name="table">DataTable to display.</param>
        private void DisplayDataTable(string title, DataTable table)
        {
            Console.WriteLine(title);
            //lopp for column name
            foreach (DataColumn column in table.Columns)
            {
                Console.Write($"{column.ColumnName,-15}");
            }
            Console.WriteLine();

            //loop for datatable's row
            foreach (DataRow row in table.Rows)
            {
                //loop for dataItem
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item,-15}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------");
        }

        #endregion

        #region WriteDataTableToFile

        /// <summary>
        /// Writes the contents of a DataTable to a text file.
        /// </summary>
        /// <param name="fileName">The name of the file to write to.</param>
        /// <param name="table">The DataTable containing the data to write.</param>
        private void WriteDataTableToFile(string fileName, DataTable table)
        {
            try
            {
                // Get the full path of the file in the current application directory
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                // Use a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(fullPath))
                {
                    // Write column names to the file
                    foreach (DataColumn column in table.Columns)
                    {
                        // Write each column name with a width of 15 characters
                        writer.Write($"{column.ColumnName,-15}");
                    }
                    // Move to the next line after writing column names
                    writer.WriteLine();

                    // Write data rows to the file
                    foreach (DataRow row in table.Rows)
                    {
                        // Write each data item with a width of 15 characters
                        foreach (var item in row.ItemArray)
                        {
                            writer.Write($"{item,-15}");
                        }
                        writer.WriteLine();
                    }
                }

                // Display a message indicating successful writing to the file
                Console.WriteLine($"Data written to {fullPath}.");
            }
            catch (IOException ex)
            {
                // Display an error message if an exception occurs during writing
                Console.WriteLine($"Error writing to {fileName}: {ex.Message}");
            }
        }

        #endregion

        #endregion

        #region Methods for validation
        // Validation methods

        #region ValidateProduct

        /// <summary>
        /// This method validate the product, when new product added 
        /// </summary>
        /// <param name="product">The product to be add.</param>
        /// <exception cref="ArgumentException"></exception>
        private void ValidateProduct(Product product)
        {
            //Validation for product ID
            if (!ValidationHelper.IsProductIdValid(product.ProductId, _products))
            {
                throw new ArgumentException("Invalid Product ID. Please provide a positive integer value.");
            }

            //Validation for product Name
            if (!ValidationHelper.IsProductNameValid(product.ProductName))
            {
                throw new ArgumentException("Invalid Product Name. Please provide a non-empty string.");
            }

            //Validation for price
            if (!ValidationHelper.IsPriceValid(product.Price))
            {
                throw new ArgumentException("Invalid Price. Please provide a non-negative value.");
            }

            //Validation for Quantity stock
            if (!ValidationHelper.IsQuantityInStockValid(product.QuantityInStock))
            {
                throw new ArgumentException("Invalid Quantity in Stock. Please provide a non-negative integer value.");
            }
        }
        #endregion

        #region ValidateCategory

        /// <summary>
        /// This method validate the Category information
        /// </summary>
        /// <param name="category">Category to add.</param>
        /// <exception cref="ArgumentException"></exception>
        private void ValidateCategory(Category category)
        {
            //Validate Category Id
            if (!ValidationHelper.IsCategoryIdValid(category.CategoryId, _categories))
            {
                throw new ArgumentException("Invalid Category ID. Please provide a positive integer value.");
            }

            // Validate the Category Name
            if (!ValidationHelper.IsCategoryNameValid(category.CategoryName))
            {
                throw new ArgumentException("Invalid Category Name. Please provide a non-empty string.");
            }
        }
        #endregion

        #endregion

       

    }



}
