using System.Collections.Generic;

namespace Repository
{
	public interface IScoreRepository : IRepository<Score>
	{
		IEnumerable<Game> GetGamesPerUser(int userId);
		IEnumerable<Score> GetScoresPerGame(int gameId);
	}
}