// This script will backup your existing save file, and then load the
// save from this repository into your LEGO Racers 2 save locations.
//
// Settings (remember to change them on all scripts!)
const string PreAPBackup = "GameSave-PreAPBackup";
const string APReadySave = "GameSave-Archipelago";
//
// This script is only tested on Windows. Please feel free to test on Mac
// or Linux, if you have LEGO Racers 2 working there, and submit a pull
// request as appropriate to update the script!

string savePath = "./GameSave";

if (File.Exists("./saves/GameSave")) savePath = "./saves/GameSave";
else if (File.Exists("../saves/GameSave")) savePath = "../saves/GameSave";

if (!File.Exists(savePath))
{
  Console.WriteLine("GameSave doesn't exist, downloading from GitHub...");
  using var client = new HttpClient();
  using var s = client.GetStreamAsync("https://github.com/Nixill/LEGO-Racers-2-Manual-AP/raw/refs/heads/main/saves/GameSave");
  using var fs = new FileStream(savePath, FileMode.Create);
  await s.Result.CopyToAsync(fs);
  Console.WriteLine("Done!");
}

var lr2SaveFolder = Path.Combine(
  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
  "Games",
  "LEGO Racers 2",
  "Saved Games"
);

string SaveFile(string filename = "GameSave") => Path.Combine(lr2SaveFolder, filename);

File.Move(SaveFile(), SaveFile(PreAPBackup), true);
File.Copy(savePath, SaveFile(), true);
File.Copy(savePath, SaveFile(APReadySave), true);
Console.WriteLine("Done!");
