using ApplicationForTrainingWEB.Application.ViewModels.UserMealVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.Interfaces
{
    public interface IUserMealService
    {
        UserMealDetailVm GetMeal(string userId, DateTime selectedDate);
        int AddMeal(UserNewMealVm model);
        void DeleteMeal(int mealid);
        int AddProductToMeal(NewProductInUserInMealVm model);
        DateTime GetMealDate(int modelMealId);
        NewProductInUserInMealVm GetMealProductById(int mealId);
        void UpdateProduct(NewProductInUserInMealVm model);
        void DeleteProduct(int id);
        bool DoesProductExistInMeal(int modelMealId, int modelProductId);
    }
}
