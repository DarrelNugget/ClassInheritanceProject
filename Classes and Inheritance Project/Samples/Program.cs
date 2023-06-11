using Samples.Helpers;
using System.Text;
using System.Xml.Linq;

namespace Samples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // PromptForInput();
            // FindSingleItemInList();
            // FindHighestItemInList();
            // FindMultipleItemsInList();
            GenerateRandomStudents();
            // DownCast();
        }

        static void PromptForInput()
        {
            while (true)
            {
                // Write "Enter a number: "
                Console.Write("Enter a number between 1 and 50: ");

                // Get what user inputted as a string.
                string input = Console.ReadLine();

                // Convert string to int
                int guess = Convert.ToInt32(input);

                // Make sure guess is between 1 and 50 (inclusive)
                if (guess < 1 || guess > 50)
                {
                    Console.WriteLine("Number entered is invalid.");
                    return;
                }

                // Create Random instance (for generated "random" numbers)
                Random rand = new Random();

                // Generate random number between 1 and 51 (exclusive)
                int drawn = rand.Next(1, 51);

                // Write drawn number
                Console.WriteLine("Number drawn: " + drawn);

                // Check generated number is what user entered
                if (guess == drawn)
                {
                    Console.WriteLine("You win!");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again.");
                }
            }
            
        }

        static void FindSingleItemInList()
        {
            // What to find in list
            string query = "Dave";

            // Creates list of students
            List<Student> students = new List<Student>();

            // Populates list with students
            students.Add(new Student("Alex", 2.5));
            students.Add(new Student("Nicole", 3.98));
            students.Add(new Student("Kitty", 2.1));
            students.Add(new Student("Maryam", 3.90));
            students.Add(new Student("Ali", 3.99));
            students.Add(new Student("Dave", 3.75));
            students.Add(new Student("Doug", 3));
            students.Add(new Student("Hamdy", 2.8));
            students.Add(new Student("John", 3.85));


            // Create variable that will hold found list item and initialize it to null.
            // The ? after the data type indicates it is nullable (can be that data type or null)
            Student? found = null;

            // Loop through list
            foreach (Student student in students)
            {
                // Test current item equals query
                if (student.Name == query)
                {
                    // Assigns current item to found
                    found = student;
                    // Breaks out of (ends) looping
                    break;
                }
            }

            // If found is null, it means nothing was found.
            if (found == null)
            {
                // Write "Nothing was found"
                Console.WriteLine("Nothing was found");
            }
            else
            {
                // Write "Found: {name}"
                Console.WriteLine("Found: " + found);
            }


        }


        static void FindHighestItemInList()
        {
            // Creates list of students
            List<Student> students = new List<Student>();

            // Populates list with students
            students.Add(new Student("Alex", 2.5));
            students.Add(new Student("Nicole", 3.98));
            students.Add(new Student("Kitty", 2.1));
            students.Add(new Student("Maryam", 3.90));
            students.Add(new Student("Ali", 3.99));
            students.Add(new Student("Dave", 3.75));
            students.Add(new Student("Doug", 3));
            students.Add(new Student("Hamdy", 2.8));
            students.Add(new Student("John", 3.85));

            // Create variable that will hold found list item and initialize it to null.
            // The ? after the data type indicates it is nullable (can be that data type or null)
            Student? found = null;

            // Loop through list
            foreach (Student student in students)
            {
                // Test found is null (nothing checked yet) or student GPA is higher than found GPA
                // To find the smallest, change the comparison to < (less than)
                if (found == null || student.GPA > found.GPA)
                {
                    // Assigns current item to found
                    found = student;
                }

                // Continue looping
            }

            // Write "Found: {name}"
            // The only way found can be null is if the list was empty.
            Console.WriteLine("Found: " + found);

        }

        static void FindMultipleItemsInList()
        {

            // What to find in list
            string query = "J";

            // Creates list of students
            List<Student> students = new List<Student>();

            // Populates list with students
            students.Add(new Student("Alex", 2.5));
            students.Add(new Student("Nicole", 3.98));
            students.Add(new Student("Kitty", 2.1));
            students.Add(new Student("Maryam", 3.90));
            students.Add(new Student("Ali", 3.99));
            students.Add(new Student("Dave", 3.75));
            students.Add(new Student("Doug", 3));
            students.Add(new Student("Hamdy", 2.8));
            students.Add(new Student("John", 3.85));

            // Create variable that will hold found items and initialize it to an empty list.
            
            List<Student> found = new List<Student>();

            // Loop through list
            foreach (Student student in students)
            {
                // Test current item contains query
                if (student.Name.Contains(query))
                {
                    // Add current item to found list
                    found.Add(student);
                }

                // Continue looping
            }

            // If the list is empty, it means nothing was found.
            if (found.Count == 0)
            {
                // Write "Nothing was found"
                Console.WriteLine("Nothing was found");
            }
            else
            {
                Console.WriteLine("Found:");
                // Print out each item found in list
                foreach (Student student in found)
                { 
                    Console.WriteLine(student.Name); 
                }
            }
        }

        static void GenerateRandomStudents()
        {

            // Max # of random students to display
            int max = 3;

            // Creates list of students
            List<Student> students = new List<Student>();

            // Populates list with students
            students.Add(new Student("Alex", 2.5));
            students.Add(new Student("Nicole", 3.98));
            students.Add(new Student("Kitty", 2.1));
            students.Add(new Student("Maryam", 3.90));
            students.Add(new Student("Ali", 3.99));
            students.Add(new Student("Dave", 3.75));
            students.Add(new Student("Doug", 3));
            students.Add(new Student("Hamdy", 2.8));
            students.Add(new Student("John", 3.85));

            // Create variable that will hold randomized items and initialize it from existing students.

            List<Student> randomized = new List<Student>(students);

            // Use comparer to randomize list
            randomized.Sort(new RandomComparer());

            // Check if there's more students than the max
            // It's important this is done after the list is randomized.
            if (randomized.Count > max)
            {
                randomized.RemoveRange(max, randomized.Count - max);
            }

            // If the list is empty, it means nothing was found.
            if (randomized.Count == 0)
            {
                // Write "Nothing was found"
                Console.WriteLine("Nothing was found");
            }
            else
            {
                Console.WriteLine("Randomized:");

                // Print out each item found in list
                foreach (Student student in randomized)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }

        static void DownCast()
        {
            // Create objects
            Person john = new Person("John Doe");
            Person joe = new Student("Joe Blow", 3.5);

            // Test if john is a Student
            if (john is Student)
            {
                // Down cast to Student object
                Student studentJohn = (Student)john;

                // Write John's GPA
                Console.WriteLine("John's GPA: " + studentJohn.GPA);
            }

            // Test if joe is Student
            if (joe is Student)
            {
                // Down cast to Student object
                Student studentJoe = (Student)joe;

                // Write Joe's GPA
                Console.WriteLine("Joe's GPA: " + studentJoe.GPA);
            }

            // Shorter version of above:

            /*
            if (joe is Student studentJoe)
            {
                // Write Joe's GPA
                Console.WriteLine("Joe's GPA: " + studentJoe.GPA);
            }
            */

        }
    }
}