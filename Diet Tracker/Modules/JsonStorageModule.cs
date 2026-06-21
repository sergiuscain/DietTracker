using System.Text.Json;
using Diet_Tracker.Models;

namespace Diet_Tracker.Modules;

internal class JsonStorageModule : IStorageModule
{
    private string filePath = "MealData.json";
    public bool AddMealEntry(MealEntry mealEntry)
    {
        try
        {
            if (File.Exists(filePath))
            {
                var lastJsonData = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<ICollection<MealEntry>>(lastJsonData);
                data?.Add(mealEntry);
                var newJsonData = JsonSerializer.Serialize(data);
                File.WriteAllText(filePath, newJsonData);
            }
            else
            {
                var data = new List<MealEntry>();
                data.Add(mealEntry);
                var jsonData = JsonSerializer.Serialize(data);
                File.WriteAllText(filePath, jsonData);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ошибка при записи данных: {ex.ToString()}");
            return false;
        }
        return true;
    }

    public ICollection<MealEntry> GetAllMealEntries()
    {
        throw new NotImplementedException();
    }

    public ICollection<MealEntry> GetAllMealEntries(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public MealEntry GetMealEntry(int mealEntryId)
    {
        throw new NotImplementedException();
    }

    public bool RemoveMealEntry(int mealEntryId)
    {
        throw new NotImplementedException();
    }

    public MealEntry UpdateMealEntry(MealEntry mealEntry, int mealEntryId)
    {
        throw new NotImplementedException();
    }
}
