using ApplicationForTrainingWEB.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Domain.Interfaces
{
    public interface IReadyRecipesRepository
    {
        IQueryable<ReadyRecipes> GetAllReadyRecipes();
        int AddReadyRecipes(ReadyRecipes readyRecipes);
        ReadyRecipes GetDetail(int id);
        void DeleteReadyRecipes(ReadyRecipes readyRecipes);
    }
}
