# LEGO Racers 2 Manual APWorld
This is an APWorld for LEGO Racers 2!

# Before the run
Before the run, you will want to set up a save file that has completed all races (The Grand Finale is optional) but has not collected any on-the-ground Golden Bricks or opened any bonus games. Such a save file is included within this repository, but you may wish to make your own so that you have your name and character and car choices on it.

## Tip 1!
You can find scripts in this repository that will assist with the copying of save files. Currently, they're in `.cs` form, but I'll make a `.ps` form at some point...

## Tip 2!
Once you create the save, find the `GameSave` file in the folder `%USERPROFILE%\Documents\Games\LEGO Racers 2\Saved Games`, and make a copy of it as a backup. (Or, if you use the save included in this repository, overwrite the `GameSave` file with it.)

## Note!
If you use a save file that has completed bonus minigames, the randomizer can still be enjoyed. However, you must not have collected any on-the-ground golden bricks.

# How the run works
When you first load into Sandy Bay, you will have access only to Sandy Bay's races, its on-the-ground Golden Bricks, and the easy bonus game. All else is locked.

You may perform checks by:
- Winning any unlocked race, except The Grand Finale
- Winning any unlocked bonus game
- Collecting an on-the-ground golden brick, in a world where exploration is unlocked

The following are unlocked by checks:
- Non-boss races (except for Sandy Bay's, which are unlocked from the start)
- Pieces of Boss Keys - four spawn per archipelago, and it takes three of those to unlock a Boss Race
- The ability to explore a world (except for Sandy Bay, which is unlocked from the start) to collect its on-the-ground golden bricks and easy bonus games
- The ability to play a world's hard bonus game (*includes* Sandy Bay; it is *not* unlocked from the start)

Outside of Sandy Bay, you must unlock *both* exploration *and* hard bonus game to play that world's hard bonus game.

## On-the-ground Golden Bricks
Golden bricks found on the ground are specifically named in this world. For a listing of which golden brick matches which name, you may check [this document](docs/golden-bricks.md).

## Victory conditions
There are several possible victory conditions. While the manual APworld only natively supports a check at the end of The Grand Finale, you could also limit yourself to a more restricted end condition by not performing that check until you meet one of the following conditions:
1. You have completed the other boss races.
2. You have completed all other races.
3. You have performed all checks in the game.

## Death Link
If playing with death link:
- Any time you *receive* a death link, you must reset the race or bonus game you're in. (If you're not in a race or bonus game at that time, lucky you, the death link has no effect!) If you don't notice until you win the race or bonus game, you must still reset when you do notice, and that attempt is not counted even if you won (but a loss also does not count).
- Any time you lose a race or a bonus game, or reset for any reason (other than resets for receiving a death link), you must send a death link.

# Configuration
There is configuration added now, documentation pending...
