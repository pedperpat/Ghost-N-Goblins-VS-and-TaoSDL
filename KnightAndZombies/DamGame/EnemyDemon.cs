using System;

namespace DamGame
{
    class EnemyDemon : Enemy
    {
        public EnemyDemon(int newX, int newY) : base(newX, newY)
        {
            LoadSequence(RIGHT, new string[]
                { "data/demonRight1.png","data/demonRight2.png",
                    "data/demonRight3.png" });
            LoadSequence(LEFT, new string[]
                { "data/demonLeft1.png","data/demonLeft2.png",
                    "data/demonLeft3.png" });

            x = newX;
            y = newY;
            xSpeed = 1;
            ySpeed = 1;
            width = 50;
            height = 67;
            stepsTillNextFrame = 6;
        }
        public override void Move()//Edited with two if statements
        {
            if ((x > 3265 - width) || (x < 2625))
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
