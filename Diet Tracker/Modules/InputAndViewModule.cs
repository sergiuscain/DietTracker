using Diet_Tracker.Models;

namespace Diet_Tracker.Modules;
internal class InputAndViewModule
{
    private readonly IStorageModule _storageModule;
    private readonly ReportModule _reportModule;
    public InputAndViewModule(ReportModule reportModule, IStorageModule storageModule)
    {
        _reportModule = reportModule;
        _storageModule = storageModule;
    }

    internal void View()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write($"\t═══════════════════════════════════════\n");
            Console.Write($"\t════════════ДНЕВНИК ПИТАНИЯ════════════\n");
            Console.Write($"\t═══════ 1.Добавить приём пищи ═════════\n");
            Console.Write($"\t═══════ 2.Отчёт за сегодня ════════════\n");
            Console.Write($"\t═══════ 3.Выполнение целей (КБЖУ) ═════\n");
            Console.Write($"\t═══════════════════════════════════════\n");
            Console.Write($"\t═══════ 4.Все записи ══════════════════\n");
            Console.Write($"\t═══════ 5.Отчёт за неделю ═════════════\n");
            Console.Write($"\t═══════ 0.Выход ═══════════════════════\n");
            Console.Write($"\t═══════════════════════════════════════\n");
            Console.Write($"\t═══════════════════════════════════════\n");
            var input = GetInputRangeKey(5);
            switch (input)
            {
                case 0:
                    Exit();
                    break;
                case 1:
                    ShowAddMealEntryMenu();
                    break;
                case 2:
                    ShowDailyReportMenu();
                    break;
                case 3:
                    ShowGoalsMenu();
                    break;
                case 4:
                    ShowAllMealEntryMenu();
                    break;
                case 5:
                    ShowWeeklyReportMenu();
                    break;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        }
    }

    private void ShowWeeklyReportMenu()
    {
        throw new NotImplementedException();
    }

    private void ShowAllMealEntryMenu()
    {
        Console.Clear();
        var entries = _storageModule.GetAllMealEntries();

        foreach (var entry in entries)
        {
            Console.WriteLine($"\tId: {entry.Id}");
            Console.WriteLine($"\tДата: {entry.DateTime}");
            Console.WriteLine($"\tТип: {entry.MealType}");
            Console.WriteLine($"\tБлюдо: {entry.FoodName}");
            Console.WriteLine($"\tКалории: {entry.Calories}");
            Console.WriteLine($"\tБелки: {entry.Proteins}г");
            Console.WriteLine($"\tЖиры: {entry.Fats}г");
            Console.WriteLine($"\tУглеводы: {entry.Carbohydrates}г");
            Console.WriteLine($"\tВес: {entry.PortionWeight}г");
            Console.WriteLine($"\t----------------------------------------");
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\tНажмите любую клавишу, что бы вернуться в меню");
        Console.ReadKey(); 
    }

    private void ShowGoalsMenu()
    {
        throw new NotImplementedException();
    }

    private void ShowDailyReportMenu()
    {
        throw new NotImplementedException();
    }

    private void ShowAddMealEntryMenu()
    {
        Console.Clear();

        Console.Write("Введите название блюда: ");
        string foodName = Console.ReadLine();

        Console.Write("Введите тип приема пищи (0-завтрак, 1-обед, 2-ужин, 3-перекус, 4-другое): ");
        MealType mealType = (MealType)GetInputRangeKey(4);

        Console.Write("Введите калории: ");
        int calories = GetInputRangeKey(3000);

        Console.Write("Введите белки (г): ");
        int proteins = GetInputRangeKey(1000);

        Console.Write("Введите жиры (г): ");
        int fats = GetInputRangeKey(1000);

        Console.Write("Введите углеводы (г): ");
        int carbohydrates = GetInputRangeKey(1000);

        Console.Write("Введите вес порции (г): ");
        int portionWeight = GetInputRangeKey(1000);

        var entry = new MealEntry
        {
            DateTime = DateTime.Now,
            MealType = mealType,
            FoodName = foodName,
            Calories = calories,
            Proteins = proteins,
            Fats = fats,
            Carbohydrates = carbohydrates,
            PortionWeight = portionWeight
        };

        _storageModule.AddMealEntry(entry);
        Console.WriteLine("Запись добавлена.");
    }

    private void Exit()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\tВы вышли из приложения.");
        Console.ForegroundColor= ConsoleColor.White;
        Environment.Exit(0);
    }

    private int GetInputRangeKey(int range)
    {
        while(true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int number))
                if (number >= 0 && number <= range)
                    return number;
            Console.WriteLine("Неверный формат ввода.");
        }
    }
}
