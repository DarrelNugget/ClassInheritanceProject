using ModernAppliances.Entities.Abstract;

namespace ModernAppliances.Entities
{
    internal class Microwave : Appliance
    {
        /// <summary>
        /// Constant for kitchen room type
        /// </summary>
        public const char RoomTypeKitchen = 'K';
        /// <summary>
        /// Constant for work site room type
        /// </summary>
        public const char RoomTypeWorkSite = 'W';

        /// <summary>
        /// Field that holds capacity of microwave
        /// </summary>
        private readonly float _capacity;
        /// <summary>
        /// Field that holds room type
        /// </summary>
        private readonly char _roomType;

        /// <summary>
        /// Property for capacity
        /// </summary>
        public float Capacity
        {
            get { return _capacity; }
        }

        /// <summary>
        /// Property for room type
        /// </summary>
        public char RoomType
        {
            get { return _roomType; }
        }

        /// <summary>
        /// Property getter for displayable room type
        /// </summary>
        public string RoomTypeDisplay
        {
            get
            {
                switch (_roomType)
                {
                    case RoomTypeKitchen:
                        return "Kitchen";
                    case RoomTypeWorkSite:
                        return "Work Site";
                    default:
                        return "(Unknown)";
                }
            }
        }

        /// <summary>
        /// Constructs Microwave object
        /// </summary>
        /// <param name="itemNumber">Item number</param>
        /// <param name="brand">Brand</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="wattage">Wattage</param>
        /// <param name="color">Color</param>
        /// <param name="price">Price</param>
        /// <param name="capacity">Microwave capacity</param>
        /// <param name="roomType">Type of room for microwave</param>
        public Microwave(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, float capacity, char roomType) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._capacity = capacity;
            this._roomType = roomType;
        }

        public override string FormatForFile()
        {
            string commonFormatted = base.FormatForFile();
            string formatted = string.Join(';', commonFormatted, Capacity, RoomType);

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
                string.Format("Capacity: {0}", Capacity) + "\n" +
                string.Format("Room Type: {0}", RoomTypeDisplay);

            return display;
        }
    }
}
