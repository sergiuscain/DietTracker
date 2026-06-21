using Diet_Tracker.Models;
using Diet_Tracker.Modules;

Console.WriteLine("Hello, World!");
var x = new JsonStorageModule();
var meal = new MealEntry
{
    Calories = 100,
    DateTime = DateTime.Now,
    Carbohydrates = 100,
    Fats = 100,
    FoodName = "Макарошки с сосиской",
    Id = 0,
    MealType = MealType.breakfast,
    PortionWeight = 100,
    Proteins = 999
};
x.AddMealEntry(meal);