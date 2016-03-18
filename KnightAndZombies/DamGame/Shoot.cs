using System;

namespace DamGame
{
    class Shoot : Sprite
    {
        int shootDistance;
        public Shoot()
        {
            width = 64;
            height = 17;
            visible = false;
            LoadImage("data\\SpearRight.png");
        }

        public void Appear(int xPos, int yPos, int speed)
        {
            shootDistance = 1000;
            visible = true;
            x = xPos;
            y = yPos;
            xSpeed = speed;
            ySpeed = 0;
        }

        public override void Move()
        {
            x += xSpeed;

            if (xSpeed != 0)
            {
                if (shootDistance > 0)
                    shootDistance--;
                else
                {
                    xSpeed = 0;
                }
            }
        }
    }
}
