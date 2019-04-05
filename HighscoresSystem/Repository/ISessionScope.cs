using System;

namespace Repository
{
	public interface ISessionScope : IDisposable
	{
		IUserRepository  UserRepository  { get; }
		IGameRepository  GameRepository  { get; }
		IScoreRepository ScoreRepository { get; }
		void Save();
	}
}