using System.Collections.Generic;
using GridComponent.DataAccess.Repository;

namespace GridComponent.Services
{
    public class EntitiesService
    {
        private readonly Repository _repository = new Repository();

        public List<T> GetAllEntities<T>() where T : class
        {
            return _repository.GetEntities<T>();
        }

        public bool SaveEntity<T>(T entity) where T : class
        {
            return _repository.AddEntity(entity);
        }
    }
}