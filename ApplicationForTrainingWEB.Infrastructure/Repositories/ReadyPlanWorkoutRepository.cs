using ApplicationForTrainingWEB.Application.ViewModels.ReadyPlanWorkoutVm;
using ApplicationForTrainingWEB.Domain.Interfaces;
using ApplicationForTrainingWEB.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Infrastructure.Repositories
{
    public class ReadyPlanWorkoutRepository : IReadyPlanWorkoutRepository
    {
        private readonly ApplicationForTrainingWEBDbContext _context;

        public ReadyPlanWorkoutRepository(ApplicationForTrainingWEBDbContext context)
        {
            _context = context;
        }
        public int AddReadyPlanWorkout(ReadyPlanWorkout planWorkout)
        {
            planWorkout.ApplicationUser = _context.ApplicationUsers.Find(planWorkout.UserId);
            _context.ReadyPlanWorkouts.Add(planWorkout);
            _context.SaveChanges();
            return planWorkout.Id;
        }

        public void DeleteReadyPlanWorkout(ReadyPlanWorkout planWorkout)
        {
            _context.ReadyPlanWorkouts.Remove(planWorkout);
            _context.SaveChanges();
        }

        public IQueryable<ReadyPlanWorkout> GetAllPlanReadyWorkout()
        {
            var planWorkout = _context.ReadyPlanWorkouts.AsQueryable();
            return planWorkout;
        }

        public ReadyPlanWorkout GetDetail(int id)
        {
            return _context.ReadyPlanWorkouts.FirstOrDefault(e => e.Id == id);
        }

        public IQueryable<ReadyPlanWorkout> GetPlansByDifficulty(string difficulty)
        {
            return _context.ReadyPlanWorkouts
                                   .Where(plan => plan.Difficulty == difficulty)
                                   .AsQueryable();
        }

        public IQueryable<ReadyPlanWorkout> GetPlansByType(string type)
        {
            return _context.ReadyPlanWorkouts
                                 .Where(plan => plan.PlanType == type)
                                 .AsQueryable();
        }

        public IQueryable<ReadyPlanWorkout> GetPlansByTypeAndDifficulty(string type, string difficulty)
        {
            return _context.ReadyPlanWorkouts
                                   .Where(plan => plan.PlanType == type && plan.Difficulty == difficulty)
                                   .AsQueryable();
        }
        //public ReadyPlanWorkoutDetailVm GetReadyPlanWorkoutDetail(int id)
        //{
        //    var plan = _context.ReadyPlanWorkouts
        //                       .Include(p => p.ApplicationUser) // Ładowanie użytkownika
        //                       .FirstOrDefault(p => p.Id == id);

        //    if (plan == null)
        //        return null;

        //    return new ReadyPlanWorkoutDetailVm
        //    {
        //        Id = plan.Id,
        //        Name = plan.Name,
        //        PlanType = plan.PlanType,
        //        Difficulty = plan.Difficulty,
        //        Description = plan.Description,
        //        PlanDetails = plan.PlanDetails,
        //        ApplicationUser = plan.ApplicationUser
        //    };
        //}
    }
}
