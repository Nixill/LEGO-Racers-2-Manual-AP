The scripts in this folder can be used to manipulate your LEGO Racers 2 save game to make setting up an archipelago game easier. Which script you need depends on exactly what you want to do.

All of these scripts are tested only on Windows (using .NET 10 SDK's `dotnet run file.cs` feature). If you have LEGO Racers 2 working on a Unix-based system (through Wine or whatever), please send a pull request with your save game folders!

Remember that if you change any options, you will need to change those options across all scripts!

All file operations described below overwrite the destination file if it already exists.

# [1] Download AP save and copy into place
The script `DownloadSave.cs` is designed for first-time setup. It will take my pre-made AP-ready save and copy it to your save games folder, replacing the existing save (which will be backed up; if a backup already exists, that backup will be deleted).

Specifically:
1. `GameSave` renamed to `GameSave-PreAPBackup`
2. Download copied to `GameSave`
3. Download copied to `GameSave-APReady`

*💡 This script will look for a game save at `./GameSave`, `./saves/GameSave`, and `../saves/GameSave` (either right next to the script or at various relative paths in the repository). If it is not found at any of those locations, it will be downloaded from the repository and saved adjacent to the script.*

# [2] Use existing save as AP-ready save
The script `PrepareCurrentSave.cs` is also designed for first-time setup. It will treat your existing save file as the AP-ready save and make a copy to be reset to later.

Specifically:
1. `GameSave` copied to `GameSave-APReady`
2. `GameSave` copied to `GameSave-PreAPBackup`

# [3] Copy AP save from within saved games folder
The script `ResetAPSave.cs` is designed for resetting after playing an AP. It will take the APReady save that exists in the folder and overwrite the current save with it.

Specifically:
1. `GameSave-APReady` copied to `GameSave`

# [4] Restore backed-up save without deleting AP-ready save
The script `RestoreBackupSave.cs` is designed to restore your backed-up non-AP save.

Specifically:
1. `GameSave-PreAPBackup` copied to `GameSave`

# [5] Switch personal save back to AP-ready save
The script `RestoreAPReadySave.cs` is designed to return to AP play.

Specifically:
1. `GameSave` moved to `GameSave-PreAPBackup`
2. `GameSave-APReady` copied to `GameSave`

# [6] Uninstall AP-ready saves altogether
The script `UninstallSaves.cs` is designed to remove evidence of the AP from the Saved Games folder.

Specifically:
1. `GameSave-APReady` deleted.
2. `GameSave-PreAPBackup` moved to `GameSave`.
