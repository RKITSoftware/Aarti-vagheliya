$(function () {

    const stateData = [
        { ID: 1, State: "California", Country: "United States" },
        { ID: 2, State: "Bavaria", Country: "Germany" },
        { ID: 3, State: "Queensland", Country: "Australia" },
        { ID: 4, State: "Maharashtra", Country: "India" },
        { ID: 5, State: "Ontario", Country: "Canada" },
        { ID: 6, State: "São Paulo", Country: "Brazil" },
        { ID: 7, State: "New South Wales", Country: "Australia" },
        { ID: 8, State: "Texas", Country: "United States" },
        { ID: 9, State: "Hessen", Country: "Germany" },
        { ID: 10, State: "British Columbia", Country: "Canada" }
    ];


    var localStore = new DevExpress.data.LocalStore({
        name: "StateCountryStore", // The key used in local storage
        key: "ID", // Unique identifier for each item
        data: stateData, // Initial data
        immediate: false,
        flushInterval: 3000,

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
        }
    });

    //Methods of LocalStore
    console.log("loading data : ", localStore.load());
    console.log("byKey(key) : ", localStore.byKey("ID"));
    var query = localStore.createQuery();
    console.log("createQuery : ", query);
    localStore.insert({ ID: 11, State: "Jammu kashmir", Country: "India" })
        .done(function (dataObj, key) {
            console.log("data inserted successfully.");
        })
        .fail(function (error) {
            console.log("Failed to insert data..!!");
        });
    console.log("key = ", localStore.key());
    console.log("Key(Object) : ", localStore.keyOf({ ID: 11, State: "Jammu kashmir", Country: "India" }));
    console.log("Remove : ", localStore.remove(2));
    localStore.push([{ type: "insert", data: { ID: 12, State: "Oddisa", Country: "India" } }]);
    localStore.push([{ type: "update", data: { ID: 11, State: "Telangana", Country: "India" }, key: 11 }]);
    localStore.push([{ type: "remove", key: 5 }]);
    console.log("Total Count = ", localStore.totalCount());
    console.log("Updated data : ", localStore.update(4, { State: "State" }));
    //localStore.clear();

    // Example usage of event handling methods
    function exampleEventHandler() {
        console.log("Example event handler triggered");
    }

    // Attach an event handler
    localStore.on("loaded", exampleEventHandler);

    // Detach the event handler
    localStore.off("modified", exampleEventHandler);

    // Bind LocalStore to DataGrid
    $("#localStore").dxDataGrid({
        dataSource: localStore,
        columns: [
            { dataField: "ID", caption: "ID", width: 50 },
            { dataField: "State", caption: "State" },
            { dataField: "Country", caption: "Country" }
        ],
        showBorders: true,
        editing: {
            mode: "row",
            allowUpdating: true,
            allowDeleting: true,
            allowAdding: true
        }
    });
});