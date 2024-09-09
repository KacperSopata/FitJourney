using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.ViewModels.Calculator
{
    public class Calculator
    {
        [Display(Name = "Płeć")]
        public string Gender { get; set; }
        public List<string> Genders { get; set; } = new List<string> { "Mężczyzna", "Kobieta" };
        [Display(Name = "Cel")]
        public string Goal { get; set; }
        public List<string> Goals { get; set; } = new List<string> { "Redukcja", "Utrzymanie", "Masa" };
        [Display(Name = "Współczynnik aktywności PAL")]
        public double Pal { get; set; }
        public List<double> Pals { get; set; } = new List<double> { 1.2, 1.4, 1.6, 1.8, 2.0 };
        public double Weight { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double? CPM { get; set; }
        public double? PPM { get; set; }

    }
}