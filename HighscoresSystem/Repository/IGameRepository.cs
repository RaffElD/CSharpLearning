using System.Collections.Generic;

namespace Repository
{
	public interface IGameRepository : IRepository<Game>
	{
		IEnumerable<GameInfo> GetGameInfos();
	}
}