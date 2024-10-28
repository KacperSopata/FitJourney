using ApplicationForTrainingWEB.Application.ViewModels.ExerciseVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.Interfaces
{
    public interface IExerciseService
    {
        ListExerciseForListVm GetAllExercisesForList(int pageSize, int pageNO, string searchString);
        ExerciseDetailVm GetExerciseDetail(int id);
        ListExerciseForListVm GetAllExercisesForList2();
        ExerciseDetailVm GetExerciseDetailByWorkoutExercise(int id);
    }
}
