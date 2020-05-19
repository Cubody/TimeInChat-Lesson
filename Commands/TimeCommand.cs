using Rocket.API;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UP = Rocket.Unturned.Player.UnturnedPlayer;

namespace MyFirstPlugin.Commands
{
    class TimeCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "time";

        public string Help => "Выводит Московское время в чат";

        public string Syntax => "/time";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var up = (UP)caller;
            if (command.Length != 0)
            {
                ChatManager.serverSendMessage($"[<color=green>Time</color>] Используйте: {Syntax} - {Help}", Color.white, null, up.SteamPlayer(), EChatMode.SAY, null, true);
                return;
            }
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standart Time");
            var time = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
            ChatManager.serverSendMessage($"[<color=green>Time</color>] МСК Время: {time}", Color.white, null, up.SteamPlayer(), EChatMode.SAY, null, true);
        }
    }
}
