using System.Text.Json;
using Diet_Tracker.Models;

namespace Diet_Tracker.Modules;

internal class JsonStorageModule : IStorageModule
{
    private string mealEntryPath = "MealEntry.json";
    private string goalsPath = "Goals.json";
    public bool AddMealEntry(MealEntry mealEntry)
    {
        try
        {
            if (File.Exists(mealEntryPath))
            {
                var lastJsonData = File.ReadAllText(mealEntryPath);
                var data = JsonSerializer.Deserialize<ICollection<MealEntry>>(lastJsonData);
                var lastEntryId = data.Select(x => x.Id).Max();
                mealEntry.Id = ++lastEntryId;
                data?.Add(mealEntry);
                var newJsonData = JsonSerializer.Serialize(data);
                File.WriteAllText(mealEntryPath, newJsonData);
            }
            else
            {
                var data = new List<MealEntry>();
                data.Add(mealEntry);
                var jsonData = JsonSerializer.Serialize(data);
                File.WriteAllText(mealEntryPath, jsonData);
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
        if(File.Exists(mealEntryPath))
        {
            var jsonData = File.ReadAllText(mealEntryPath);
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
        if (File.Exists(mealEntryPath))
        {
            var jsonData = File.ReadAllText(mealEntryPath);
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
        return GetAllMealEntries().FirstOrDefault(x => x.Id == mealEntryId);
    }

    public bool RemoveMealEntry(int mealEntryId)
    {
        var data = GetAllMealEntries();
        var mealEntry = data.FirstOrDefault(x => x.Id == mealEntryId);
        if (mealEntry != null)
        {
            data.Remove(mealEntry);
            var jsonData = JsonSerializer.Serialize(data);
            File.WriteAllText(mealEntryPath, jsonData);
            return true;
        }
        return false;
    }
    /// <summary>
    /// Возвращает запись целей. Если цели ещё не заданы, 
    /// создает запись по умолчания, записывает её в Json 
    /// и рекрусивно вызывает себя же.
    /// </summary>
    /// <returns></returns>
    public Goals GetGoals()
    {
        if (!File.Exists(goalsPath))
        {
            Goals goals = new Goals 
            { Calories = 1800, 
                Carbohydrates = 120, 
                Fats = 40, 
                Proteins = 90 
            };
            var jsonGoals = JsonSerializer.Serialize(goals);
            File.WriteAllText(goalsPath, jsonGoals);
            return GetGoals();
        }
        else
        {
            var jsonGoals = File.ReadAllText(goalsPath);
            var goals = JsonSerializer.Deserialize<Goals>(jsonGoals);
            return goals;
        }
    }
    /// <summary>
    /// Устонавливает цель КБЖУ.
    /// </summary>
    /// <param name="goals"></param>
    /// <returns></returns>
    public bool SetGoals(Goals goals)
    {
        if (!File.Exists(goalsPath))
        {
            var jsonGoals = JsonSerializer.Serialize(goals);
            File.WriteAllText(goalsPath, jsonGoals);
            return true;
        }
        else
        {
            File.Delete(goalsPath);
            SetGoals(goals);
            return false;
        }
    }

    public bool EditGoals(Goals goals)
    {
        throw new NotImplementedException();
    }
}
