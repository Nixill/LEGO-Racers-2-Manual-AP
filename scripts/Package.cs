// A script to package up the apworld from the "src" folder.

// NOTE: This script expects to be run from the *repository root* level!
// If running directly from its folder, uncomment the first non-using line.

using System.IO.Compression;
using System.Text.Json.Nodes;

// Directory.SetCurrentDirectory("..");

string gameName = "LEGO Racers 2";
string gameCreator = "Nixill";

string manualName = $"Manual_{gameName}_{gameCreator}";

ZipFile.CreateFromDirectory(manualName, $"release/{manualName}.apworld");