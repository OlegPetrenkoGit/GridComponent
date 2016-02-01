using System;
using System.Collections.Generic;
using System.Linq;

namespace GridComponent.DataAccess.Repository
{
    public class Repository<T> where T : class
    {
        public List<T> GetEntities()
        {
            using (var context = new EntitiesContext<T>())
            {
                return context.Entities.ToList();
            }
        }

        public bool AddEntity(T entity)
        {
            try
            {
                using (var context = new EntitiesContext<T>())
                {
                    context.Entities.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}