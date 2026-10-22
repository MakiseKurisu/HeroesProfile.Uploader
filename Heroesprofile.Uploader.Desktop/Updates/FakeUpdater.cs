using System.Threading.Tasks;

namespace Heroesprofile.Uploader.Desktop.Updates
{
    internal sealed class FakeUpdater : IUpdater
    {
        public Task<IUpdater.Result> CheckAndDownloadAsync(AppConfig config)
        {
            return Task.FromResult(new IUpdater.Result { Outcome = IUpdater.Outcome.NoUpdate });
        }

        public bool ApplyAndRestart(bool minimized) => false;
    }
}
