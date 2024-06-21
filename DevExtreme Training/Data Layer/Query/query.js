$(() => {

    const products = [
        { ID: 1, Name: "Apple", Category: "Fruits", Price: 1.2, Quantity: 100 },
        { ID: 2, Name: "Banana", Category: "Fruits", Price: 0.5, Quantity: 150 },
        { ID: 3, Name: "Carrot", Category: "Vegetables", Price: 0.8, Quantity: 200 },
        { ID: 4, Name: "Broccoli", Category: "Vegetables", Price: 1.5, Quantity: 80 },
        { ID: 5, Name: "Orange", Category: "Fruits", Price: 1.0, Quantity: 120 },
        { ID: 6, Name: "Cucumber", Category: "Vegetables", Price: 0.6, Quantity: 90 },
        { ID: 7, Name: "Grapes", Category: "Fruits", Price: 2.0, Quantity: 60 },
        { ID: 8, Name: "Tomato", Category: "Vegetables", Price: 1.2, Quantity: 70 }
    ];
    
    // Initialize DevExtreme Query
    const query = DevExpress.data.query(products);

    // Execute various query operations and log the results
    console.log("1. Fruits:");
    console.log(query.filter(["Category", "=", "Fruits"]).toArray());

    console.log("2. Sorted by Price (Asc):");
    console.log(query.sortBy("Price").toArray());

    console.log("3. Sorted by Price (Desc):");
    console.log(query.sortBy("Price", true).toArray());

    console.log("4. Product Names:");
    console.log(query.select("Name").toArray());

    console.log("5. Grouped by Category:");
    console.log(query.groupBy("Category").toArray());

    console.log("6. Total Quantity:");
    console.log(query.aggregate(0, (sum, item) => sum + item.Quantity));

    console.log("7. Average Price:");
    console.log(query.avg("Price"));

    console.log("8. Product Count:");
    console.log(query.count());

    console.log("9. Max Price:");
    console.log(query.max("Price"));

    console.log("10. Min Price:");
    console.log(query.min("Price"));

    console.log("11. First Three Products:");
    console.log(query.slice(0, 3).toArray());

    console.log("12. Expensive Products (Price > 1.0):");
    console.log(query.filter(product => product.Price > 1.0).toArray());

    console.log("13. Sorted Vegetables by Price (Desc):");
    console.log(query.filter(["Category", "=", "Vegetables"]).sortBy("Price", true).toArray());

    console.log("14. Total Price:");
    console.log(query.sum("Price"));

    console.log("15. Product Names and Prices:");
    console.log(query.select(item => ({ Name: item.Name, Price: item.Price })).toArray());

    console.log("16. Sorted by Category then Price:");
    console.log(query.sortBy("Category").thenBy("Price").toArray());

    console.log("17. Category Summary:");
    console.log(query.groupBy("Category").aggregate({
        totalQuantity: (sum, item) => sum + item.Quantity,
        totalPrice: (sum, item) => sum + item.Price
    }));

});








// $(() => {
//         const products = [
//                 { ID: 1, Name: "Apple", Category: "Fruits", Price: 1.2, Quantity: 100 },
//                 { ID: 2, Name: "Banana", Category: "Fruits", Price: 0.5, Quantity: 150 },
//                 { ID: 3, Name: "Carrot", Category: "Vegetables", Price: 0.8, Quantity: 200 },
//                 { ID: 4, Name: "Broccoli", Category: "Vegetables", Price: 1.5, Quantity: 80 },
//                 { ID: 5, Name: "Orange", Category: "Fruits", Price: 1.0, Quantity: 120 },
//                 { ID: 6, Name: "Cucumber", Category: "Vegetables", Price: 0.6, Quantity: 90 },
//                 { ID: 7, Name: "Grapes", Category: "Fruits", Price: 2.0, Quantity: 60 },
//                 { ID: 8, Name: "Tomato", Category: "Vegetables", Price: 1.2, Quantity: 70 }
//             ];

//      // Initialize DevExtreme Query
//      const query = DevExpress.data.query(products);

//      // Execute various query operations and log the results
//      const results = [];

//      // 1. Filter: Get all fruits
//      const fruits = query.filter(["Category", "=", "Fruits"]).toArray();
//      results.push("Fruits:", fruits);

//      // 2. Sort by Price in ascending order
//      const sortedByPriceAsc = query.sortBy("Price").toArray();
//      results.push("Sorted by Price (Asc):", sortedByPriceAsc);

//      // 3. Sort by Price in descending order
//      const sortedByPriceDesc = query.sortBy("Price", true).toArray();
//      results.push("Sorted by Price (Desc):", sortedByPriceDesc);

//      // 4. Select: Get an array of product names
//      const productNames = query.select("Name").toArray();
//      results.push("Product Names:", productNames);

//      // 5. Group by Category
//      const groupedByCategory = query.groupBy("Category").toArray();
//      results.push("Grouped by Category:", groupedByCategory);

//      // 6. Aggregate: Calculate the total quantity of all products
//      const totalQuantity = query.aggregate(0, (sum, item) => sum + item.Quantity);
//      results.push("Total Quantity:", totalQuantity);

//      // 7. Avg: Calculate the average price of all products
//      const averagePrice = query.avg("Price");
//      results.push("Average Price:", averagePrice);

//      // 8. Count: Get the number of products
//      const productCount = query.count();
//      results.push("Product Count:", productCount);

//      // 9. Max: Get the maximum price
//      const maxPrice = query.max("Price");
//      results.push("Max Price:", maxPrice);

//      // 10. Min: Get the minimum price
//      const minPrice = query.min("Price");
//      results.push("Min Price:", minPrice);

//      // 11. Slice: Get the first 3 products (paging example)
//      const firstThreeProducts = query.slice(0, 3).toArray();
//      results.push("First Three Products:", firstThreeProducts);

//      // 12. Filter with custom predicate: Get products with price greater than 1.0
//      const expensiveProducts = query.filter(product => product.Price > 1.0).toArray();
//      results.push("Expensive Products (Price > 1.0):", expensiveProducts);

//      // 13. Multiple Operations: Get all vegetables sorted by price descending
//      const sortedVegetables = query
//          .filter(["Category", "=", "Vegetables"])
//          .sortBy("Price", true)
//          .toArray();
//      results.push("Sorted Vegetables by Price (Desc):", sortedVegetables);

//      // 14. Sum: Calculate the total price of all products
//      const totalPrice = query.sum("Price");
//      results.push("Total Price:", totalPrice);

//      // 15. Enumerate: Get an array of product names and prices
//      const namePriceArray = query.select(item => ({ Name: item.Name, Price: item.Price })).toArray();
//      results.push("Product Names and Prices:", namePriceArray);

//      // 16. ThenBy: Sort by Category, then by Price within each category
//      const sortedByCategoryThenPrice = query
//          .sortBy("Category")
//          .thenBy("Price")
//          .toArray();
//      results.push("Sorted by Category then Price:", sortedByCategoryThenPrice);

//      // 17. Advanced Aggregate: Calculate the total price and quantity per category
//      const categorySummary = query.groupBy("Category").aggregate({
//          totalQuantity: (sum, item) => sum + item.Quantity,
//          totalPrice: (sum, item) => sum + item.Price
//      });
//      results.push("Category Summary:", categorySummary);

//      // Display results in the output div
//      $('#results').text(JSON.stringify(results, null, 2));
// });
