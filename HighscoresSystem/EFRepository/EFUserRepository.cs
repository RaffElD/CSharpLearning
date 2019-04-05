using System.Collections.Generic;
using System.Linq;
using Repository;

namespace EFRepository
{
	public class EFUserRepository : EFRepository<User>, IUserRepository
	{
		public EFUserRepository(HighscoreDBContext newContext) : base(newContext)
		{
		}

		public IEnumerable<UserScore> GetTotalScores()
		{
			return ctx.Users.Select(u =>
				                 new UserScore()
				                 {
					                 userId       = u.Id,
					                 totalScore   = (u.Scores.Count != 0 ? u.Scores.Sum(s => s.Points) : 0),
					                 highestScore = (u.Scores.Count != 0 ? u.Scores.Max(s => s.Points) : 0)
				                 })
			   .OrderByDescending(s => s.totalScore)
			   .Take(10)
			   .ToList();
		}
	}
}