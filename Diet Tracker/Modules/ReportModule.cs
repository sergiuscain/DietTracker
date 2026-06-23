using Diet_Tracker.Models;

namespace Diet_Tracker.Modules;
internal class ReportModule
{
    /// <summary>
    /// Ежедневный отчёт
    /// </summary>
    /// <returns></returns>
    public ICollection<MealEntry> DailyReport()
    {
        return new List<MealEntry>();
    }
    public ICollection<MealEntry> PeriodReport()
    {
        return new List<MealEntry>();
    }
    public NutrientGoalReport GetNutrientGoalReport(DateTime date)
    {
        return new NutrientGoalReport();
    }
}
