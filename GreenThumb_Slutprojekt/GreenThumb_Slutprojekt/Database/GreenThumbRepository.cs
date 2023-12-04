using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace GreenThumb_Slutprojekt.Database
{
    internal class GreenThumbRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public GreenThumbRepository(GreenThumbDbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            T? entityDelete = GetById(id);
            if (entityDelete != null)
            {
                _dbSet.Remove(entityDelete);
            }

            else
                MessageBox.Show("Sorry, could not delete. Please try again!", "Error");
        }



    }
}
