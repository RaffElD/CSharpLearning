using System.Collections.Generic;
using System.Linq;
using Repository;

namespace EFRepository
{
	public class EFRepository<EFEntity> : IRepository<EFEntity> where EFEntity : class
	{
		protected readonly HighscoreDBContext ctx;

		protected EFRepository(HighscoreDBContext newContext)
		{
			ctx = newContext;
		}

		public EFEntity Create(EFEntity entity)
		{
			EFEntity newEntity = ctx.Set<EFEntity>().Add(entity);
			return newEntity;
		}

		public IEnumerable<EFEntity> GetAll()
		{
			return ctx.Set<EFEntity>().ToList();
		}

		public EFEntity GetById(int id)
		{
			return ctx.Set<EFEntity>().Find(id);
		}
	}
}