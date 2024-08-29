using System;
using System.Collections.Generic;

// Animal information class
class Animal
{
    public int ID { get; set; }//Added id field
    public string Class { get; set; }//Added class field
    public string Name { get; set; } //Added name field
    public string Gender { get; set; }// Added gender field
    public int CageNumber { get; set; }// Added cagenumber field
    public string Status { get; set; } // Added status field
    public string HealthCare { get; set; } // Added health care field
    public string Habit { get; set; } // Added habit field
}

// Cage management class
class Cage
{
    public int CageNumber { get; set; }
    public string CleaningStatus { get; set; }
    public string Status { get; set; } // Cage Status (full, available, broken)
    public string FeedStatus { get; set; } // Feed Status (complete, no)
    public int Capacity { get; set; }
    public List<Animal> AnimalsInCage { get; set; }

    public Cage(int cageNumber, int capacity)
    {
        CageNumber = cageNumber;
        CleaningStatus = "Clear";
        Status = "Available";
        FeedStatus = "Complete"; // Initialize FeedStatus to Complete
        Capacity = capacity;
        AnimalsInCage = new List<Animal>();
    }
}


class Program
{
    static List<Animal> animals = new List<Animal>();
    static List<Cage> cages = new List<Cage>();
    static bool zooOpenToday = DateTime.Now.DayOfWeek != DayOfWeek.Monday; // Check if the zoo is open today (not Monday)

   static void Main(string[] args)
{
    InitializeZoo(); // Initialize the zoo, add some animals and cages.

    while (true)
    {
        Console.WriteLine($"Welcome to the Zoo Management System - Today is {DateTime.Now.ToLongDateString()}, {DateTime.Now.DayOfWeek}");
        Console.WriteLine("Please choose an option");
        Console.WriteLine("1. Register new animal");
        Console.WriteLine("2. Register new cage");
        Console.WriteLine("3. Search animal");
        Console.WriteLine("4. Search cage");
        Console.WriteLine("5. Display animals by status");
        Console.WriteLine("6. Display all cage statuses");
        Console.WriteLine("7. Change cage status");
        Console.WriteLine("8. Change cage feed status");
        Console.WriteLine("9. Quit");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                AddNewAnimal();
                break;
            case 2:
                AddNewCage();
                break;
            case 3:
                QueryAnimalInfo();
                break;
            case 4:
                QueryCageInfo();
                break;
            case 5:
                DisplayAnimalsByStatus();
                break;
            case 6:
                ChangeCageStatus();
                break;
            case 7:
                DisplayAllCageStatuses();
                break;
            case 8:
                ChangeCageFeedStatus();
                break;
            case 9:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("No option, please choose a valid option.");
                break;
        }
    }
}


    // Initialize zoo, insert some animals and cages.
    static void InitializeZoo()
    {
        animals.Add(new Animal { ID = 1, Class = "Panda", Name = "Gaogao", Gender = "Male", CageNumber = 1, Status = "Healthy", HealthCare = "Regular checkup", Habit = "Bamboo eater" });
        animals.Add(new Animal { ID = 2, Class = "Panda", Name = "Beibei", Gender = "Female", CageNumber = 1, Status = "Healthy", HealthCare = "Regular checkup", Habit = "Bamboo eater" });
        animals.Add(new Animal { ID = 3, Class = "Lion", Name = "Leo", Gender = "Male", CageNumber = 2, Status = "Sick", HealthCare = "Under medical treatment", Habit = "Meat eater" });
        animals.Add(new Animal { ID = 4, Class = "Lion", Name = "Ruby", Gender = "Female", CageNumber = 2, Status = "Healthy", HealthCare = "Regular checkup", Habit = "Meat eater" });
        animals.Add(new Animal { ID = 5, Class = "Koala", Name = "Koby", Gender = "Male", CageNumber = 3, Status = "Healthy", HealthCare = "Regular checkup", Habit = "Eucalyptus leaves eater" });
        animals.Add(new Animal { ID = 6, Class = "Koala", Name = "Kara", Gender = "Female", CageNumber = 3, Status = "Mother", HealthCare = "Postnatal care", Habit = "Eucalyptus leaves eater" });
        animals.Add(new Animal { ID = 7, Class = "Giraffe", Name = "Garry", Gender = "Male", CageNumber = 4, Status = "Healthy", HealthCare = "Regular checkup", Habit = "Leaf eater" });
        animals.Add(new Animal { ID = 8, Class = "Giraffe", Name = "Grace", Gender = "Female", CageNumber = 4, Status = "Healthy", HealthCare = "Regular checkup", Habit = "Leaf eater" });
        animals.Add(new Animal { ID = 9, Class = "Zebra", Name = "Zacky", Gender = "Male", CageNumber = 5, Status = "Healthy", HealthCare = "Regular checkup", Habit = "Grass eater" });
        animals.Add(new Animal { ID = 10, Class = "Zebra", Name = "Zoe", Gender = "Female", CageNumber = 5, Status = "Healthy", HealthCare = "Regular checkup", Habit = "Grass eater" });

        cages.Add(new Cage(1, 2));
        cages.Add(new Cage(2, 2));
        cages.Add(new Cage(3, 2));
        cages.Add(new Cage(4, 2));
        cages.Add(new Cage(5, 2));
    }

    // Insert new animal
    static void AddNewAnimal()
    {
        Console.WriteLine("Please insert information of new animal:");
        Console.Write("ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Class (Panda, Lion, Koala, Giraffe, Zebra): ");
        string animalClass = Console.ReadLine();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Gender: ");
        string gender = Console.ReadLine();
        Console.Write("Cage Number: ");
        int cageNumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("Status (Healthy, Sick, Mother, Baby, Oestrus, Visit, Examine): ");
        string status = Console.ReadLine();
        Console.Write("Health Care: ");
        string healthCare = Console.ReadLine();
        Console.Write("Habit (Favorite Food): ");
        string habit = Console.ReadLine();

        animals.Add(new Animal { ID = id, Class = animalClass, Name = name, Gender = gender, CageNumber = cageNumber, Status = status, HealthCare = healthCare, Habit = habit });
        Console.WriteLine("New animal registered.");
    }

    // Insert new cage
    static void AddNewCage()
    {
        Console.WriteLine("Please insert information of new cage:");
        Console.Write("Cage Number: ");
        int cageNumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("Capacity: ");
        int capacity = Convert.ToInt32(Console.ReadLine());

        cages.Add(new Cage(cageNumber, capacity));
        Console.WriteLine("New cage registered.");
    }

    // Search animal
    static void QueryAnimalInfo()
    {
        Console.Write("Please insert animal ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Animal animal = animals.Find(a => a.ID == id);
        if (animal != null)
        {
            Console.WriteLine("Animal Information:");
            Console.WriteLine($"ID: {animal.ID}");
            Console.WriteLine($"Class: {animal.Class}");
            Console.WriteLine($"Name: {animal.Name}");
            Console.WriteLine($"Gender: {animal.Gender}");
            Console.WriteLine($"Cage Number: {animal.CageNumber}");
            Console.WriteLine($"Status: {animal.Status}");
            Console.WriteLine($"Health Care: {animal.HealthCare}");
            Console.WriteLine($"Habit: {animal.Habit}");
        }
        else
        {
            Console.WriteLine("Did not find this animal!");
        }
    }

    // Find cage information
    static void QueryCageInfo()
    {
        Console.Write("Please insert Cage Number: ");
        int cageNumber = Convert.ToInt32(Console.ReadLine());

        List<Animal> animalsInCage = animals.FindAll(a => a.CageNumber == cageNumber);
        if (animalsInCage.Count > 0)
        {
            Console.WriteLine("Cage Information:");
            Console.WriteLine($"Cage Number: {cageNumber}");
            Console.WriteLine($"Cleaning Status: {cages[cageNumber - 1].CleaningStatus}");
            Console.WriteLine($"Status: {cages[cageNumber - 1].Status}");
            Console.WriteLine("Animals in the cage:");

            foreach (Animal animal in animalsInCage)
            {
                Console.WriteLine($"- {animal.Name} ({animal.Class})");
            }
        }
        else
        {
            Console.WriteLine("Did not find this cage!");
        }
    }

    // Display animals by status
    static void DisplayAnimalsByStatus()
    {
        Console.WriteLine("Choose a status:");
        Console.WriteLine("1. Healthy");
        Console.WriteLine("2. Sick");
        Console.WriteLine("3. Mother");
        Console.WriteLine("4. Baby");
        Console.WriteLine("5. Oestrus");
        Console.WriteLine("6. Visit");
        Console.WriteLine("7. Examine");

        int choice = Convert.ToInt32(Console.ReadLine());

        string statusToDisplay = "";
        switch (choice)
        {
            case 1:
                statusToDisplay = "Healthy";
                break;
            case 2:
                statusToDisplay = "Sick";
                break;
            case 3:
                statusToDisplay = "Mother";
                break;
            case 4:
                statusToDisplay = "Baby";
                break;
            case 5:
                statusToDisplay = "Oestrus";
                break;
            case 6:
                statusToDisplay = "Visit";
                break;
            case 7:
                statusToDisplay = "Examine";
                break;
            default:
                Console.WriteLine("Invalid option.");
                return;
        }

        List<Animal> animalsWithStatus = animals.FindAll(a => a.Status == statusToDisplay);
        if (zooOpenToday && statusToDisplay == "Healthy")
        {
            Console.WriteLine($"Animals with status 'Healthy' available for display today ({DateTime.Now.ToLongDateString()}, {DateTime.Now.DayOfWeek}):");
            foreach (Animal animal in animalsWithStatus)
            {
                Console.WriteLine($"- {animal.Name} ({animal.Class})");
            }
        }
        else
        {
            Console.WriteLine($"Animals with status '{statusToDisplay}' ({DateTime.Now.ToLongDateString()}, {DateTime.Now.DayOfWeek}):");
            foreach (Animal animal in animalsWithStatus)
            {
                Console.WriteLine($"- {animal.Name} ({animal.Class})");
            }
        }
    }

    // Change cage status
static void ChangeCageStatus()
{
    Console.Write("Please insert Cage Number: ");
    int cageNumber = Convert.ToInt32(Console.ReadLine());

    Cage cage = cages.Find(c => c.CageNumber == cageNumber);
    if (cage != null)
    {
        Console.WriteLine($"Current Cage Status: {cage.Status}");
        Console.Write("Enter new Cage Status (full, available, broken): ");
        string newStatus = Console.ReadLine();
        
        // Check if the provided status is valid
        if (newStatus == "full" || newStatus == "available" || newStatus == "broken")
        {
            cage.Status = newStatus;
            Console.WriteLine("Cage status updated.");
        }
        else
        {
            Console.WriteLine("Invalid status. Cage status not updated.");
        }
    }
    else
    {
        Console.WriteLine("Did not find this cage!");
    }
}

// Change cage feed status
static void ChangeCageFeedStatus()
{
    Console.Write("Please insert Cage Number: ");
    int cageNumber = Convert.ToInt32(Console.ReadLine());

    Cage cage = cages.Find(c => c.CageNumber == cageNumber);
    if (cage != null)
    {
        Console.WriteLine($"Current Feed Status: {cage.FeedStatus}");
        Console.Write("Enter new Feed Status (complete, no): ");
        string newFeedStatus = Console.ReadLine();
        
        // Check if the provided feed status is valid
        if (newFeedStatus == "complete" || newFeedStatus == "no")
        {
            cage.FeedStatus = newFeedStatus;
            Console.WriteLine("Cage feed status updated.");
        }
        else
        {
            Console.WriteLine("Invalid feed status. Cage feed status not updated.");
        }
    }
    else
    {
        Console.WriteLine("Did not find this cage!");
    }
}
// Display all cage statuses and feed statuses
static void DisplayAllCageStatuses()
{
    Console.WriteLine("Cage Statuses:");
    foreach (Cage cage in cages)
    {
        Console.WriteLine($"Cage Number {cage.CageNumber}: {cage.Status}");
    }
    
    Console.WriteLine("Cage Feed Statuses:");
    foreach (Cage cage in cages)
    {
        Console.WriteLine($"Cage Number {cage.CageNumber}: {cage.FeedStatus}");
    }
}


}


