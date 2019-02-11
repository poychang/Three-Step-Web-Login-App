using Microsoft.Extensions.Configuration;
using System.IO;
using ThreeStepWebLoginApp.Models;

namespace ThreeStepWebLoginApp.Helpers
{
    public static class AppSettingHelper
    {
        public static AppSettingsModel Fetch()
        {
            return ReadFromAppSettings().Get<AppSettingsModel>();
        }

        private static IConfigurationRoot ReadFromAppSettings()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
        }
    }
}
