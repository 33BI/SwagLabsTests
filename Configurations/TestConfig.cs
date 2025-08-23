// Configurations/TestConfig.cs
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SwagLabsTests.Configurations
{
    public static class TestConfig
    {
        private static IConfigurationRoot? _configuration;

        static TestConfig()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                    .AddEnvironmentVariables();

                _configuration = builder.Build();
            }
            catch
            {
                _configuration = null;
            }
        }

        public static string BaseUrl =>
            Environment.GetEnvironmentVariable("SWAG_LABS_URL")
            ?? _configuration?["SwagLabs:BaseUrl"]
            ?? "https://www.saucedemo.com/";

        public static string Username =>
            Environment.GetEnvironmentVariable("SWAG_LABS_USERNAME")
            ?? _configuration?["SwagLabs:Username"]
            ?? "standard_user";

        public static string Password =>
            Environment.GetEnvironmentVariable("SWAG_LABS_PASSWORD")
            ?? _configuration?["SwagLabs:Password"]
            ?? "secret_sauce";

        public static string EnvironmentName =>
            Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")
            ?? _configuration?["TestEnvironment"]
            ?? "staging";
    }
}
