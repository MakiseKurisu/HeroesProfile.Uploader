using Heroesprofile.Uploader.Desktop.Platform;
using System;
using System.Runtime.Versioning;

namespace Heroesprofile.Uploader.Desktop
{
    /// <summary>
    /// `install`/`uninstall`: adds/removes this app from the Linux app menu. Deliberately only ever
    /// touches ~/.local/{bin,share} (see <see cref="DesktopIntegration"/>) - no sudo, no system paths.
    /// </summary>
    [SupportedOSPlatform("linux")]
    internal static class InstallCommand
    {
        public static int Install()
        {
            var whyNot = DesktopIntegration.WhyNotInstallable();
            if (whyNot != null) {
                Console.Error.WriteLine(whyNot);
                return 2;
            }

            DesktopIntegration.InstallAppMenuEntry();
            Console.WriteLine($"Added {DesktopIntegration.RunningAppImage ?? DesktopIntegration.InstalledExePath} to the app menu.");
            Console.WriteLine("Run it from your app launcher, or enable \"Start on login\" from its Settings dialog.");
            return 0;
        }

        public static int Uninstall()
        {
            var whyNot = DesktopIntegration.WhyNotInstallable();
            if (whyNot != null) {
                Console.Error.WriteLine(whyNot);
                return 2;
            }

            DesktopIntegration.UninstallAppMenuEntry();
            Console.WriteLine(DesktopIntegration.CurrentBuildType == DesktopIntegration.BuildType.SingleFileBinary
                ? "Removed the app menu entry, icon, autostart entry, and the ~/.local/bin copy."
                : "Removed the app menu entry, icon, and autostart entry.");
            Console.WriteLine($"Your settings and replay data under {AppConfig.DataDir} were left alone.");
            return 0;
        }
    }
}
