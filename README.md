# Aces Font Patcher

A [BepInEx](https://github.com/BepInEx/BepInEx) plugin for replacing fonts in [Fallen Aces](https://store.steampowered.com/app/1411910/Fallen_Aces/).

# Installing

1. Install [BepInEx 6](https://github.com/BepInEx/BepInEx?tab=readme-ov-file#resources) into Fallen Aces.
2. Download `AcesFontPatcher.zip` from [the latest release](https://github.com/DaZombieKiller/AcesFontPatcher/releases/latest).
3. Extract the contents of the zip file into the game folder.

# Adding Fonts

1. Open the `AcesFontProject` project in the same version of Unity used by Fallen Aces (currently [2022.3.42](https://unity.com/releases/editor/whats-new/2022.3.42))
2. Add new `.ttf` or `.otf` font files to the `AcesFontProject/Assets/Fonts` directory.
3. In Unity, select `Assets` > `Build AssetBundles`
4. Copy `artifacts/bundles/fonts` into `Fallen Aces_Data/StreamingAssets` (create the folder if it doesn't exist)

# Using Fonts In-Game

1. Close the game if it is running.
2. Open `BepInEx/config/AcesFontPatcher.cfg` in a text editor
3. Edit the font replacements to use any font you included in the `fonts` bundle.
4. Save your changes and re-launch the game.

# Building The Plugin Yourself

To build `AcesFontPatcher.dll`, copy the contents of `Fallen Aces_Data/Managed/` into the `Managed/` folder of this repository.

You can then open `AcesFontPatcher.sln` in Visual Studio and build the project.
