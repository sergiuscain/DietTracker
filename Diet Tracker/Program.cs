using Diet_Tracker.Models;
using Diet_Tracker.Modules;

Console.WriteLine("Hello, World!");
var x = new JsonStorageModule();
var result = x.GetAllMealEntries(1, 10);
foreach (var entry in result)
{
    Console.WriteLine(entry);
}
//Console.WriteLine("Выбор записи. Введите ID");
//var input = int.Parse(Console.ReadLine());
//Console.WriteLine(x.GetMealEntry(input));

Console.WriteLine("Выбор записи для удаления. Введите ID");
var input = int.Parse(Console.ReadLine());
Console.WriteLine(x.RemoveMealEntry(input));

//Random r = new Random();
//for (int i = 0; i < 100; i++)
//{
//    var meal = new MealEntry
//    {
//        Calories = r.Next(100),
//        DateTime = DateTime.Now,
//        Carbohydrates = r.Next(100),
//        Fats = r.Next(100),
//        FoodName = "Макарошки с сосиской",
//        Id = i,
//        MealType = MealType.breakfast,
//        PortionWeight = r.Next(100),
//        Proteins = r.Next(100)
//    };

//    x.AddMealEntry(meal);
//}