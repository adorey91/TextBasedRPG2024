using TextBasedRPG2024;

namespace Textbased_RPG_AdrianDorey
{
    internal class Item : GameObject
    {
        public bool collected;
        public char itemChar = '$';

        public Item()
        {
            collected = false;
        }

        public void TryCollect(Player player)
        {
            if (pos.y == player.pos.y && pos.x == player.pos.x)
            {
                collected = true;
                // Optionally, you may want to perform additional actions when money is collected.
                // For example, updating the player's score or inventory.
            }
        }
    }
}