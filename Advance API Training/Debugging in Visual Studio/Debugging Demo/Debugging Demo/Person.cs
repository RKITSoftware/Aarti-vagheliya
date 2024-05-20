using System.Data;

namespace Debugging_Demo
{
    // Nested Address class
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
    }


    /// <summary>
    /// Represents a person with a name, age, and additional details stored in a DataTable.
    /// </summary>
    public class Person
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the person.
        /// </summary>
        public int Age { get; set; }

        public Address HomeAddress { get; set; }

        /// <summary>
        /// Gets or sets the details of the person stored in a DataTable.
        /// </summary>
        public DataTable Details { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            Details = new DataTable();
            Details.Columns.Add("Key", typeof(string));
            Details.Columns.Add("Value", typeof(string));
            HomeAddress = new Address();
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Adds a detail about the person to the DataTable.
        /// </summary>
        /// <param name="key">The key of the detail.</param>
        /// <param name="value">The value of the detail.</param>
        public void AddDetail(string key, string value)
        {
            DataRow row = Details.NewRow();
            row["Key"] = key;
            row["Value"] = value;
            Details.Rows.Add(row);
        }

        #endregion
    }
}
