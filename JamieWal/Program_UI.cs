using static System.Console;

public class Program_UI
{
    private readonly CatRepository _catRepo = new CatRepository();
    public void Run()
    {
        Seed();
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            System.Console.WriteLine("=======\n" +
            "1. Add A Cat\n" +
            "2. View Cats\n" +
            "3. View a cat\n" +
            "4. Update a cat\n" +
            "5. Delete a cat\n" +
            "0. Close App\n");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddACat();
                    break;
                case "2":
                    ViewCats();
                    break;
                case "3":
                    ViewACat();
                    break;
                case "4":
                    UpdateACat();
                    break;
                case "5":
                    DeleteACat();
                    break;
                case "0":
                    isRunning = CloseApp();
                    break;
                default:
                    System.Console.WriteLine("invalid keys");
                    break;
            }
        }
    }
    private void ViewCats()
    {
        Console.Clear();
        if (_catRepo.GetCats().Count > 0)
        {
            foreach (var cat in _catRepo.GetCats())
            {
                System.Console.WriteLine(cat);
            }
        }
        else
        {
            System.Console.WriteLine("Sorry there are no cats available.");
        }
        Console.ReadKey();
    }
    private void ViewACat()
    {
        Console.Clear();
        System.Console.WriteLine("Please enter a cat id");
        var cat = _catRepo.GetCat(int.Parse(Console.ReadLine()));
        if (cat != null)
        {
            System.Console.WriteLine(cat);
        }
        Console.ReadKey();
    }
    private void UpdateACat()
    {
        Console.Clear();
        System.Console.WriteLine("Please enter a cat id");
        var userInput = int.Parse(Console.ReadLine());
        var cat = _catRepo.GetCat(userInput);
        if (cat != null)
        {
            Cat updatedCatData = InitializeCatCreation();
            if (_catRepo.UpdateCat(cat.Id, updatedCatData))
                System.Console.WriteLine("SUCCESS");
            else
                System.Console.WriteLine("FAIL");
        }
        else
        {
            System.Console.WriteLine($"Sorry the cat with the id: {userInput} doesn't exist.");
        }
        Console.ReadKey();
    }
    private void DeleteACat()
    {
        Console.Clear();
        System.Console.WriteLine("Please enter a cat id");
        var userInput = int.Parse(Console.ReadLine());
        var cat = _catRepo.GetCat(userInput);
        if (cat != null)
        {
            if (_catRepo.DeleteCat(cat.Id))
                System.Console.WriteLine("SUCCESS");
            else
                System.Console.WriteLine("FAIL");
        }
        else
        {
            System.Console.WriteLine($"Sorry the cat with the id: {userInput} doesn't exist.");
        }
        Console.ReadKey();
    }
    private bool CloseApp()
    {
        return false;
    }
    private void AddACat()
    {
        Console.Clear();
        Cat cat = InitializeCatCreation();

        if (_catRepo.AddCat(cat))
        {
            System.Console.WriteLine("SUCCESS");
        }
        else
        {
            System.Console.WriteLine("FAIL");
        }

        Console.ReadKey();
    }

    private Cat InitializeCatCreation()
    {
        try
        {
            Cat cat = new Cat();
            System.Console.WriteLine("Enter the cats name");
            cat.Name = Console.ReadLine();
            System.Console.WriteLine("How much is the Cat?");
            cat.Price = Convert.ToDecimal(Console.ReadLine());

            return cat;
        }
        catch
        {
            //catch any errors that may occur....to keep the app running...
            return null;
        }
    }

    private void Seed()
    {
        Cat catA = new Cat("Jimbo", 4_000m);
        Cat catB = new Cat("Jamie", 10_000m);
        Cat catC = new Cat("Jerry", 8_000m);
        Cat catD = new Cat("Jessica", 3_000m);

        _catRepo.AddCat(catA);
        _catRepo.AddCat(catC);
        _catRepo.AddCat(catB);
        _catRepo.AddCat(catD);
    }
}
