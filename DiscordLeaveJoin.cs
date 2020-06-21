// Requires: DiscordCore
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.DiscordObjects;

namespace Oxide.Plugins
{
    [Info("Discord Leave Join", "Whisper", "1.0.0")]
    [Description("Sends Message To Discord On Player Connect And Disconnect")]
    class DiscordLeaveJoin : RustPlugin
    {
        [PluginReference] private Plugin DiscordCore;
        string channelID;
        bool joinMessages;
        bool leaveMessages;
        string joinMessage;
        string leaveMessage;
        PluginConfig _config;
        static DiscordLeaveJoin ins;
        public class PluginConfig
        {
            public string channelID = "channel ID: ";
            public bool joinMessages = true;
            public bool leaveMessages = true;
            public string joinMessage = "Connected {time}: {username}";
            public string leaveMessage = "Connected {time}: {username}";
        }
        private void SaveConfig()
        {
            Config.WriteObject(_config, true);
        }
        void Init()
        {
            _config = Config.ReadObject<PluginConfig>();
            Config.WriteObject(_config);

            if(_config.joinMessages == null || _config.leaveMessages == null) {
                LoadDefaultConfig();
            }
        }
        private void OnDiscordCoreReady()
        {
            DiscordCore.Call("SendMessageToChannel", _config.channelID, "==========");
            DiscordCore.Call("SendMessageToChannel", _config.channelID, "Plugin Running. Active Players:");
            foreach (BasePlayer player in BasePlayer.activePlayerList) DiscordCore.Call("SendMessageToChannel", _config.channelID, player.displayName);
            DiscordCore.Call("SendMessageToChannel", _config.channelID, "==========");
        }
        private void OnServerShutdown()
        {
            DiscordCore.Call("SendMessageToChannel", _config.channelID, "Plugin Closing");
        }
        protected override void LoadDefaultConfig() {
            Puts($"Writing new Config");
            Config.WriteObject(new PluginConfig(), true);
        }
        void OnPlayerConnected(BasePlayer player)
        {
            if(_config.channelID == null) return;
            if(!_config.joinMessages) return;

            string discordMessage = _config.joinMessage.Replace("{time}", "[" + DateTime.Now.ToShortTimeString() + "]").Replace("{username}", player.displayName);
            DiscordCore.Call("SendMessageToChannel", _config.channelID, discordMessage);
        }
        void OnPlayerDisconnected(BasePlayer player)
        {
            if(_config.channelID == null) return;
            if(!_config.leaveMessages) return;
 
            string discordMessage = _config.leaveMessage.Replace("{time}", "[" + DateTime.Now.ToShortTimeString() + "]").Replace("{username}", player.displayName);
            DiscordCore.Call("SendMessageToChannel", _config.channelID, discordMessage);
        }
    }
}