using Job_Finder.Interface;
using Job_Finder.Model;
using ServiceStack.OrmLite;
using Microsoft.AspNetCore.Connections;
using ServiceStack.OrmLite;
using System.Globalization;
using Job_Finder.BusinessLogic;
using Job_Finder.Enum;
using Job_Finder.DataBase;
using Job_Finder.Model.POCO;

namespace Job_Finder.Services
{
    public class CRUDImplementation<T> : ICRUDService<T> where T : class
    {
        private readonly BLHelper _objBLHelper = new BLHelper();

        private Response _objResponse;

        private readonly DBCommonContext<T> _objDBCommomContext = new DBCommonContext<T>();

        public readonly OrmLiteConnectionFactory _dbFactory;

        private readonly string _connectionString;

        public T obj { get; set; }


        public enmOperationType objOperation { get; set; }


        public CRUDImplementation()
        {
            _connectionString = _objBLHelper.GetConnectionString();
            _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
            CreateIfNotExists();
        }

      
        public bool IsExists(int id)
        {
             T obj;

            using(var db = _dbFactory.OpenDbConnection())
            {
                 obj = db.SingleById<T>(id);
            }

            return  obj != null ? true : false; 
        }


        public Response Save()
        {
            _objResponse = new Response();
            try
            {
                using(var db = _dbFactory.OpenDbConnection())
                {
                    if(objOperation == enmOperationType.I)
                    {
                        db.Insert<T>(obj);
                        _objResponse.Message = "Inserted Successfully.";
                    }
                    else if(objOperation == enmOperationType.U)
                    {
                        db.Update<T>(obj);
                        _objResponse.Message = "Updated Successfully.";
                    }

                    return _objResponse;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Response Select()
        {
            _objResponse = new Response();

            _objResponse.response = _objDBCommomContext.Select();

            return _objResponse;
        }

        public Response Delete(int id)
        {
            _objResponse = new Response();
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    db.DeleteById<T>(id);
                    _objResponse.Message = "Deleted Successfully.";
                }
                return _objResponse;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private void CreateIfNotExists()
        {
            using (var db = _dbFactory.Open())
            {
                if (!db.TableExists<T>())
                {
                    db.CreateTable<T>(); // Creating the table if it doesn't exist
                }
            }
        }

    }
}
