using System;
using System.Collections.Generic;
using Repository;

namespace Server
{
	public class HighscoreDBController
	{
		private readonly Func<ISessionScope> sessionFactory;

		public HighscoreDBController(Func<ISessionScope> sessionFactoryDelegate)
		{
			sessionFactory = sessionFactoryDelegate;
		}

		public User CreateUser(string userName)
		{
			using (var session = sessionFactory.Invoke())
			{
				User newUser = session.UserRepository.Create(new User() { Name = userName });
				session.Save();
				return newUser;
			}
		}

		public Game CreateGame(string gameName)
		{
			using (var session = sessionFactory.Invoke())
			{
				Game newGame = session.GameRepository.Create(new Game() { Name = gameName });
				session.Save();
				return newGame;
			}
		}

		public Score CreateScore(int userId, int gameId, int points)
		{
			using (var session = sessionFactory.Invoke())
			{
				Score newScore = session.ScoreRepository.Create(new Score() { UserId = userId, GameId = gameId, Points = points});
				session.Save();
				return newScore;
			}
		}

		public IEnumerable<GameInfo> GetGames()
		{
			using (var session = sessionFactory.Invoke())
			{
				return session.GameRepository.GetGameInfos();
			}
		}

		public IEnumerable<User> GetUsers()
		{
			using (var session = sessionFactory.Invoke())
			{
				return session.UserRepository.GetAll();
			}
		}

		public IEnumerable<Score> GetScoresPerGame(int gameId)
		{
			using (var session = sessionFactory.Invoke())
			{
				return session.ScoreRepository.GetScoresPerGame(gameId);
			}
		}

		public IEnumerable<Game> GetGamesPerUser(int userId)
		{
			using (var session = sessionFactory.Invoke())
			{
				return session.ScoreRepository.GetGamesPerUser(userId);
			}
		}

		public IEnumerable<UserScore> GetTotalScores()
		{
			using (var session = sessionFactory.Invoke())
			{
				return session.UserRepository.GetTotalScores();
			}
		}
	}
}