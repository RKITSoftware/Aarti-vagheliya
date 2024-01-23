using System;
using System.Data;

/// <summary>
/// Demonstrate datatable in c#
/// </summary>
class Program
{
    #region Create DataTable
    /// <summary>
    /// Crteate Datatable and add some data
    /// </summary>
    /// <returns>DataTable</returns>
    static DataTable CreateDataTable()
    {
        DataTable dataTable = new DataTable("Student");

        // Adding columns
        dataTable.Columns.Add("ID", typeof(int));
        dataTable.Columns.Add("Name", typeof(string));
        dataTable.Columns.Add("Age", typeof(int));

        // Adding a unique constraint
        UniqueConstraint uniqueConstraint = new UniqueConstraint(dataTable.Columns["ID"]);
        dataTable.Constraints.Add(uniqueConstraint);

        // Adding some sample data
        dataTable.Rows.Add(1, "John", 25);
        dataTable.Rows.Add(2, "Alice", 22);
        dataTable.Rows.Add(3, "Bob", 28);

        return dataTable;
    }
    #endregion

    #region Display DataTable

    /// <summary>
    /// This method displays datatable' data
    /// </summary>
    /// <param name="dataTable"></param>
    static void DisplayDataTable(DataTable dataTable)
    {
        Console.WriteLine("Student Table:");
        Console.WriteLine("ID\tName\tAge");

        //loop iterate over table
        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine($"{row["ID"]}\t{row["Name"]}\t{row["Age"]}");
        }
        Console.WriteLine();
    }
    #endregion

    static void Main()
    {
        // Creating and displaying DataTable
        DataTable studentTable = CreateDataTable();
        DisplayDataTable(studentTable);

        // Adding a new row
        DataRow newRow = studentTable.NewRow();
        newRow["ID"] = 4;
        newRow["Name"] = "Eva";
        newRow["Age"] = 23;
        studentTable.Rows.Add(newRow);
        Console.WriteLine("Added a new student.\n");

        // Modifying data
        Console.WriteLine("Modifying data...");
        studentTable.Rows[0]["Age"] = 26;
        DisplayDataTable(studentTable);

        // Removing a row
        Console.WriteLine("Removing a student...");
        studentTable.Rows.RemoveAt(1);
        DisplayDataTable(studentTable);

        // Sorting using DataView
        DataView dataView = new DataView(studentTable);
        dataView.Sort = "Name ASC";
        Console.WriteLine("Sorted by Name:");
        DisplayDataTable(dataView.ToTable());

    }
}
