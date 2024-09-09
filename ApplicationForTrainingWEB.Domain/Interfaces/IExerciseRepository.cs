using ApplicationForTrainingWEB.Domain.Model;

namespace ApplicationForTrainingWEB.Domain.Interfaces;

public interface IExerciseRepository
{
    IQueryable<Exercise> GetAllExercises();
    Exercise GetDetail(int id);
    Exercise GetDetailByWorkoutExercise(int id);
}