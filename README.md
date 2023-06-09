<p align="center">
    <img src="https://api.xace.ch/web-assets/img/surftimer-rpc-gui.png" height="128" border-radius="10px" />
    <h1 align="center">~ SurfTimer RPC ~</h1>
    <strong>
         <p align="center">
              A SurfTimer RPC for Discord! Recode of my old cli version.
         </p>
    </strong>
</p>

---

This is an RPC (Rich Presence) client for CS:GO SurfTimer, a popular surf server plugin for Counter-Strike: Global Offensive. The client is programmed in C# using .NET Framework 4.8 and utilizes Windows Forms for the graphical user interface.

## Introduction
CS:GO SurfTimer RPC allows you to share your SurfTimer information with other users on Discord. You can choose what information to display and where to display it.

## Features
The client offers the following features:

### Module Configuration
You have the freedom to define four different modules (locations) to display your CS:GO Surftimer data.
The format will look something like this:

```
playing SurfTimer
Module 1 (| Module 2)
Module 3 (| Module 4)
```
If module 2 or 4 is not defined, the `|` that divides the module is hidden.

You can customize the value and placement of each module according to your preference.

### Available Data Values
You can choose from seven different data values to display within the defined modules:

| Value             | Description                                                                                                             | Examples                                      |
|-------------------|-------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------|
| **Nothing**       | This option allows you to hide the module from the presence.                                                            |                                               |
| **Playing State** | Displays your current playing state, including the name of the map you are surfing on.                                  | "surfing on surf\_beginner" \| "spectating on surf\_beginner"|
| **Timer**         | Shows the timer indicating your current time on the map.                                                                | "Timer: 1:23:45" \| "Timer: 01:23"             |
| **Current Map**   | Displays the name of the current map you are surfing on.                                                                | "surf\_beginner"                               |
| **Server Rank**   | Shows your rank on the server. If you are spectating, it displays the name of the replay bot.                           | "S-Rank: 150" | "S-Rank: Unranked" or "BONUS Replay"|
| **Map Completion**| Indicates the completion percentage of the current map you are surfing on.                                              | "50%"                                          |
| **Server Completion**| Displays the completion percentage of the entire servers maps.                                                       | "75%"                                          |

## Usage


1. Go to the [release page](https://github.com/13ace37/surftimer-rpc-gui/releases/) and download the [latest release](https://github.com/13ace37/surftimer-rpc-gui/releases/latest)!
2. Open the application.
    - If you are opening the application for the first time, please start CS:GO after launching the application. The application requires a config file in the cfg folder, which will be added automatically when you start CS:GO after launching the application. If you have already started CS:GO, you will need to restart CS:GO after the CGI Config light turns green.
3. Launch CS:GO
4. Modify the modules to your liking
5. Make sure you enable presence in Discord (Settings => Activity Privacy => "Show current activity as status message")
6. Enjoy your SurfTimer information displayed in Discord
