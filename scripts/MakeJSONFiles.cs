// A small script to make the items.json and locations.json files for the AP.

// NOTE: This script expects to be run from the *repository root* level!
// If running directly from its folder, uncomment the first non-using line.

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

// Directory.SetCurrentDirectory("..");

LegoWorld SandyBay = new LegoWorld(
  Name: "Sandy Bay",
  RaceNames: ["Dig-a-Brick", "Express Delivery", "Hot Stuff", "Bobby's Beat"],
  BossRaceName: null,
  GoldenBrickNames: ["Beachside", "Cliffside", "Mountain"],
  NPCNames: [
    "(player)",
    "Ben",
    "Captain Geoff",
    "Doctor Dave",
    "Fireman Gavin",
    "Fisherman",
    "Foreman Stu",
    "Gillian",
    "Jan",
    "Jay",
    "Jimmy",
    "Laura",
    "Mike the Postman",
    "Pauline",
    "PC Bobby",
    "Rachel",
    "Sparky",
    "Steve",
    "Suzie",
    "Tony the Coastguard",
    "Workman Fred",
    "Workman Jon",
    "Workman Rob"
  ],
  NPCBossName: null,
  WorldIndex: 1,
  IsStartingWorld: true
);

LegoWorld DinoIsland = new LegoWorld(
  Name: "Dino Island",
  RaceNames: [
    "Tribal Trouble",
    "Dino Dodgems",
    "The Lost Race World",
    "Cretaceous Canyon"
  ],
  BossRaceName: "Sam Sanister's Slammer",
  GoldenBrickNames: [
    "Plateau",
    "Oceanside",
    "Jungle"
  ],
  NPCNames: [
    "Achu",
    "Alexandria Sanister",
    "Bungo",
    "Johnny Thunder",
    "Mike",
    "Morat",
    "Pippin",
    "Slyboots"
  ],
  NPCBossName: "Sam Sanister",
  WorldIndex: 2
);

LegoWorld Mars = new LegoWorld(
  Name: "Mars",
  RaceNames: [
    "The Phobos Anomaly",
    "Red Run",
    "Deimos Derby",
    "Contact"
  ],
  BossRaceName: "Riegel's Racetrak",
  GoldenBrickNames: [
    "Powerstore",
    "Gold Mine",
    "Alien Base"
  ],
  NPCNames: [
    "Altair",
    "Antares",
    "BB",
    "Doc",
    "Scientist",
    "Vega"
  ],
  NPCBossName: "Riegel",
  WorldIndex: 3
);

LegoWorld Arctic = new LegoWorld(
  Name: "Arctic",
  RaceNames: [
    "Winter Wonderland",
    "Ice Canyons",
    "Slip Sliding",
    "Chill Thrill"
  ],
  BossRaceName: "The Berg's Royal Rumble",
  GoldenBrickNames: [
    "Crash Site",
    "Trapped Ship",
    "Base Camp"
  ], NPCNames: [
    "Captain Ross",
    "Chilly",
    "Cosmo",
    "Crystal",
    "Doc",
    "Frosty"
  ],
  NPCBossName: "The Berg",
  WorldIndex: 4
);

LegoWorld Xalax = new LegoWorld(
  Name: "Xalax",
  RaceNames: [
    "Wheeled Warriors",
    "Smash 'n' Bash",
    "Vertigo",
    "Beyond the Dome"
  ],
  BossRaceName: "The Grand Finale",
  GoldenBrickNames: [
    "Tubeside",
    "Jump Ramp",
    "Dormant Volcano"
  ],
  NPCNames: [
    "Warrior"
  ],
  NPCBossName: "Rocket Racer",
  WorldIndex: 5,
  IsFinalWorld: true
);

JsonSerializerOptions options = new JsonSerializerOptions
{
  DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
  WriteIndented = true,
  IndentCharacter = ' ',
  IndentSize = 4,
  NewLine = "\n"
};

// Note that these file paths are relative to the *root of this repository* (the parent directory to this file's location).
File.WriteAllText("src/data/items.json", new JsonObject
{
  ["$schema"] = "../../schemas/Manual.items.schema.json",
  ["data"] = new JsonArray([
    .. SandyBay.GetItems(),
    .. DinoIsland.GetItems(),
    .. Mars.GetItems(),
    .. Arctic.GetItems(),
    .. Xalax.GetItems(),
    .. GetTraps()
  ])
}.ToJsonString(options));

File.WriteAllText("src/data/locations.json", new JsonObject
{
  ["schema"] = "../../schemas/Manual.locations.schema.json",
  ["data"] = new JsonArray([
    .. SandyBay.GetLocations(),
    .. DinoIsland.GetLocations(),
    .. Mars.GetLocations(),
    .. Arctic.GetLocations(),
    .. Xalax.GetLocations()
  ])
}.ToJsonString(options));

IEnumerable<JsonObject> GetTraps() =>
[
  GetTrap("Item Embargo"),
  GetTrap("Freeze"),
  GetTrap("Destroy your Car"),
  GetTrap("Hold Talk"),
  GetTrap("No Shortcuts"),
  GetTrap("No Pitstops"),
  GetTrap("Drive in Reverse")
];

JsonObject GetTrap(string name) => new JsonObject
{
  ["name"] = $"TRAP - {name}",
  ["trap"] = true,
  ["category"] = new JsonArray([$"TRAP - {name}"])
};

record class LegoWorld(string Name, string[] RaceNames, string? BossRaceName, string[] GoldenBrickNames, string[] NPCNames, string? NPCBossName, int WorldIndex, bool IsStartingWorld = false, bool IsFinalWorld = false)
{
  public IEnumerable<JsonObject> GetItems()
  {
    if (!IsStartingWorld)
    {
      foreach (string race in RaceNames)
        yield return new JsonObject
        {
          ["name"] = $"{race} Race Key",
          ["progression"] = true
        };
      yield return new JsonObject
      {
        ["name"] = $"{Name} Boss Key",
        ["classification_count"] = new JsonObject
        {
          ["progression"] = 5,
          ["filler"] = 5
        }
      };
      yield return new JsonObject
      {
        ["name"] = $"{Name} Exploration Key",
        ["progression"] = true
      };
    }
    yield return new JsonObject
    {
      ["name"] = $"{Name} Hard Bonus Game Key",
      ["classification_count"] = new JsonObject
      {
        ["progression"] = 1,
        ["filler"] = 1
      }
    };
  }

  public IEnumerable<JsonObject> GetLocations()
  {
    foreach ((int i, string race) in RaceNames.Index())
    {
      yield return new JsonObject
      {
        ["name"] = $"Race: {race}",
        ["region"] = Name,
        ["sort-key"] = $"{WorldIndex}-1-{i + 1}",
        ["requires"] = IsStartingWorld ? null : $"|{race} Race Key|"
      };
    }

    if (!IsStartingWorld)
    {
      foreach ((int i, string str) in Enumerable.Index(["", "Second", "Third", "Fourth", "Fifth"]))
      {
        List<JsonNode> cats = [];
        if (IsFinalWorld) cats.Add($"{Name} Boss Checks");
        if (i > 0) cats.Add($"{str} Boss Checks");
        yield return new JsonObject
        {
          ["name"] = $"Boss: {BossRaceName} (Check {i + 1})",
          ["requires"] = $"{{OptionCount({Name} Boss Key, {(IsFinalWorld ? "boss" : "xalax")}_keys_needed)}}",
          ["category"] = new JsonArray([.. cats]),
          ["region"] = Name,
          ["sort-key"] = $"{WorldIndex}-2-{i + 1}"
        };
      }
    }

    yield return new JsonObject
    {
      ["name"] = $"Bonus Game: {Name} Easy",
      ["category"] = new JsonArray(["Minigames"]),
      ["region"] = Name,
      ["sort-key"] = $"{WorldIndex}-3-1",
      ["requires"] = IsStartingWorld ? null : $"|{Name} Exploration Key|"
    };

    yield return new JsonObject
    {
      ["name"] = $"Bonus Game: {Name} Hard",
      ["category"] = new JsonArray(["Minigames"]),
      ["requires"] = $"|{Name} Hard Bonus Game Key|{(IsStartingWorld ? "" : $" and |{Name} Exploration Key|")}",
      ["region"] = Name,
      ["sort-key"] = $"{WorldIndex}-3-2"
    };

    foreach ((int i, string brick) in GoldenBrickNames.Index())
    {
      yield return new JsonObject
      {
        ["name"] = $"Golden Brick: {brick}",
        ["requires"] = IsStartingWorld ? null : $"|{Name} Exploration Key|",
        ["region"] = Name,
        ["sort-key"] = $"{WorldIndex}-3-{i + 3}"
      };
    }

    foreach ((int i, string chr) in NPCNames.Index())
    {
      yield return new JsonObject
      {
        ["name"] = $"NPC: {chr}",
        ["category"] = new JsonArray(["Talksanity"]),
        ["sort-key"] = $"{WorldIndex}-4-{i + 1}",
        ["requires"] = IsStartingWorld ? null : $"|{Name} Exploration Key|"
      };
    }

    if (NPCBossName != null)
      yield return new JsonObject
      {
        ["name"] = $"NPC: {NPCBossName}",
        ["requires"] = $"{{OptionCount({Name} Boss Key, {(IsFinalWorld ? "boss" : "xalax")}_keys_needed)}}",
        ["category"] = new JsonArray(["Talksanity"]),
        ["sort-key"] = $"{WorldIndex}-4-{NPCNames.Length + 1}"
      };
  }
}
