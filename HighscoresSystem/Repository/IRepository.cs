using System.Collections.Generic;

namespace Repository
{
	public interface IRepository<TEntity> where TEntity : class
	{
		TEntity GetById(int id);

		IEnumerable<TEntity> GetAll();

		TEntity Create(TEntity entity);
	}
}