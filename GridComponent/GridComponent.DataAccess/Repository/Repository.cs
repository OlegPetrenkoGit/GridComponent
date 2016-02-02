using System;
using System.Collections.Generic;
using System.Linq;

namespace GridComponent.DataAccess.Repository
{
    public class Repository
    {
        public List<T> GetEntities<T>() where T : class
        {
            using (var context = new EntitiesContext<T>())
            {
                var entities = new List<T>();

                if (context.Entities.Any())
                {
                    entities = context.Entities.ToList();
                }

                return entities;
            }
        }

        public bool AddEntity<T>(T entity) where T : class
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