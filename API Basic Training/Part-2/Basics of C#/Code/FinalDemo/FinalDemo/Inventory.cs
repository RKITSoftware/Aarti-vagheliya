using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDemo
{


    public class Inventory
    {
        private List<Product> products;
        private List<Category> categories;

        public Inventory()
        {
            products = new List<Product>();
            categories = new List<Category>();
        }

        // Methods for managing products
        public void AddProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product), "Product cannot be null.");
                }

                // Additional validation if needed

                products.Add(product);
                Console.WriteLine("Product added to inventory.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
            }
        }

        public void UpdateProduct(Product updatedProduct)
        {
            try
            {
                if (updatedProduct == null)
                {
                    throw new ArgumentNullException(nameof(updatedProduct), "Updated product cannot be null.");
                }

                Product existingProduct = products.Find(p => p.ProductId == updatedProduct.ProductId);

                if (existingProduct != null)
                {
                    // Update product details
                    existingProduct.SetProductName(updatedProduct.ProductName);
                    existingProduct.SetPrice(updatedProduct.Price);
                    existingProduct.AddStock(updatedProduct.QuantityInStock);

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

        public void RemoveProduct(int productId)
        {
            try
            {
                Product productToRemove = products.Find(p => p.ProductId == productId);

                if (productToRemove != null)
                {
                    products.Remove(productToRemove);
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

        // Methods for managing categories
        public void AddCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException(nameof(category), "Category cannot be null.");
                }

                // Additional validation if needed

                categories.Add(category);
                Console.WriteLine("Category added to inventory.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding category: {ex.Message}");
            }
        }

        public void UpdateCategory(Category updatedCategory)
        {
            try
            {
                if (updatedCategory == null)
                {
                    throw new ArgumentNullException(nameof(updatedCategory), "Updated category cannot be null.");
                }

                Category existingCategory = categories.Find(c => c.CategoryId == updatedCategory.CategoryId);

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

        public void RemoveCategory(int categoryId)
        {
            try
            {
                Category categoryToRemove = categories.Find(c => c.CategoryId == categoryId);

                if (categoryToRemove != null)
                {
                    categories.Remove(categoryToRemove);
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

        // Display methods
        public void DisplayProducts()
        {
            Console.WriteLine("Products in Inventory:");
            foreach (Product product in products)
            {
                product.DisplayProductInfo();
                Console.WriteLine("------------------------");
            }
        }

        public void DisplayCategories()
        {
            Console.WriteLine("Categories in Inventory:");
            foreach (Category category in categories)
            {
                Console.WriteLine($"Category ID: {category.CategoryId}");
                Console.WriteLine($"Category Name: {category.CategoryName}");
                Console.WriteLine("------------------------");
            }
        }
    }


}
