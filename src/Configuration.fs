namespace JunoBot

module Configuration =

    type Lavalink =
        { Hostname: string
          Port: int
          Password: string }

    type Config = { Token: string; Lavalink: Lavalink }

    let appConfig =
        { Token = System.Environment.GetEnvironmentVariable "DISCORD_TOKEN"
          Lavalink =
            { Hostname = System.Environment.GetEnvironmentVariable "LAVALINK_HOSTNAME"
              Port = System.Environment.GetEnvironmentVariable "LAVALINK_PORT" |> int
              Password = System.Environment.GetEnvironmentVariable "LAVALINK_PASSWORD" } }
