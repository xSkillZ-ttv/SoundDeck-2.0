# Sound Deck 2.0 (by SkillZ)

**Disclaimer:** This is a customized, updated, and streamlined fork of the original [Sound Deck by GeekyEggo](https://github.com/GeekyEggo/SoundDeck). All original credit goes to GeekyEggo; I am not the original creator of the initial Sound Deck project.

This version (Sound Deck 2.0) has been modernized to work flawlessly with the latest Stream Deck updates (6.0+). It strips away unnecessary features to provide a lightweight, lightning-fast experience focused purely on **Audio Playback** and **Sampling**.

## 🚀 Features

- **Play Audio:** Play any audio file or a folder of files seamlessly.
- **Stop Audio:** Instantly stop all audio playing through the plugin.
- **Sampler:** Record quick audio samples directly from your microphone and play them back on demand.
- **Clear Sampler:** Wipe the current sample to record a new one.

## 🛠️ What's new in 2.0?

- **Modern SDK Support:** Upgraded internal libraries (`SharpDeck` v6.0.1) to support modern Stream Deck and Stream Deck+ clients without freezing or crashing.
- **Fixed Hidden Dialogs:** Fixed a major bug where the file/folder selection windows would crash or open invisibly behind the Stream Deck app.
- **Debounced Inputs:** Added safety locks so pressing "Add files..." rapidly won't spawn multiple windows or crash the plugin.
- **Lightweight:** Removed unused actions (App volume control, Clip audio, etc.) and their assets to keep the plugin highly optimized and focused.

## 📦 Installation

1. Download the `Sound Deck 2.0.streamDeckPlugin` file from the `dist` folder.
2. Double-click the file to install it into your Elgato Stream Deck software.
3. Drag and drop the actions onto your Stream Deck!

## 📜 License

Sound Deck is licensed under [GNU General Public License v3 (GPL-3)](LICENSE.md).
