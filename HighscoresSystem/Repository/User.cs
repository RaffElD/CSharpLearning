using System.Collections.Generic;

public class User
{
	public int                Id     { get; set; }
	public string             Name   { get; set; }
	public ICollection<Score> Scores { get; set; }
}