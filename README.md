Sends a customizable message to a specified channel in a Discord server on player connect and disconnect.

## Configuration

```json
{
  "channelID": "channel ID: ",
  "joinMessages":  true,
  "leaveMessages":  true,
  "joinMessage":  "Connected {time}: {username}",
  "leaveMessage":  "Connected {time}: {username}"
}
```

## Discord Setup

This plugin requires the Discord Core plugin.

To find the Channel ID of a Channel. First turn on [Developer Mode](https://discordia.me/en/developer-mode).

Then right click the specified channel and click "Copy ID"