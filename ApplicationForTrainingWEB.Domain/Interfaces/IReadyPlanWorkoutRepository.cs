using ApplicationForTrainingWEB.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Domain.Interfaces
{
    public interface IReadyPlanWorkoutRepository
    {
        IQueryable<ReadyPlanWorkout> GetAllPlanReadyWorkout();
        IQueryable<ReadyPlanWorkout> GetPlansByType(string type);
        IQueryable<ReadyPlanWorkout> GetPlansByDifficulty(string difficulty);
        IQueryable<ReadyPlanWorkout> GetPlansByTypeAndDifficulty(string type, string difficulty);
        int AddReadyPlanWorkout(ReadyPlanWorkout plan);
        ReadyPlanWorkout GetDetail(int id);
        void DeleteReadyPlanWorkout(ReadyPlanWorkout planWorkout);    
    }
}
