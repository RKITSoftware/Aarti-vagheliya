using Job_Finder.Model.POCO;

namespace Job_Finder.BusinessLogic
{
    public class BLLogin
    {
        private BLUSR01Handler _objBLUSR01Handler = new BLUSR01Handler();

        public USR01 ValidateUser(string userName, string passWord)
        {
           var user = _objBLUSR01Handler.GetAllUsers().FirstOrDefault(x => x.R01F02 == userName && x.R01F03 == passWord);

            return (user);
        }

        
    }


}
