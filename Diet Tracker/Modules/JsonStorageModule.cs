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
        if(File.Exists(filePath))
        {
            var jsonData = File.ReadAllText(filePath);
            if(jsonData.Length > 5)
            {
                var data = JsonSerializer.Deserialize<ICollection<MealEntry>>(jsonData);
                return data;
            }
        }
        return new List<MealEntry>();
    }

    public ICollection<MealEntry> GetAllMealEntries(int page, int pageSize)
    {
        if (File.Exists(filePath))
        {
            var jsonData = File.ReadAllText(filePath);
            if (jsonData.Length > 5)
            {
                var data = JsonSerializer.Deserialize<ICollection<MealEntry>>(jsonData);
                var paginatedData = data.Skip((page-1) * pageSize).Take(pageSize).ToList();
                return paginatedData;
            }
        }
        return new List<MealEntry>();
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
