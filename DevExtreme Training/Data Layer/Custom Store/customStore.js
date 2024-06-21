$(() => {

    const SERVICE_URL = "https://localhost:7242/api/CLNovel";

    var customStore = new DevExpress.data.CustomStore({
        key: "l01F01", // Unique identifier for each item
        cacheRawData: true,
        // loadMode : "raw", //  'processed' | 'raw'
        onInserted: function (values, key) {
            console.log("Item Inserted:", values, "with Key:", key);
        },
        onInserting: function (values) {
            console.log("Item Inserting:", values);
        },
        onLoaded: function (result) {
            console.log("Data Loaded:", result);
        },
        onLoading: function (loadOptions) {
            console.log("Data Loading with Options:", loadOptions);
        },
        onModified: function () {
            console.log("Data Modified");
        },
        onModifying: function () {
            console.log("Data Modifying");
        },
        onPush: function (changes) {
            console.log("Data Pushed to Store:", changes);
        },
        onRemoved: function (key) {
            console.log("Item Removed with Key:", key);
        },
        onRemoving: function (key) {
            console.log("Item Removing with Key:", key);
        },
        onUpdated: function (key, values) {
            console.log("Item Updated with Key:", key, "and New Values:", values);
        },
        onUpdating: function (key, values) {
            console.log("Item Updating with Key:", key, "and New Values:", values);
        },
        errorHandler: function (error) {
            console.error("An error occurred:", error.message);
        },

        load: function (loadOptions) {

            // const skip = loadOptions.skip || 0; // Number of items to skip (offset)
            // const take = loadOptions.take || 5; // Number of items to take (limit)

            //  // Construct the query parameters for pagination
            // const queryParams = {
            //     skip: skip,
            //     take: take
            // };

            //  // Fetch data from the API with pagination
            // return $.ajax({
            //     url: SERVICE_URL + "/GetNovels",
            //     method: "GET",
            //     data: queryParams, // Pass the pagination parameters as query string
            //     dataType: "json"
            // })
            // .then(response => {
            //     // Transform the response if necessary and return the paginated data
            //     return {
            //         data: response.data, // The data array
            //         totalCount: response.totalCount // Total number of records (for pagination)
            //     };
            // })
            // .fail(function (jqXHR, textStatus, errorThrown) {
            //     console.error("Load failed: ", textStatus, errorThrown);
            // });

            // Fetch data from the API
            return $.getJSON(SERVICE_URL + "/GetNovels")
                .then(data => {
                    // Optionally transform the data if needed
                    return { data: data, totalCount: data.length };
                })
                .fail(function (errorThrown) {
                    console.error("Load failed: ", errorThrown);
                });
        },

        byKey: function (key) {
            // Fetch an item by its key
            return $.getJSON(SERVICE_URL + "/GetNovelById?id=" + encodeURIComponent(key))
                .fail(function (errorThrown) {
                    console.error("byKey failed: ", errorThrown);
                });
        },

        insert: function (values) {
            // Insert a new item using the specific AddNovel endpoint
            return $.ajax({
                url: SERVICE_URL + "/AddNovel",
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(values)
            }).fail(function (errorThrown) {
                console.error("Insert failed: ", errorThrown);
            });
        },

        update: function (key, partialValues) {
            // Fetch the existing data for the key
            $.ajax({
                url: SERVICE_URL +  "/GetNovelById?id=" + encodeURIComponent(key), 
                method: "GET",
                contentType: "application/json"
            })
            .done(function (existingData) {
                // Merge the existing data with the new values
                let updatedData = { ...existingData, ...partialValues };
                
                // Ensure the key is included in the updated data
                updatedData.l01F01 = key;
        
                // Send the entire updated object back to the server
                $.ajax({
                    url: SERVICE_URL + "/UpdateNovelData",
                    method: "PUT",
                    contentType: "application/json",
                    data: JSON.stringify(updatedData)
                })
                .done(function (response) {
                    console.log("Update successful:", response);
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    console.error("Update failed:", textStatus, errorThrown);
                    if (jqXHR.responseText) {
                        console.error("Server response:", jqXHR.responseText);
                    }
                });
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.error("Failed to fetch existing data:", textStatus, errorThrown);
                if (jqXHR.responseText) {
                    console.error("Server response:", jqXHR.responseText);
                }
            });
        },
        
        remove: function (key) {
            // Remove an item by its key using the specific DeleteNovel endpoint
            return $.ajax({
                url: SERVICE_URL + "/DeleteNovel?id=" + encodeURIComponent(key),
                method: "DELETE"
            }).fail(function (errorThrown) {
                console.error("Remove failed: ", errorThrown);
            });
        }
    });



    // Bind CustomStore to DataGrid
    $("#customStore").dxDataGrid({
        dataSource: customStore,
        columns: [
            { dataField: "l01F01", caption: "ID", width: 50 },
            { dataField: "l01F02", caption: "Title" },
            { dataField: "l01F03", caption: "Author" },
            { dataField: "l01F04", caption: "Price" }
        ],
        showBorders: true,
        editing: {
            mode: "row",
            allowUpdating: true,
            allowDeleting: true,
            allowAdding: true
        }
    });

    // Adding event handlers for customStore using the on and off methods
    customStore.on('loading', function (loadOptions) {
        console.log("Loading event triggered with options:", loadOptions);
    });

    customStore.off('loading'); // Unregisters the loading event

    customStore.on('loaded', function (result) {
        console.log("Loaded event triggered with result:", result);
    });

    customStore.on('inserting', function (values) {
        console.log("Inserting event triggered with values:", values);
    });

    customStore.off('inserting'); // Unregisters the inserting event

    customStore.on('inserted', function (values, key) {
        console.log("Inserted event triggered with values:", values, "and key:", key);
    });
});