using ApplicationForTrainingWEB.Domain.Model;

namespace ApplicationForTrainingWEB.Domain.Interfaces;

public interface IWorkoutRepository
{
    bool WorkoutExistForDate(DateTime selectedDate);
    Workout GetWorkout(DateTime selectedDate, string applicationUserId);
    List<WorkoutExercise> GetExercises(int workoutId, string userId);
    void AddExerciseTo(WorkoutExercise workout);
    Workout GetWorkoutById(int workoutId);
    void DeleteProduct(int id);
    void UpdateExercise(int workoutId, int exerciseId, int sets, int reps, float weight);
    int AddWorkout(Workout product);
    void DeleteWorkout(int workoutid);
    int AddExercise(WorkoutExercise exer);
    WorkoutExercise GetWorkoutExerciseById(int id);
    void UpdateProduct(WorkoutExercise workoutexercise);

}