using ApplicationForTrainingWEB.Domain.Interfaces;
using ApplicationForTrainingWEB.Domain.Model;

namespace ApplicationForTrainingWEB.Infrastructure.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationForTrainingWEBDbContext _context;

    public ExerciseRepository(ApplicationForTrainingWEBDbContext context)
    {
        _context = context;
    }
    public IQueryable<Exercise> GetAllExercises()
    {
        return _context.Exercises.AsQueryable();
    }

    public Exercise GetDetail(int id)
    {
        return _context.Exercises.FirstOrDefault(e => e.Id == id);
    }
    
    public Exercise GetDetailByWorkoutExercise(int id)
    {
        var workoutExercise = _context.WorkoutExercises.FirstOrDefault(we => we.Id == id);

        return _context.Exercises.FirstOrDefault(e => e.Id == workoutExercise.ExerciseId);
    }
}