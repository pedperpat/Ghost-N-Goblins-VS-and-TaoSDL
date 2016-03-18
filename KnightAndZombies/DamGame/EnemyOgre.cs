using System;

namespace DamGame
{
    class EnemyOgre : Enemy
    {
        public EnemyOgre(int newX, int newY) : base(newX, newY)
        {
            LoadSequence(RIGHT, new string[]
                { "data/ogreRight2.png",
                  "data/ogreRight3.png" });
            LoadSequence(LEFT, new string[]
                { "data/ogreLeft2.png",
                  "data/ogreLeft3.png" });

            x = newX;
            y = newY;
            xSpeed = 1;
            ySpeed = 1;
            width = 67;
            height = 50;
            stepsTillNextFrame = 6;
        }
        public override void Move()//Edited with two if statements
        {
            if ((x > 6400 - width) || (x < 4000))
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
