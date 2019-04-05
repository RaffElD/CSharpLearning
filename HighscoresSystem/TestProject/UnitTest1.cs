using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using EFRepository;

namespace TestProject
{
	[TestClass]
	public class HighScoreDBControllerTest
	{
		private HighscoreDBController HSC;

		[TestInitialize]
		public void InitializeDBController()
		{
			HSC = new HighscoreDBController(() => new EFSessionScope());
		}

		[TestMethod]
		public void CreateUser()
		{
			Assert.IsFalse(HSC.GetUsers().Any(u => u.Name == "TestUser"));
			User newUser = HSC.CreateUser("TestUser");
			Assert.IsTrue(HSC.GetUsers().Any(u => u.Name == "TestUser"));
			Assert.AreEqual(newUser.Id,HSC.GetUsers().First(u => u.Name == "TestUser").Id);
		}

		[TestMethod]
		public void CreateGame()
		{
			Assert.IsFalse(HSC.GetGames().Any(u => u.name == "GameX"));
			Game newGame = HSC.CreateGame("GameX");
			Assert.IsTrue(HSC.GetGames().Any(u => u.name == "GameX"));
		}

		[TestMethod]
		public void CreateScore()
		{
			Game newGame = HSC.CreateGame("GameX");
			Assert.IsFalse(HSC.GetScoresPerGame(newGame.Id).Any(u => u.UserId == 1 && u.Points == 100));
			Score newScore = HSC.CreateScore(1, newGame.Id, 100);
			Assert.IsTrue(HSC.GetScoresPerGame(newGame.Id).Any(u => u.UserId == 1 && u.Points == 100));
		}

		[TestMethod]
		public void GetGames()
		{
			IEnumerable<GameInfo> games = HSC.GetGames();
			Assert.IsTrue(games.Count() == 4);
			Assert.IsTrue(games.Any(g => g.name == "GameTwo"));
		}
	}
}
