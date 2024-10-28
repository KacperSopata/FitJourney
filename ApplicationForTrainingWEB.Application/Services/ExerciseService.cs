using ApplicationForTrainingWEB.Application.Interfaces;
using ApplicationForTrainingWEB.Application.ViewModels.ExerciseVm;
using ApplicationForTrainingWEB.Domain.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepo;
        private readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepo = exerciseRepository;
            _mapper = mapper;
        }
        public ListExerciseForListVm GetAllExercisesForList(int pageSize, int pageNO, string searchString)
        {
            var exercise = _exerciseRepo.GetAllExercises().Where(p => p.Name.StartsWith(searchString))
             .ProjectTo<ApplicationForTrainingWEB.Application.ViewModels.ExerciseVm.ExerciseForListVm>(_mapper.ConfigurationProvider).ToList();
            var exerciseToShow = exercise.Skip(pageSize * (pageNO - 1)).Take(pageSize).ToList();
            var exerciseList = new ListExerciseForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNO,
                SearchString = searchString,
                ExerciseForListVm = exerciseToShow,
                Count = exercise.Count
            };
            return exerciseList;
        }
        public ListExerciseForListVm GetAllExercisesForList2()
        {
            var exercise = _exerciseRepo.GetAllExercises()
             .ProjectTo<ApplicationForTrainingWEB.Application.ViewModels.ExerciseVm.ExerciseForListVm>(_mapper.ConfigurationProvider).ToList();
            var exerciseList = new ListExerciseForListVm()
            {
                ExerciseForListVm = exercise
            };

            return exerciseList;
        }
        public ExerciseDetailVm GetExerciseDetail(int id)
        {
            var exercise = _exerciseRepo.GetDetail(id);
            var exerciseVm = _mapper.Map<ExerciseDetailVm>(exercise);
            return exerciseVm;
        }
        public ExerciseDetailVm GetExerciseDetailByWorkoutExercise(int id)
        {
            var exercise = _exerciseRepo.GetDetailByWorkoutExercise(id);
            var exerciseVm = _mapper.Map<ExerciseDetailVm>(exercise);
            return exerciseVm;
        }
    }
}
