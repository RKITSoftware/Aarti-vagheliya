// import { stateData } from "./Data.js";

$(() => {

    // Create an ArrayStore
    var arrayStore = new DevExpress.data.ArrayStore({
        key: "ID", // Unique identifier
        data: stateData,// Array data source
        errorHandler: function (error) {
            console.log("Error occured : ", error.message);
        },
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
    });

    //Methods of ArrayStore
    console.log("loading data : ", arrayStore.load());
    console.log("byKey(key) : ", arrayStore.byKey("ID"));
    var query = arrayStore.createQuery();
    console.log("createQuery : ", query);
    arrayStore.insert({ ID: 11, State: "Jammu kashmir", Country: "India" })
    .done(function (dataObj, key) {
       console.log("data inserted successfully.");
    })
    .fail(function (error) {
        console.log("Failed to insert data..!!");
    });
    console.log("key = ", arrayStore.key());
    console.log("Key(Object) : ", arrayStore.keyOf({ ID: 11, State: "Jammu kashmir", Country: "India" }));
    console.log("Remove : ",arrayStore.remove(2));
    arrayStore.push([{ type: "insert", data: { ID: 12, State: "UP", Country: "India" } }]);
    arrayStore.push([{ type: "update", data: { ID: 11, State: "MP", Country: "India" }, key: 11 }]);
    arrayStore.push([{ type: "remove", key: 5 }]);
    console.log("Total Count = ",arrayStore.totalCount());
    console.log("Updated data : ", arrayStore.update(4, { State:"State" }));
    //arrayStore.clear();




    // Bind the ArrayStore to a DataGrid
    $("#arrayStore").dxDataGrid({
        dataSource: arrayStore, // Use the ArrayStore as the data source
        columns: [
            { dataField: "ID", caption: "ID", width: 50 },
            { dataField: "State", caption: "State" },
            { dataField: "Country", caption: "Country" }
        ],
        showBorders: true, // Show grid borders
        paging: { enabled: false }, // Disable paging for this example
        editing: {
            mode: "row", // Allow row editing
            allowUpdating: true, // Enable updating
            allowDeleting: true, // Enable deleting
            allowAdding: true // Enable adding
        }
    });

});
