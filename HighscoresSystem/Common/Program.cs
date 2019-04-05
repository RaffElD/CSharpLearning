using System;
using EFRepository;
using Repository;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
			HighscoreDBController controller = new HighscoreDBController(() => new EFSessionScope());

			// CreateUser
			User newUser = controller.CreateUser("TestUser");
			Console.WriteLine("New user created: {1} ({0})", newUser.Id, newUser.Name);

			// CreateGame
			Game newGame = controller.CreateGame("GameX");
			Console.WriteLine("New game created: {1} ({0})", newGame.Id, newGame.Name);

			// CreateScore
			Score newScore = controller.CreateScore(newUser.Id, newGame.Id, 37);
			Console.WriteLine("New score created: {1} got {2} points on {3} ({0})", newScore.Id, newScore.UserId,
							  newScore.Points, newScore.GameId);

			// GetGames
			Console.WriteLine("\n All games with highest score:");
			foreach(GameInfo gameInfo in controller.GetGames())
			{
				Console.WriteLine("Highest score on {0}: {1}", gameInfo.name, gameInfo.highestScore);
			}

			// GetUsers
			Console.WriteLine("\n All users with id and name:");
			foreach(User user in controller.GetUsers())
			{
				Console.WriteLine("{0}: {1}", user.Id, user.Name);
			}

			// GetScoresPerGame
			Console.WriteLine("\n All scores of game with id 2:");
			foreach(Score score in controller.GetScoresPerGame(2))
			{
				Console.WriteLine("User with id {0} reached {1} points", score.UserId, score.Points);
			}

			// GetGamesPerUser
			Console.WriteLine("\n All games user with id 2 played:");
			foreach(Game game in controller.GetGamesPerUser(2))
			{
				Console.Write("{0}, ", game.Name);
			}
			Console.WriteLine("\n");

			// GetTotalScores
			Console.WriteLine("\n Top 10 players with their highest score:");
			foreach(UserScore userScore in controller.GetTotalScores())
			{
				Console.WriteLine("{0}: {1} ({2})", userScore.userId, userScore.highestScore, userScore.totalScore);
			}
		}
	}
}