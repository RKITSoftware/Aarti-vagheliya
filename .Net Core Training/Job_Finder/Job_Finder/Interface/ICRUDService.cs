using Job_Finder.Enum;
using Job_Finder.Model;

namespace Job_Finder.Interface
{
    public interface ICRUDService<T> where T : class
    {
        T obj { get; set; }

        enmOperationType objOperation { get; set; }
        bool IsExists(int id);
        Response Save();
        Response Select();
        Response Delete(int id);


       // Response Delete(int id);
       // Response Validation();
    }
}
