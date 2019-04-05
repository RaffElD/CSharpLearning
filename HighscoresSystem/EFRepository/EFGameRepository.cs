using System.Collections.Generic;
using System.Linq;
using Repository;

namespace EFRepository
{
	public class EFGameRepository : EFRepository<Game>, IGameRepository
	{
		public EFGameRepository(HighscoreDBContext newContext) : base(newContext)
		{
		}

		public IEnumerable<GameInfo> GetGameInfos()
		{
			return ctx.Games.Select(game => new GameInfo()
			{
				id           = game.Id,
				name         = game.Name,
				highestScore = (game.Scores.Count != 0 ? game.Scores.Max(s => s.Points) : 0)
			}).ToList();
		}
	}
}