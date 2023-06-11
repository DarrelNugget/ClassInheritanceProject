using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    internal class MyModernAppliances : ModernAppliances
    {
        //Message in the Discord when something done and mark it on in the code to make it easier for everyone to follow and to allow everyone to know what to work on
        public override void Checkout()
        {
            //Code Done / Testing Done / Review Done
            Console.Write("Enter the item number of an appliance: ");
            string itemNumberInput = Console.ReadLine();

            if (!long.TryParse(itemNumberInput, out long itemNumber))
            {
                Console.WriteLine("Invalid item number. Please try again.");
                return;
            }

            Appliance foundAppliance = Appliances.FirstOrDefault(appliance => appliance.ItemNumber == itemNumber);

            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.");
                return;
            }

            if (!foundAppliance.IsAvailable)
            {
                Console.WriteLine("The appliance is not available to be checked out.");
                return;
            }

            foundAppliance.Checkout();
            Console.WriteLine("Appliance has been checked out.");


        }

      
        public override void Find()
        {
            //Code Done / Testing Done / Review Done
            Console.Write("Enter brand to search for: ");
            string brand = Console.ReadLine();

            var found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Brand == brand)
                {
                    found.Add(appliance);
                }
            }

            DisplayAppliancesFromList(found, 0);
        }

     
        public override void DisplayRefrigerators()
        {
            //Code Done / Testing Done / Review Done
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");

            Console.Write("Enter number of doors: ");
            string doorsInput = Console.ReadLine();

            if (!int.TryParse(doorsInput, out int numberOfDoors))
            {
                Console.WriteLine("Invalid number of doors. Please try again.");
                return;
            }

            var found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Refrigerator refrigerator)
                {
                    if (numberOfDoors == 0 || refrigerator.Doors == numberOfDoors)
                    {
                        found.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(found, 0);
        }

        public override void DisplayVacuums()
        {
            //Code Done / Testing Done / Review Done
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial");

            Console.Write("Enter grade: ");
            string gradeInput = Console.ReadLine();

            string grade;
            if (gradeInput == "0")
                grade = "Any";
            else if (gradeInput == "1")
                grade = "Residential";
            else if (gradeInput == "2")
                grade = "Commercial";
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt");

            Console.Write("Enter voltage: ");
            string voltageInput = Console.ReadLine();

            int voltage;
            if (voltageInput == "0")
                voltage = 0;
            else if (voltageInput == "1")
                voltage = 18;
            else if (voltageInput == "2")
                voltage = 24;
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            var found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Vacuum vacuum)
                {
                    if ((grade == "Any" || vacuum.Grade == grade) && (voltage == 0 || vacuum.BatteryVoltage == voltage))
                    {
                        found.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(found, 0);

        }

        public override void DisplayMicrowaves()
        {
            //Code Done / Testing Done / Review Done
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Work site");

            Console.Write("Enter room type: ");
            string roomTypeInput = Console.ReadLine();

            char roomType;
            if (roomTypeInput == "0")
                roomType = 'A';
            else if (roomTypeInput == "1")
                roomType = 'K';
            else if (roomTypeInput == "2")
                roomType = 'W';
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            var found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Microwave microwave)
                {
                    if (roomType == 'A' || microwave.RoomType == roomType)
                    {
                        found.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(found, 0);
        }

        public override void DisplayDishwashers()
        {
            //Code Done / Testing Done / Review Done
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate");

            Console.Write("Enter sound rating: ");
            string soundRatingInput = Console.ReadLine();

            string soundRating;
            if (soundRatingInput == "0")
                soundRating = "Any";
            else if (soundRatingInput == "1")
                soundRating = "Qt";
            else if (soundRatingInput == "2")
                soundRating = "Qr";
            else if (soundRatingInput == "3")
                soundRating = "Qu";
            else if (soundRatingInput == "4")
                soundRating = "M";
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            var found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Dishwasher dishwasher)
                {
                    if (soundRating == "Any" || dishwasher.SoundRating == soundRating)
                    {
                        found.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(found, 0);
        }

        public override void RandomList()
        {
            //Code Done / Testing Done / Review NotDone
            Console.WriteLine("Appliance Types");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Refrigerators");
            Console.WriteLine("2 - Vacuums");
            Console.WriteLine("3 - Microwaves");
            Console.WriteLine("4 - Dishwashers");

            Console.Write("Enter type of appliance: ");
            string applianceTypeInput = Console.ReadLine();

            Console.Write("Enter number of appliances: ");
            string numberOfAppliancesInput = Console.ReadLine();

            if (!int.TryParse(numberOfAppliancesInput, out int numberOfAppliances))
            {
                Console.WriteLine("Invalid number of appliances. Please try again.");
                return;
            }

            var found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (applianceTypeInput == "0" || (applianceTypeInput == "1" && appliance is Refrigerator) ||
                    (applianceTypeInput == "2" && appliance is Vacuum) ||
                    (applianceTypeInput == "3" && appliance is Microwave) ||
                    (applianceTypeInput == "4" && appliance is Dishwasher))
                {
                    found.Add(appliance);
                }
            }

            found.Sort(new RandomComparer());
            DisplayAppliancesFromList(found, numberOfAppliances);

        }
    }
}
