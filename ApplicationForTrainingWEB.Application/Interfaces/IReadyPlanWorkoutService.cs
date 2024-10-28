using ApplicationForTrainingWEB.Application.ViewModels.ReadyPlanWorkoutVm;
using ApplicationForTrainingWEB.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.Interfaces
{
    public interface IReadyPlanWorkoutService
    {
        ListReadyPlanWorkoutVm GetAllReadyPlanWorkoutsForList(int pageSize, int pageNO, string searchString);
        int AddReadyPlanWorkout(NewReadyPlanWorkoutVm model);
     //   ReadyPlanWorkoutDetailVm GetReadyPlanWorkoutDetail(int id);
        void DeleteReadyPlanWorkout(int id);
        IQueryable<ReadyPlanWorkout> GetPlansByType(string type);
        IQueryable<ReadyPlanWorkout> GetPlansByDifficulty(string difficulty);
        IQueryable<ReadyPlanWorkout> GetPlansByTypeAndDifficulty(string type, string difficulty);
        List<ReadyPlanWorkoutForListVm> GetPlansByTypeAndDifficulty2(string type, string difficulty);
    }
}
