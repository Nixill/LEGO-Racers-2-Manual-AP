from typing import Optional, Any, Union
from BaseClasses import MultiWorld, Item, Location

# just copying these from ..Helpers to avoid circular imports
def is_option_enabled(multiworld: MultiWorld, player: int, name: str) -> bool:
    return get_option_value(multiworld, player, name) > 0

def get_option_value(multiworld: MultiWorld, player: int, name: str) -> Union[int, dict]:
    option = getattr(multiworld.worlds[player].options, name, None)
    if option is None:
        return 0

    return option.value

# Use this if you want to override the default behavior of is_option_enabled
# Return True to enable the category, False to disable it, or None to use the default behavior
def before_is_category_enabled(multiworld: MultiWorld, player: int, category_name: str) -> Optional[bool]:
    if category_name == "Second Boss Checks" and get_option_value(multiworld, player, "boss_check_count") < 2: return False
    if category_name == "Third Boss Checks" and get_option_value(multiworld, player, "boss_check_count") < 3: return False
    if category_name == "Fourth Boss Checks" and get_option_value(multiworld, player, "boss_check_count") < 4: return False
    if category_name == "Fifth Boss Checks" and get_option_value(multiworld, player, "boss_check_count") < 5: return False
    if category_name == "Xalax Boss Checks" and get_option_value(multiworld, player, "goal_condition") == 0: return False
    return None

# Use this if you want to override the default behavior of is_option_enabled
# Return True to enable the item, False to disable it, or None to use the default behavior
def before_is_item_enabled(multiworld: MultiWorld, player: int, item:  dict[str, Any]) -> Optional[bool]:
    return None

# Use this if you want to override the default behavior of is_option_enabled
# Return True to enable the location, False to disable it, or None to use the default behavior
def before_is_location_enabled(multiworld: MultiWorld, player: int, location:  dict[str, Any]) -> Optional[bool]:
    return None
