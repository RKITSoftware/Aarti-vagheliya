using ActionMethods.Model;

namespace ActionMethods.BusinessLogic
{
    /// <summary>
    /// Business logic class for managing novels.
    /// </summary>
    public class BLNovel
    {
        //Static count for unique id
        private static int _count = 0;

        // List to store novels
        private static List<NVL01> _lstNovel = new List<NVL01>
        {
            // Sample data initialization
            new NVL01 { L01F01 = Counter(), L01F02 = "To Kill a Mockingbird", L01F03 = "Harper Lee", L01F04 = 25.99m },
            new NVL01 { L01F01 = Counter(), L01F02 = "1984", L01F03 = "George Orwell", L01F04 = 15.50m },
            new NVL01 { L01F01 = Counter(), L01F02 = "Pride and Prejudice", L01F03 = "Jane Austen", L01F04 = 12.75m },
            new NVL01 { L01F01 = Counter(), L01F02 = "The Great Gatsby", L01F03 = "F. Scott Fitzgerald", L01F04 = 20.00m }
        };

        /// <summary>
        /// Retrieves all novels.
        /// </summary>
        /// <returns>A list of all novels.</returns>
        public List<NVL01> GetNovels()
        {
            return _lstNovel;
        }

        /// <summary>
        /// Retrieves a novel by its ID.
        /// </summary>
        /// <param name="id">The ID of the novel to retrieve.</param>
        /// <returns>The novel object if found; otherwise, null.</returns>
        public NVL01 GetNovelById(int id)
        {
            return _lstNovel.FirstOrDefault(n => n.L01F01 == id);
        }

        /// <summary>
        /// Adds a new novel.
        /// </summary>
        /// <param name="novel">The novel object to add.</param>
        /// <returns>A message indicating the result of the operation.</returns>
        public string AddNovel(NVL01 novel)
        {
            // Generate a unique ID for the novel
            novel.L01F01 = Counter();
            // Add the novel to the list
            _lstNovel.Add(novel);
            return "success.";
        }

        /// <summary>
        /// Updates an existing novel.
        /// </summary>
        /// <param name="objNVL01">The updated novel object.</param>
        /// <returns>A message indicating the result of the operation, or null if the novel is not found.</returns>
        public string UpdateNovel(NVL01 objNVL01)
        {
            // Find the novel to update
            var novel = _lstNovel.FirstOrDefault(c => c.L01F01 == objNVL01.L01F01);
            if (novel != null)
            {
                // Update the novel if found
                var index = _lstNovel.FindIndex(c => c.L01F01 == objNVL01.L01F01);
                if (index > -1)
                {
                    _lstNovel[index] = objNVL01;
                    return "Success";
                }
            }
            return null;
        }

        /// <summary>
        /// Deletes a novel by its ID.
        /// </summary>
        /// <param name="id">The ID of the novel to delete.</param>
        /// <returns>A message indicating the result of the operation, or null if the novel is not found.</returns>
        public string DeleteNovel(int id)
        {
            // Find the novel to delete
            var novel = _lstNovel.FirstOrDefault(n => n.L01F01 == id);
            if (novel != null)
            {
                // Remove the novel if found
                _lstNovel.Remove(novel);
                return "Success.";
            }
            return null;
        }

        /// <summary>
        /// Validates a novel object.
        /// </summary>
        /// <param name="objNVL01">The novel object to validate.</param>
        /// <returns>True if the novel object is valid; otherwise, false.</returns>
        public bool Validation(NVL01 objNVL01)
        {
            // Validate that the title, author, and price are not null or empty, and the price is greater than 0
            if (objNVL01.L01F02 != null && objNVL01.L01F03 != null && objNVL01.L01F04 > 0)
            {
                return true;
            }
            return false;
        }

        #region Private Method

        /// <summary>
        /// Increases the count and returns it.
        /// </summary>
        /// <returns>The incremented count.</returns>
        private static int Counter()
        {
            return ++_count;
        }

        #endregion
    }
}
