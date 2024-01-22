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

        public void TryCollect(int posX, int posY)
        {
            if (pos.y == posY && pos.x == posX)
            {
                collected = true;
            }
        }
    }
}