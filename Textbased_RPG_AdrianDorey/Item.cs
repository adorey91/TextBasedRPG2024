using TextBasedRPG2024;

namespace Textbased_RPG_AdrianDorey
{
    internal class Item : GameObject
    {
        public bool collected;
        public char moneyChar = '$';
        public char potionChar = 'H';

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