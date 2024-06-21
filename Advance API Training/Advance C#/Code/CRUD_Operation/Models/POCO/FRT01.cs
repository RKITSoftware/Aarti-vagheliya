using Newtonsoft.Json;

namespace CRUD_Operation.Models.POCO
{
    /// <summary>
    /// Represents a fruit entity with properties for ID, name, color, and price.
    /// </summary>
    public class FRT01
    {
        /// <summary>
        /// Gets or sets the ID of the fruit.
        /// </summary>
        [JsonProperty("T01101")]
        public int T01F01 { get; set; }

        /// <summary>
        /// Gets or sets the name of the fruit.
        /// </summary>
        [JsonProperty("T01102")]
        public string T01F02 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the color of the fruit.
        /// </summary>
        [JsonProperty("T01103")]
        public string T01F03 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the fruit.
        /// </summary>
        [JsonProperty("T01104")]
        public decimal T01F04 { get; set; }
    }
}