using System;
using Repository;

namespace EFRepository
{
	public class EFSessionScope : ISessionScope
	{
		#region IDisposable Support

		private bool disposedValue = false; // To detect redundant calls

		private Lazy<HighscoreDBContext> dbctx =
			new Lazy<HighscoreDBContext>(() => new HighscoreDBContext());

		private Lazy<IUserRepository>  userRepository;
		private Lazy<IGameRepository>  gameRepository;
		private Lazy<IScoreRepository> scoreRepository;

		public HighscoreDBContext DBctx           => dbctx.Value;
		public IUserRepository    UserRepository  => userRepository.Value;
		public IGameRepository    GameRepository  => gameRepository.Value;
		public IScoreRepository   ScoreRepository => scoreRepository.Value;

		public EFSessionScope()
		{
			userRepository  = new Lazy<IUserRepository>(() => new EFUserRepository(DBctx));
			gameRepository  = new Lazy<IGameRepository>(() => new EFGameRepository(DBctx));
			scoreRepository = new Lazy<IScoreRepository>(() => new EFScoreRepository(DBctx));
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
					if (dbctx.IsValueCreated)
					{
						dbctx.Value.Dispose();
					}
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~EFSessionScope() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);

			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}

		public void Save()
		{
			DBctx.SaveChanges();
		}

		#endregion
	}
}