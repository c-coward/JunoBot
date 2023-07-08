namespace JunoBot

open System.IO
open Microsoft.Extensions.Configuration

module Configuration =
    [<CLIMutable>]
    type Lavalink =
        { Hostname: string
          Port: int
          Password: string }

    [<CLIMutable>]
    type Config = { Token: string; Lavalink: Lavalink }

    let appConfig =
        ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("config/AppSettings.json", true, true)
            .Build()
            .Get<Config>()
