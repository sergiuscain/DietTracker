namespace Diet_Tracker.Models;
internal class MealEntry
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public MealType MealType { get; set; }
    public string FoodName { get; set; }
    public int Calories { get; set; }
    public int Proteins { get; set; }
    public int Fats { get; set; }
    public int Carbohydrates { get; set; }
    public int PortionWeight { get; set; }


    public override string ToString()
    {
        return $"Id: {Id}, DateTime: {DateTime}, MealType: {MealType}, FoodName: {FoodName}, Calories: {Calories}, Proteins: {Proteins}, Fats: {Fats}, Carbohydrates: {Carbohydrates}, PortionWeight: {PortionWeight}";
    }
}
