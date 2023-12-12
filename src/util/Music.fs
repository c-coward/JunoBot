namespace JunoBot.Util

open DisCatSharp.Lavalink
open System.Collections.Generic
open System.Threading.Tasks
open DisCatSharp.CommandsNext
open DisCatSharp.Entities

module Music =

    let getLavaNode (ctx: CommandContext) =
        ctx.Client.GetLavalink().ConnectedNodes.Values |> Seq.head

    type Song =
        { Track: LavalinkTrack
          Member: DiscordMember }

    type Player(conn: LavalinkGuildConnection) =
        member val Connection: LavalinkGuildConnection = conn
        member val Playlist: Queue<Song> = Queue<Song>()

    type GuildPlayer = Dictionary<DiscordGuild, Player>

    type MusicController() =
        member val Players = GuildPlayer()

// member this.AddGuildConnection (ctx: CommandContext) =
//     if not (this.Players.ContainsKey ctx.Guild)
//     then
//         let node = getLavaNode ctx
//         this.Players.Add(guild, Player(getLavaNode ctx))
