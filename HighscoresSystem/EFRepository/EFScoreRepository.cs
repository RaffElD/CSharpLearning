using System.Collections.Generic;
using System.Linq;
using Repository;

namespace EFRepository
{
	public class EFScoreRepository : EFRepository<Score>, IScoreRepository
	{
		public EFScoreRepository(HighscoreDBContext newContext) : base(newContext)
		{
		}

		public IEnumerable<Game> GetGamesPerUser(int userId)
		{
			return ctx.Scores.Where(s => s.UserId == userId).Select(s => s.Game).Distinct().ToList();
		}

		public IEnumerable<Score> GetScoresPerGame(int gameId)
		{
			return ctx.Scores.Where(s => s.GameId == gameId).ToList();
		}
	}
}