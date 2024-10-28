using ApplicationForTrainingWEB.Application.ViewModels.PostVm;
using ApplicationForTrainingWEB.Application.ViewModels.ReadyRecipesVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.Interfaces
{
    public interface IReadyRecipesService
    {
        ListReadyRecipesVm GetAllReadyRecipesForList(int pageSize, int pageNO, string searchString);
        int AddReadyRecipes(NewReadyRecipesVm model);
        ReadyRecipesDetailVm GetReadyRecipesDetail(int id);
        void DeleteReadyRecipes(int id);
    }
}
