﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Domain.Model
{
    public class Workout
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartWorkout { get; set; }
        public DateTime EndWorkout { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}