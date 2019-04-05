using System.Data.Entity;

internal class HighscoreDBInitializer : DropCreateDatabaseAlways<HighscoreDBContext>
{
	protected override void Seed(HighscoreDBContext ctx)
	{
		base.Seed(ctx);


		User user0 = ctx.Users.Add(new User { Name = "Ajay O'Reilly"  });
		User user1 = ctx.Users.Add(new User { Name = "Aida Goldsmith" });
		User user2 = ctx.Users.Add(new User { Name = "Evie-Mae Lyon" });
		User user3 = ctx.Users.Add(new User { Name = "Shae Gallagher" });
		User user4 = ctx.Users.Add(new User { Name = "Pedro Hubbard" });

		Game game0 = ctx.Games.Add(new Game { Name = "GameOne"});
		Game game1 = ctx.Games.Add(new Game { Name = "GameTwo"});
		Game game2 = ctx.Games.Add(new Game { Name = "GameThree"});
		Game game3 = ctx.Games.Add(new Game { Name = "GameFour"});

		ctx.Scores.Add(new Score { Game = game0, Points = 15, User = user0});
		ctx.Scores.Add(new Score { Game = game1, Points = 48, User = user1});
		ctx.Scores.Add(new Score { Game = game1, Points = 25, User = user4});
		ctx.Scores.Add(new Score { Game = game2, Points = 6, User  = user1});
		ctx.Scores.Add(new Score { Game = game1, Points = 13, User = user2});
		ctx.Scores.Add(new Score { Game = game3, Points = 15, User = user0});

		ctx.SaveChanges();
	}
}