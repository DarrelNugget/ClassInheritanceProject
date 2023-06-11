namespace ModernAppliances.Entities.Abstract
{
    /// <summary>
    /// Abstract representation of an appliance
    /// </summary>
    internal abstract class Appliance
    {
        /// <summary>
        /// Types of appliances
        /// </summary>
        public enum ApplianceTypes
        {
            Unknown,
            Refrigerator = 1,
            Vacuum = 2,
            Microwave = 3,
            Dishwasher = 4
        }

        private readonly long _itemNumber;
        private readonly string _brand;
        private int _quantity;
        private readonly decimal _wattage;
        private readonly string _color;
        private readonly decimal _price;

        public ApplianceTypes Type
        {
            get
            {
                return DetermineApplianceTypeFromItemNumber(_itemNumber);
            }
        }

        /// <summary>
        /// Item number
        /// </summary>
        public long ItemNumber
        {
            get
            {
                return _itemNumber;
            }
        }

        /// <summary>
        /// Brand of appliance
        /// </summary>
        public string Brand
        {
            get { return _brand; }
        }

        /// <summary>
        /// Number of appliances
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
        }

        /// <summary>
        /// Wattage for appliance
        /// </summary>
        public decimal Wattage
        {
            get { return _wattage; }
        }

        /// <summary>
        /// Color of appliance
        /// </summary>
        public string Color
        {
            get { return _color;  }
        }

        /// <summary>
        /// Price for appliance
        /// </summary>
        public decimal Price
        {
            get { return _price; }
        }

        /// <summary>
        /// Is there appliance(s) available
        /// </summary>
        public bool IsAvailable
        {
            get
            {
                bool isAvailable = Quantity > 0 ? true : false;
                return isAvailable;
            }
        }

        /// <summary>
        /// Constructor for appliance
        /// </summary>
        /// <param name="itemNumber">Item number</param>
        /// <param name="brand">Brand</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="wattage">Wattage</param>
        /// <param name="color">Color</param>
        /// <param name="price">Price</param>
        protected Appliance(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price)
        {
            this._itemNumber = itemNumber;
            this._brand = brand;
            this._quantity = quantity;
            this._wattage = wattage;
            this._color = color;
            this._price = price;
        }

        /// <summary>
        /// Checkout appliance
        /// </summary>
        public void Checkout()
        {
            this._quantity = this._quantity - 1;
        }

        /// <summary>
        /// Formats appliance to be stored in file
        /// </summary>
        /// <returns></returns>
        public virtual string FormatForFile()
        {
            return string.Join(';', ItemNumber, Brand, Quantity, Wattage, Color, Price);
        }

        /// <summary>
        /// Determines appliance type from item number
        /// </summary>
        /// <param name="itemNumber">Item number</param>
        /// <returns>Appliance type</returns>
        public static ApplianceTypes DetermineApplianceTypeFromItemNumber(long itemNumber)
        {
            string firstDigitStr = itemNumber.ToString().Substring(0, 1);
            short firstDigit = short.Parse(firstDigitStr);

            if (firstDigit == 1)
            {
                // Refrigerator
                return ApplianceTypes.Refrigerator;
            }
            else if (firstDigit == 2)
            {
                // Vacuum
                return ApplianceTypes.Vacuum;
            }
            else if (firstDigit == 3)
            {
                // Microwave
                return ApplianceTypes.Microwave;
            }
            else if (firstDigit == 4 || firstDigit == 5)
            {
                // Dishwasher
                return ApplianceTypes.Dishwasher;
            }
            else
            {
                // Unknown
                return ApplianceTypes.Unknown;
            }
        }
    }
}
