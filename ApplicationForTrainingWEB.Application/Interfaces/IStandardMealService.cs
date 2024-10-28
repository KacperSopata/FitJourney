using ApplicationForTrainingWEB.Application.ViewModels.StandardMealVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.Interfaces
{
    public interface IStandardMealService
    {
        ListStandardMealsForListVm GetMealById(int mealId);
        ListStandardMealsForListVm GetAllMealsForList(DateTime selectedData);
        void AddMealsToDay(DateTime selectedData);
        void DeleteProduct(int id);
        int AddProductMeal(NewProductStandardInMealVm productId);
    }
}
