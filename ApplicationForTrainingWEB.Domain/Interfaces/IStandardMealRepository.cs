using ApplicationForTrainingWEB.Domain.Model;

namespace ApplicationForTrainingWEB.Domain.Interfaces;

public interface IStandardMealRepository
{
    IQueryable<Meal> GetAllMeals(DateTime selectedData);
    int AddProductTo(int productId, int mealId,int quantity);
    int GetGrammageForProduct(int productId);
    void AddMeals(List<Meal> meals);
    bool MealsExistForDate(DateTime selectedDate);
    IQueryable<Meal> GetAllMealsById(int mealId);
    void DeleteProduct(int id);
    void AddProd(MealProduct product);
}

