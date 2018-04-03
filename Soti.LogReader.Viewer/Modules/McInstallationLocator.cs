using System;
using Microsoft.Win32;

namespace Soti.LogReader.Viewer.Modules
{
    public class McInstallationInfo
    {
        public string InstallPath { get; set; }
        public string Version { get; set; }
    }

    public class McInstallationLocator
    {
        private const string McDisplayName = "SOTI MobiControl";
        private const string DisplayNameKey = "DisplayName";
        private const string DisplayVersionKey = "DisplayVersion";
        private const string InstallLocation = "InstallLocation";

        private static readonly string[] UninstallRegistries =
        {
            @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
        };

        public static McInstallationInfo Locate()
        {
            foreach (var uninstallRegistry in UninstallRegistries)
            {
                using (var key = Registry.LocalMachine.OpenSubKey(uninstallRegistry))
                {
                    if (key == null) continue;

                    foreach (var subKeyName in key.GetSubKeyNames())
                    {
                        using (var subkey = key.OpenSubKey(subKeyName))
                        {
                            if (subkey == null) continue;

                            var displayNameValue = subkey.GetValue(DisplayNameKey);
                            if (displayNameValue != null && displayNameValue.ToString().Equals(McDisplayName, StringComparison.InvariantCultureIgnoreCase))
                            {
                                return new McInstallationInfo()
                                {
                                    InstallPath = subkey.GetValue(InstallLocation).ToString(),
                                    Version = subkey.GetValue(DisplayVersionKey).ToString()
                                };
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
