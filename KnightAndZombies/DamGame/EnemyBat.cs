using System;

namespace DamGame
{
    class EnemyBat : Enemy
    {
        public EnemyBat(int newX, int newY) : base(newX, newY)
        {
            LoadSequence(RIGHT, new string[]
                { "data/batRight1.png","data/batRight2.png",
                    "data/batRight3.png","data/batRight4.png"});
            LoadSequence(LEFT, new string[]
                { "data/batLeft1.png","data/batLeft2.png",
                    "data/batLeft3.png","data/batLeft4.png" });

            x = newX;
            y = newY;
            xSpeed = 1;
            ySpeed = 1;
            width = 22;
            height = 32;
            stepsTillNextFrame = 6;
        }
        public override void Move()//Edited with two if statements
        {
            if ((x > 1601 - width) || (x < 300))
                xSpeed = -xSpeed;
            x = (short)(x + xSpeed);

            if (xSpeed < 0)
                ChangeDirection(LEFT);
            else
                ChangeDirection(RIGHT);

            NextFrame();
        }
    }
}
