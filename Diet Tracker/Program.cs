using Diet_Tracker.Models;
using Diet_Tracker.Modules;

public class Program
{
    static void Main(string[] args)
    {
        IStorageModule storageModule = new JsonStorageModule();
        ReportModule reportModule = new ReportModule(storageModule);
        InputAndViewModule viewModule = new InputAndViewModule(reportModule, storageModule);
        viewModule.View();
    }
}
