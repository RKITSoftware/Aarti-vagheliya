using ORMDemo.Models;
using ORMDemo.Models.DTO;
using ORMDemo.Models.POCO;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ORMDemo.BL
{
    /// <summary>
    /// Business logic class for managing operations related to the FAC01 entity.
    /// </summary>
    public class BLFAC01
    {
        #region Public properties

        /// <summary>
        /// Declares object of class RES01
        /// </summary>
        public RES01 ObjRES01 { get; set; } = new RES01();

        /// <summary>
        /// Declares object of class FAC01 
        /// </summary>
        public FAC01 ObjFAC01 { get; set; }

        /// <summary>
        /// Declares a list of FAC01 objects.
        /// </summary>
        public List<FAC01> lstFAC01 { get; set; }

        /// <summary>
        /// Declares object of class BLMapper
        /// </summary>
        public BLMapper<DtoFAC01, FAC01> objBLMapper = new BLMapper<DtoFAC01, FAC01>();

        /// <summary>
        ///  Declares object of class BLConvertor
        /// </summary>
        public BLConvertor objBLConvertor = new BLConvertor();

        #endregion

        #region Public Methods

        /// <summary>
        /// Preprocessing before saving.
        /// </summary>
        /// <param name="objDtoFAC01">DtoFAC01 object to preprocess.</param>
        public void PreSave(DtoFAC01 objDtoFAC01)
        {
            ObjFAC01 = objBLMapper.Map(objDtoFAC01);
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.CreateTableIfNotExists<FAC01>();
            }
        }

        /// <summary>
        /// Preprocessing before saving.
        /// </summary>
        /// <param name="lstDtoFAC01">lstDtoFAC01 is list of objects of DtoFAC01 to preprocess.</param>
        public void PreSave(List<DtoFAC01> lstDtoFAC01)
        {
            lstFAC01 = new List<FAC01>();
            foreach (var objFAC01 in lstDtoFAC01)
            {
                lstFAC01.Add(objBLMapper.Map(objFAC01));
            }
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.CreateTableIfNotExists<FAC01>();
            }
        }

        /// <summary>
        /// Retrieves all records from the FAC01 table.
        /// </summary>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 Select()
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.CreateTableIfNotExists<FAC01>();
                lstFAC01 = db.Select<FAC01>();

                ObjRES01.isError = false;
                ObjRES01.Message = "Success";
                ObjRES01.Response = objBLConvertor.ListToDataTable(lstFAC01);

                return ObjRES01;
            }
        }

        /// <summary>
        /// Retrieves a single record from the FAC01 table based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the record to retrieve.</param>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 SingleById(int id)
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.CreateTableIfNotExists<FAC01>();
                ObjFAC01 = db.SingleById<FAC01>(id);

                ObjRES01.isError = false;
                ObjRES01.Message = "Success";
                ObjRES01.Response = objBLConvertor.ObjectToDataTable(ObjFAC01);

                return ObjRES01;
            }
        }

        /// <summary>
        /// Retrieves records from the FAC01 table based on the specified list of IDs.
        /// </summary>
        /// <param name="lstId">The list of IDs to retrieve records for.</param>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 SelectByIds(List<int> lstId)
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.CreateTableIfNotExists<FAC01>();
                lstFAC01 = db.SelectByIds<FAC01>(lstId);

                ObjRES01.isError = false;
                ObjRES01.Message = "Success";
                ObjRES01.Response = objBLConvertor.ListToDataTable(lstFAC01);

                return ObjRES01;
            }
        }

        /// <summary>
        /// Inserts a new record into the FAC01 table.
        /// </summary>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 Insert()
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.Insert(ObjFAC01);

                ObjRES01.isError = false;
                ObjRES01.Message = "Success";

                return ObjRES01;
            }
        }

        /// <summary>
        /// Inserts a single record into the FAC01 table with predefined values.
        /// </summary>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 InsertOnly()
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.CreateTableIfNotExists<FAC01>();
                db.InsertOnly<FAC01>(new FAC01 { C01F02 = "XYZ", C01F03 = "HR" }, x => new { x.C01F02, x.C01F03 });

                ObjRES01.isError = false;
                ObjRES01.Message = "Success";

                return ObjRES01;
            }
        }

        /// <summary>
        /// Inserts multiple records into the FAC01 table.
        /// </summary>
        /// <param name="lstDtoFAC01">The list of DTO objects to insert.</param>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 InsertAll()
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.CreateTableIfNotExists<FAC01>();
                db.InsertAll<FAC01>(lstFAC01);

                ObjRES01.isError = false;
                ObjRES01.Message = "success";

                return ObjRES01;
            }
        }

        /// <summary>
        /// Updates an existing record in the FAC01 table.
        /// </summary>
        /// <param name="id">The ID of the record to update.</param>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 Update(int id)
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                ObjFAC01.C01F01 = id;
                db.Update<FAC01>(ObjFAC01);

                ObjRES01.isError = false;
                ObjRES01.Message = "Success";

                return ObjRES01;
            }
        }

        /// <summary>
        /// Updates specific fields of an existing record in the FAC01 table.
        /// </summary>
        /// <param name="id">The ID of the record to update.</param>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 UpdateOnly(int id)
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.UpdateOnly<FAC01>(() => new FAC01 { C01F02 = "Arti" }, where: x => x.C01F01 == id);

                ObjRES01.isError = false;
                ObjRES01.Message = "success";

                return ObjRES01;
            }
        }

        /// <summary>
        /// Updates only specific fields of an existing record in the FAC01 table.
        /// </summary>
        /// <param name="name">The name of the record to update.</param>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 UpdateOnlyFields(string name)
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.UpdateOnlyFields<FAC01>(new FAC01 { C01F03 = "CE" }, onlyFields: x => x.C01F03, where: a => a.C01F02 == name);

                ObjRES01.isError = false;
                ObjRES01.Message = "success";

                return ObjRES01;

            }
        }

        /// <summary>
        /// Updates only specific fields of an existing record in the FAC01 table.
        /// </summary>
        /// <param name="name">The name of the record to update.</param>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 Delete(int id)
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.Delete<FAC01>(x => x.C01F01 == id);

                ObjRES01.isError = false;
                ObjRES01.Message = "success";

                return ObjRES01;
            }
        }

        /// <summary>
        /// Deletes a record from the FAC01 table based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the record to delete.</param>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 DeleteById(int id)
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.DeleteById<FAC01>(id);

                ObjRES01.isError = false;
                ObjRES01.Message = "success";

                return ObjRES01;
            }
        }

        /// <summary>
        /// Deletes multiple records from the FAC01 table based on the provided list of IDs.
        /// </summary>
        /// <param name="lstIds">The list of IDs of the records to delete.</param>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 DeleteByIds(List<int> lstIds)
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.DeleteByIds<FAC01>(lstIds);

                ObjRES01.isError = false;
                ObjRES01.Message = "success";

                return ObjRES01;
            }
        }

        /// <summary>
        /// Retrieves the schema tables from the database.
        /// </summary>
        /// <returns>An object containing the schema tables.</returns>
        public RES01 GetSchemaTables()
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                Dictionary<string, List<string>> result = db.GetSchemaTables();

                //Debug.WriteLine(result);

                ObjRES01.isError = false;
                ObjRES01.Message = "Success";
                ObjRES01.Response = objBLConvertor.DictionaryToDataTable(result);

                return ObjRES01;
            }
        }

        /// <summary>
        /// Adds a new column to the FAC01 table.
        /// </summary>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 AddNewColumn()
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                if (!db.ColumnExists<FAC01>(x => x.C01F07))
                    db.AddColumn<FAC01>(x => x.C01F07);

                ObjRES01.isError = false;
                ObjRES01.Message = "success";

                return ObjRES01;
            }
        }

        /// <summary>
        /// Creates an index on the FAC01 table.
        /// </summary>
        /// <returns>An object containing the result of the operation.</returns>
        public RES01 CreateIndex()
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                db.CreateIndex<FAC01>(x => x.C01F06);

                ObjRES01.isError = false;
                ObjRES01.Message = "success";

                return ObjRES01;
            }
        }

        /// <summary>
        /// Executes a scalar query to retrieve a single value from the database.
        /// </summary>
        /// <returns>An object containing the result of the scalar query.</returns>
        public RES01 Scalar()
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                var q = db.From<FAC01>()
                    .Where(a => a.C01F01 == 8)
                    .Select(x => new { x.C01F01, x.C01F02, x.C01F03, x.C01F04, x.C01F05 });

                var result = db.Scalar<int>(q);

                ObjRES01.isError = false;
                ObjRES01.Message = "Success";

                return ObjRES01;
            }
        }

        /// <summary>
        /// Executes a group by query on the FAC01 table.
        /// </summary>
        /// <returns>An object containing the result of the group by query.</returns>
        public RES01 GroupBy()
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                SqlExpression<FAC01> query = db.From<FAC01>()
                    .GroupBy(x => x.C01F04)
                    .Select(x => new { x.C01F01, x.C01F02, x.C01F03, x.C01F04, x.C01F05, x.C01F06, x.C01F07 })
                    .Where(x => Sql.In(x.C01F07, 20, 30))
                    .OrderByDescending(x => x.C01F01);

                var resultList = db.SqlList<FAC01>(query);
                List<FAC01> resultColumn = db.SqlColumn<FAC01>(query);
                HashSet<int> resultColumnDistinct = db.ColumnDistinct<int>(query);

                var result = new { SqlList = resultList, SqlColumn = resultColumn, ColumnDistinct = resultColumnDistinct };

                //  Debug.WriteLine(result);

                ObjRES01.isError = false;
                ObjRES01.Message = "Success";
                ObjRES01.Response = objBLConvertor.ObjectToDataTable(result);

                return ObjRES01;
            }
        }


        /// <summary>
        /// Performs a lookup query on the FAC01 table based on certain conditions and returns the results as a dictionary.
        /// </summary>
        /// <typeparam name="T">The type of object to use for lookup results.</typeparam>
        /// <returns>An object containing the lookup query results.</returns>
        public RES01 LookupQuery<T>() where T : class
        {
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                SqlExpression<FAC01> query = db.From<FAC01>()
                                               .Select(x => new { x.C01F01, x.C01F02 })
                                               .Where(x => x.C01F07 < 35);

                // Execute the LINQ query and obtain the results
                List<FAC01> results = db.Select(query);

                // Initialize a dictionary to store the lookup results
                Dictionary<int, List<string>> lookupResults = new Dictionary<int, List<string>>();

                // Iterate over the results and populate the dictionary
                foreach (var result in results)
                {
                    // Assuming the first property of T is int and the second property is string
                    PropertyInfo[] properties = typeof(T).GetProperties();
                    int key = (int)properties[0].GetValue(result);
                    string value = (string)properties[1].GetValue(result);

                    // Check if the key already exists in the dictionary
                    if (!lookupResults.ContainsKey(key))
                    {
                        lookupResults[key] = new List<string>();
                    }

                    // Add the value to the list corresponding to the key
                    lookupResults[key].Add(value);
                }

                ObjRES01.isError = false;
                ObjRES01.Message = "Success";
                ObjRES01.Response = objBLConvertor.ListToDataTable(lookupResults);

                return ObjRES01;
            }
        }

        /// <summary>
        /// Performs a join operation.
        /// </summary>
        /// <returns>Return List of data.</returns>
        public RES01 Join()
        {
            using( var db = BLConnection.dbFactory.OpenDbConnection())
            {
                var q = db.From<FAC01>()
                          .Join<FAC01, STD01>((fac, std) => fac.C01F01 == std.D01F07);

                var dbCustomers = db.Select<STD01>(q);

                ObjRES01.isError = false;
                ObjRES01.Message = "success";
                ObjRES01.Response = objBLConvertor.ListToDataTable(dbCustomers);

                return ObjRES01;
            }
        }

        #endregion

    }
}