using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Domain.Model
{
    public class ReadyPlanWorkout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public string  PlanType { get; set; }    // To dodaj, aby określać rodzaj treningu, np. cardio, siłowy { get; set; } 
        public string Description { get; set; }
        public string PlanDetails { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}