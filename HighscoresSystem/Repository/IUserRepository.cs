using System.Collections.Generic;

namespace Repository
{
	public interface IUserRepository : IRepository<User>
	{
		IEnumerable<UserScore> GetTotalScores();
	}
}