using System.Collections.Generic;

namespace CORS.BL
{
    /// <summary>
    /// Class Manage bussiness logic for teachers.
    /// </summary>
    public class BLTeachers
    {
        #region Private member

        // Static list to store teacher names.
        private static List<string> _lstTeacher = new List<string>
        {
            "Arti vagheliya",
            "Ishika Jethwa",
            "Krinsi Kayada"
        };

        #endregion

        #region Public Methods

        /// <summary>
        /// this method fpr retrive teachers names.
        /// </summary>
        /// <returns>liost of teacher's name</returns>
        public List<string> GetTeachers()
        {
            return _lstTeacher;
        }

        /// <summary>
        /// Add new teacher name
        /// </summary>
        /// <param name="teacher"> teacher's name for adding</param>
        /// <returns>teacher name</returns>
        public string Add(string teacher)
        {
            _lstTeacher.Add(teacher);
            return teacher;
        }

        #endregion
    }
}