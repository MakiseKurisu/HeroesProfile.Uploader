using System.Threading.Tasks;

namespace Heroesprofile.Uploader.Desktop.Updates
{
    internal interface IUpdater
    {
        public enum Outcome
        {
            /// <summary>Not an installed copy, so Velopack can't update it - see <see cref="ReleaseChecker"/>.</summary>
            NotInstalled,
            NoUpdate,
            /// <summary>An update is downloaded and applies on restart.</summary>
            ReadyToRestart,
            Failed,
        }

        public sealed class Result
        {
            public Outcome Outcome { get; init; }
            public string Version { get; init; }
        }

        Task<Result> CheckAndDownloadAsync(AppConfig config);
        bool ApplyAndRestart(bool minimized);
    }
}
