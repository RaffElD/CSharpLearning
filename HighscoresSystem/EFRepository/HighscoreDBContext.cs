using System.Data.Entity;

public class HighscoreDBContext : DbContext
{
	static HighscoreDBContext()
	{
		Database.SetInitializer(new HighscoreDBInitializer());
	}

	public DbSet<User>  Users  { get; set; }
	public DbSet<Game>  Games  { get; set; }
	public DbSet<Score> Scores { get; set; }
}