using System.Collections.Generic;
using GridComponent.DataAccess.Repository;

namespace GridComponent.Services
{
    public class EntitiesService
    {
        public List<T> GetAllEntities<T>() where T : class
        {
            return new Repository<T>().GetEntities();
        }

        public bool SaveEntity<T>(T entity) where T : class
        {
            return new Repository<T>().AddEntity(entity);
        }
    }
}