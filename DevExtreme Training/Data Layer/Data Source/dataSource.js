$(() => {

    
    // Create a DataSource
    const dataSource = new DevExpress.data.DataSource({
        store: items, // Define the data source
        sort: { field: "Name", desc: false }, // Sort by Name in ascending order
        //filter: ["Category", "=", "Vegetables"], // Filter to include only 'Fruits' category
        paginate: true, // Enable pagination
        pageSize: 3, // Items per page
        requireTotalCount: true, // Include the total count of items
        reshapeOnPush: true, // Automatically reshape data when pushed
        searchExpr: "Name", // Search by 'Name' field
        searchOperation: "contains", // Search operation is 'contains'
        searchValue: "", // Initial search value
        customQueryParams: { extraParam: 1 }, // Example of custom parameters
        expand: ["Category"], // Automatically load related categories (if any)
        //group: ["Category"], // Group items by 'Category'
        select: ["ID", "Name"], // Only include ID and Name in the output
        postProcess: function(data) { // Modify data after processing
            // This modifies the dataset to append ' (filtered)' to all names
            return data.map(item => ({ ...item, Name: item.Name + ' (filtered)' }));
        },
        onChanged: function() {
            console.log("Data has changed.");
        },
        onLoadError: function(error) {
            console.error("Data loading error: ", error);
        },
        onLoadingChanged: function(isLoading) {
            console.log("Data loading state changed: ", isLoading);
        }
    });

    // Fetch and load data into the select box
    function loadSelectBox(dataSource) {
        dataSource.load().then((data) => {
            const selectBox = $('#selectBox');
            selectBox.empty();
            data.forEach(item => {
                selectBox.append($('<option>', {
                    value: item.ID,
                    text: item.Name
                }));
            });
        });
    }

    // Initial load
    loadSelectBox(dataSource);

    // Event listener for selection change
    $('#selectBox').on('change', function () {
        const selectedId = $(this).val();
        const selectedItem = items.find(item => item.ID == selectedId);
        $('#dataDisplay').html(`<pre>${JSON.stringify(selectedItem, null, 2)}</pre>`);
    });

    // Log additional information
    console.log("Total count:", dataSource.totalCount());
    console.log("Filtered and sorted data:", dataSource.items());

});









// <!DOCTYPE html>
// <html lang="en">
// <head>
//     <meta charset="UTF-8">
//     <meta name="viewport" content="width=device-width, initial-scale=1.0">
//     <title>DevExtreme DataSource Methods and Events Demo</title>
//     <link rel="stylesheet" href="https://cdn3.devexpress.com/jslib/21.1.3/css/dx.common.css">
//     <link rel="stylesheet" href="https://cdn3.devexpress.com/jslib/21.1.3/css/dx.light.css">
//     <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
//     <script src="https://cdn3.devexpress.com/jslib/21.1.3/js/dx.all.js"></script>
//     <style>
//         body {
//             font-family: Arial, sans-serif;
//             margin: 20px;
//         }
//         .section {
//             margin-bottom: 20px;
//         }
//         .controls {
//             margin-top: 20px;
//         }
//         button {
//             margin-right: 10px;
//             margin-bottom: 10px;
//         }
//         #dataDisplay, #consoleOutput {
//             background-color: #f9f9f9;
//             padding: 10px;
//             border: 1px solid #ddd;
//             border-radius: 5px;
//             max-height: 200px;
//             overflow-y: auto;
//         }
//     </style>
// </head>
// <body>
//     <h1>DevExtreme DataSource Methods and Events Demo</h1>

//     <div class="section">
//         <label for="selectBox">Select an Item:</label>
//         <div id="selectBox"></div>
//     </div>

//     <div class="section controls">
//         <button id="reloadBtn">Reload Data</button>
//         <button id="sortBtn">Sort by Name</button>
//         <button id="filterBtn">Filter Fruits</button>
//         <button id="groupBtn">Group by Category</button>
//         <button id="pageSizeBtn">Set Page Size to 2</button>
//         <button id="nextPageBtn">Next Page</button>
//         <button id="totalCountBtn">Get Total Count</button>
//     </div>

//     <div class="section" id="demoContainer">
//         <h2>Selected Data:</h2>
//         <div id="dataDisplay">Select an item to see its details here.</div>
//     </div>

//     <div class="section">
//         <h2>Console Output:</h2>
//         <div id="consoleOutput"></div>
//     </div>

//     <script>
//         // Sample dataset of items
//         const items = [
//             { ID: 1, Name: "Apple", Category: "Fruits", Price: 1.2, Stock: 100 },
//             { ID: 2, Name: "Banana", Category: "Fruits", Price: 0.5, Stock: 150 },
//             { ID: 3, Name: "Carrot", Category: "Vegetables", Price: 0.8, Stock: 200 },
//             { ID: 4, Name: "Broccoli", Category: "Vegetables", Price: 1.5, Stock: 80 },
//             { ID: 5, Name: "Orange", Category: "Fruits", Price: 1.0, Stock: 120 },
//             { ID: 6, Name: "Cucumber", Category: "Vegetables", Price: 0.6, Stock: 90 },
//             { ID: 7, Name: "Grapes", Category: "Fruits", Price: 2.0, Stock: 60 },
//             { ID: 8, Name: "Tomato", Category: "Vegetables", Price: 1.2, Stock: 70 }
//         ];

//         // Create a DataSource
//         const dataSource = new DevExpress.data.DataSource({
//             store: items, // Define the data source
//             sort: { field: "Name", desc: false }, // Sort by Name in ascending order
//             filter: ["Category", "=", "Fruits"], // Filter to include only 'Fruits' category
//             paginate: true, // Enable pagination
//             pageSize: 3, // Items per page
//             requireTotalCount: true, // Include the total count of items
//             reshapeOnPush: true, // Automatically reshape data when pushed
//             searchExpr: "Name", // Search by 'Name' field
//             searchOperation: "contains", // Search operation is 'contains'
//             searchValue: "", // Initial search value
//             customQueryParams: { extraParam: 1 }, // Example of custom parameters
//             expand: ["Category"], // Automatically load related categories (if any)
//             group: ["Category"], // Group items by 'Category'
//             select: ["ID", "Name", "Category"], // Only include ID and Name in the output
//             postProcess: function(data) { // Modify data after processing
//                 return data;
//             },
//             onChanged: function() {
//                 consoleOutput("Data has changed.");
//             },
//             onLoadError: function(error) {
//                 consoleOutput("Data loading error: " + error);
//             },
//             onLoadingChanged: function(isLoading) {
//                 consoleOutput("Data loading state changed: " + isLoading);
//             }
//         });

//         // Function to log messages to the console output div
//         function consoleOutput(message) {
//             const consoleDiv = $('#consoleOutput');
//             consoleDiv.append('<p>' + message + '</p>');
//             consoleDiv.scrollTop(consoleDiv[0].scrollHeight);
//         }

//         // Initialize the DevExtreme select box
//         $("#selectBox").dxSelectBox({
//             dataSource: dataSource,
//             displayExpr: "Name",
//             valueExpr: "ID",
//             onValueChanged: function(e) {
//                 const selectedItem = items.find(item => item.ID == e.value);
//                 $('#dataDisplay').html(`<pre>${JSON.stringify(selectedItem, null, 2)}</pre>`);
//                 consoleOutput("Item selected: " + selectedItem.Name);
//             }
//         });

//         // Bind actions to buttons
//         $('#reloadBtn').on('click', function () {
//             dataSource.reload().done(function() {
//                 consoleOutput("Data reloaded.");
//             });
//         });

//         $('#sortBtn').on('click', function () {
//             dataSource.sort('Price', true); // Sort by Price in descending order
//             dataSource.reload().done(function() {
//                 consoleOutput("Data sorted by Price in descending order.");
//             });
//         });

//         $('#filterBtn').on('click', function () {
//             dataSource.filter(['Category', '=', 'Vegetables']); // Filter to show only Vegetables
//             dataSource.reload().done(function() {
//                 consoleOutput("Data filtered to show only Vegetables.");
//             });
//         });

//         $('#groupBtn').on('click', function () {
//             dataSource.group(['Category']); // Group by Category
//             dataSource.reload().done(function() {
//                 consoleOutput("Data grouped by Category.");
//             });
//         });

//         $('#pageSizeBtn').on('click', function () {
//             dataSource.pageSize(2); // Set page size to 2
//             dataSource.reload().done(function() {
//                 consoleOutput("Page size set to 2.");
//             });
//         });

//         $('#nextPageBtn').on('click', function () {
//             const currentPage = dataSource.pageIndex();
//             dataSource.pageIndex(currentPage + 1); // Go to next page
//             dataSource.reload().done(function() {
//                 consoleOutput("Moved to the next page.");
//             });
//         });

//         $('#totalCountBtn').on('click', function () {
//             dataSource.totalCount().done(function(count) {
//                 consoleOutput("Total count of items: " + count);
//             });
//         });

//         // Additional console log to demonstrate other DataSource methods
//         consoleOutput("Is loaded: " + dataSource.isLoaded());
//         consoleOutput("Is last page: " + dataSource.isLastPage());
//         consoleOutput("Is loading: " + dataSource.isLoading());
//     </script>
// </body>
// </html>
