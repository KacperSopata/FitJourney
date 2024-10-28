using ApplicationForTrainingWEB.Domain.Interfaces;
using ApplicationForTrainingWEB.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Infrastructure.Repositories
{
    public class ReadyRecipesRepository : IReadyRecipesRepository
    {
        private readonly ApplicationForTrainingWEBDbContext _context;
        public ReadyRecipesRepository(ApplicationForTrainingWEBDbContext context)
        {
            _context = context;
        }
        public int AddReadyRecipes(ReadyRecipes readyRecipes)
        {
            readyRecipes.ApplicationUser = _context.ApplicationUsers.Find(readyRecipes.UserId);
            _context.ReadyRecipes.Add(readyRecipes);
            _context.SaveChanges();
            return readyRecipes.Id;
        }
        public void DeleteReadyRecipes(ReadyRecipes readyRecipes)
        {
            _context.ReadyRecipes.Remove(readyRecipes);
            _context.SaveChanges();
        }
        public IQueryable<ReadyRecipes> GetAllReadyRecipes()
        {
            var readyRecipes = _context.ReadyRecipes.AsQueryable();
            return readyRecipes;
        }
        public ReadyRecipes GetDetail(int id)
        {
            return _context.ReadyRecipes.FirstOrDefault(e => e.Id == id);
        }
   }
}
