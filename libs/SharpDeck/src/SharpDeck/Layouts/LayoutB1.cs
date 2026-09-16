namespace SharpDeck.Layouts
{
    using Newtonsoft.Json;

    /// <summary>
    /// Provides information for the default layout $B1.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class LayoutB1 : LayoutX1
    {
        /// <summary>
        /// Gets or sets the indicator.
        /// </summary>
        public Bar Indicator { get; set; }

        /// <summary>
        /// Gets or sets the value shown above the <see cref="Indicator"/>.
        /// </summary>
        public Text Value { get; set; }
    }
}
