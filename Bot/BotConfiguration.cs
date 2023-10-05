using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;


namespace ScheduleBot
{
    public class BotConfiguration
    {
        public BotConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            
            AppConfiguration = builder.Build();
        }

        public IConfiguration AppConfiguration { get; set; }
    }
}
