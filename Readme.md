# Films(StreamFlix) version 0.1.0

Films is an open source project, which allows watching films.

## About version 0.1.0

This version allows you to upload your torrent file. After you upload it, it will be started to stream on your client. The output file of torrent must be `*.mp4` format (other file extensions are not supported in this version).

## Building

To build this project you must have `Docker compose` installed.

```
git clone https://github.com/AntakovAndrey/Films.git -b version-0.1.0

docker compose up
```

Your app will be available on [localhost:3000/](localhost:3000/)