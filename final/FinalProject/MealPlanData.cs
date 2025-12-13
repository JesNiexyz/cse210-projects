public class MealPlanData
    {
        public DateTime WeekStartDate { get; set; }
        public Dictionary<string, DailyMeals> DailyMealsData { get; set;}

        public MealPlanData()
        {
            DailyMealsData = new Dictionary<string, DailyMeals>();
        }
    }