**What does the plugin do**
Sends a customizable message to a specified channel in a Discord Server on player Connect and Disconnect.

**Configuration**
```json
{
            "channelID": "channel ID: ",
            "joinMessages":  true,
            "leaveMessages":  true,
            "joinMessage":  "Connected {time}: {username}",
            "leaveMessage":  "Connected {time}: {username}"
}
```

**Discord Integration**

This plugin requires Discord Core.

To find the Channel ID of a Channel. First turn on Developer mode.

https://discordia.me/en/developer-mode

Then right click the specified channel and click "Copy ID"