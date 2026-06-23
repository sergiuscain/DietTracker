using Diet_Tracker.Models;

namespace Diet_Tracker.Modules;
internal class ReportModule
{
    private readonly IStorageModule _storageModule;
    public ReportModule(IStorageModule storageModule)
    {
        _storageModule = storageModule;
    }
    /// <summary>
    /// Ежедневный отчёт
    /// </summary>
    /// <returns></returns>
    public ICollection<MealEntry> DailyReport()
    {
        return _storageModule.GetAllMealEntries().Where(x => x.DateTime.Date == DateTime.Today.Date).ToList();
    }
    public ICollection<MealEntry> PeriodReport(DateTime startDate, DateTime endDate)
    {
        return _storageModule.GetAllMealEntries().Where(x => x.DateTime.Date >= startDate && x.DateTime.Date <= endDate).ToList();
    }
    public NutrientGoalReport GetNutrientGoalReport(DateTime date)
    {
        var dailyEntry = _storageModule.GetAllMealEntries().Where(x => x.DateTime == date.Date);
        var goals = _storageModule.GetGoals();
        var report = new NutrientGoalReport
        {
            GoalCalories = goals.Calories,
            GoalCarbohydrates = goals.Carbohydrates,
            GoalFats = goals.Fats,
            GoalProteins = goals.Proteins,

            CurrentCalories = dailyEntry.Select(x => x.Calories).Sum(x => x),
            CurrentCarbohydrates = dailyEntry.Select(x => x.Carbohydrates).Sum(x => x),
            CurrentFats = dailyEntry.Select(x => x.Fats).Sum(x => x),
            CurrentProteins = dailyEntry.Select(x => x.Proteins).Sum(x => x)
        };
        return report;
    }
}
