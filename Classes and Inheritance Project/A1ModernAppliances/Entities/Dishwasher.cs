using ModernAppliances.Entities.Abstract;

namespace ModernAppliances.Entities
{
    /// <summary>
    /// Represents a dishwasher
    /// </summary>
    internal class Dishwasher : Appliance
    {
        /// <summary>
        /// Constant for quietest sound rating
        /// </summary>
        public const string SoundRatingQuietest = "Qt";
        /// <summary>
        /// Constant for quieter sound rating
        /// </summary>
        public const string SoundRatingQuieter = "Qr";
        /// <summary>
        /// Constant for quiet sound rating
        /// </summary>
        public const string SoundRatingQuiet = "Qu";
        /// <summary>
        /// Constant for moderate sound rating
        /// </summary>
        public const string SoundRatingModerate = "M";

        /// <summary>
        /// Field that holds feature
        /// </summary>
        private string _feature;
        /// <summary>
        /// Field that holds sound rating
        /// </summary>
        private string _soundRating;

        /// <summary>
        /// Property for feature
        /// </summary>
        public string Feature
        {
            get
            {
                return _feature;
            }
        }

        /// <summary>
        /// Property for sound rating
        /// </summary>
        public string SoundRating
        {
            get
            {
                return _soundRating;
            }
        }

        /// <summary>
        /// Property getter for sound rating
        /// </summary>
        public string SoundRatingDisplay
        {
            get
            {
                switch (_soundRating)
                {
                    case SoundRatingQuietest:
                        return "Quietest";
                    case SoundRatingQuieter:
                        return "Quieter";
                    case SoundRatingQuiet:
                        return "Quiet";
                    case SoundRatingModerate:
                        return "Moderate";
                    default:
                        return "(Unknown)";
                }
            }
        }

        /// <summary>
        /// Constructs Dishwasher instance
        /// </summary>
        /// <param name="itemNumber">Item number</param>
        /// <param name="brand">Brand</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="wattage">Wattage</param>
        /// <param name="color">Color</param>
        /// <param name="price">Price</param>
        /// <param name="feature">Feature</param>
        /// <param name="soundRating">Sound rating</param>
        public Dishwasher(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._feature = feature;
            this._soundRating = soundRating;
        }

        public override string FormatForFile()
        {
            string commonFormatted = base.FormatForFile();
            string formatted = string.Join(';', commonFormatted, Feature, SoundRating);

            return formatted;
        }

        public override string ToString()
        {
            string display = 
                string.Format("Item Number: {0}", ItemNumber) + "\n" +
                string.Format("Brand: {0}", Brand) + "\n" +
                string.Format("Quantity: {0}", Quantity) + "\n" +
                string.Format("Wattage: {0}", Wattage) + "\n" +
                string.Format("Color: {0}", Color) + "\n" +
                string.Format("Price: {0}", Price) + "\n" +
                string.Format("Feature: {0}", Feature) + "\n" +
                string.Format("Sound Rating: {0}", SoundRatingDisplay);

            return display;
        }
    }
}
