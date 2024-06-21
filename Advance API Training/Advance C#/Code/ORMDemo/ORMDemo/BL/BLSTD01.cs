using ORMDemo.Models;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;

namespace ORMDemo.BL
{
    /// <summary>
    /// Contains business logic for Student table
    /// </summary>
    public class BLSTD01
    {
        #region Public Method

        /// <summary>
        /// Selects all records from table STD01
        /// </summary>
        /// <returns>All records of table STD01</returns>
        public List<STD01> Select()
        {
            // Open a database connection
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                // Create table if it doesn't exist
                if (!db.TableExists<STD01>())
                {
                    db.CreateTable<STD01>();
                }

                // Select all records from STD01 table
                List<STD01> students = db.Select<STD01>();
                return students;
            }
        }


        /// <summary>
        /// Inserts a new record into table STD01
        /// </summary>
        /// <param name="objSTD01">New student object to be inserted</param>
        /// <returns>Message indicating the success of the operation</returns>
        public string Insert(STD01 objSTD01)
        {
            // Open a database connection
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                // Create table if it doesn't exist
                if (!db.TableExists<STD01>())
                {
                    db.CreateTable<STD01>();
                }

                // Insert new student object
                db.Insert(objSTD01);
                return "Success!";
            }
        }


        /// <summary>
        /// Updates a record in table STD01
        /// </summary>
        /// <param name="objSTD01">Student object with updated data</param>
        /// <returns>Message indicating the success of the operation</returns>
        public string Update(STD01 objSTD01)
        {
            // Open a database connection
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                // Check if table exists
                if (!db.TableExists<STD01>())
                {
                    return "Table does not exist!";
                }

                // Find existing student by ID
                var existingStudent = db.Select<STD01>().FirstOrDefault(c => c.D01F01 == objSTD01.D01F01);
                if (existingStudent == null)
                {
                    return "Student not found!";
                }

                // Update student object
                db.Update(objSTD01);
                return "Success!";
            }
        }


        /// <summary>
        /// Deletes a record from table STD01
        /// </summary>
        /// <param name="id">ID of the student record to be deleted</param>
        /// <returns>Message indicating the success of the operation</returns>
        public string Delete(int id)
        {
            // Open a database connection
            using (var db = BLConnection.dbFactory.OpenDbConnection())
            {
                // Check if table exists
                if (!db.TableExists<STD01>())
                {
                    return "Table does not exist!";
                }

                // Find existing student by ID
                var existingStudent = db.SingleById<STD01>(id);
                if (existingStudent == null)
                {
                    return "Student not found!";
                }

                // Delete student record
                db.DeleteById<STD01>(id);
                return "Success!";
            }
        }

        #endregion
    }
}