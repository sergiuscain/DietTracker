using Diet_Tracker.Models;

namespace Diet_Tracker.Modules;
internal class InputAndViewModule
{
    public InputAndViewModule(ReportModule reportModule, IStorageModule storageModule)
    {

    }

    internal void View()
    {
        while (true)
        {
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
