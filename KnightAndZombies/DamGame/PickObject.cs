using System;

namespace DamGame
{
    class PickObject : Sprite
    {
        public PickObject(int newX, int newY)
        {
            LoadImage("data/money.png");
            x = newX;
            y = newY;
            visible = true;
        }
    }
}
