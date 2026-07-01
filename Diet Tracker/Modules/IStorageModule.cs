using Diet_Tracker.Models;

namespace Diet_Tracker.Modules;
internal interface IStorageModule
{
    /// <summary>
    /// Добавляет запись приёма пищи
    /// </summary>
    /// <param name="mealEntry">Модель приёма пищи</param>
    /// <returns></returns>
    public bool AddMealEntry(MealEntry mealEntry);
    /// <summary>
    /// Удаляет запись приёма пищи
    /// </summary>
    /// <param name="mealEntryId">Id записи</param>
    /// <returns></returns>
    public bool RemoveMealEntry(int mealEntryId);
    /// <summary>
    /// Получает запись приёма пищи по Id
    /// </summary>
    /// <param name="mealEntryId">Id записи</param>
    /// <returns></returns>
    public MealEntry GetMealEntry(int mealEntryId);
    /// <summary>
    /// Получает все записи приемов пищи
    /// </summary>
    /// <returns></returns>
    public ICollection<MealEntry> GetAllMealEntries();
    /// <summary>
    /// Перегрузка получения записей приёмов пищи с пагинацией
    /// </summary>
    /// <param name="page">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы</param>
    /// <returns></returns>
    public ICollection<MealEntry> GetAllMealEntries(int page, int pageSize);
    public Goals GetGoals();
    public bool SetGoals(Goals goals);
    bool EditGoals(Goals goals);
}
