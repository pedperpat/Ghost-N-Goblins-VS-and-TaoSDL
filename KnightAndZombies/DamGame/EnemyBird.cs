using System;

namespace DamGame
{
    class EnemyBird : Enemy
    {
        public EnemyBird(int newX, int newY) : base(newX, newY)
        {
            LoadSequence(RIGHT, new string[]
               { "data/birdR1.png",
                  "data/birdR2.png"});
            LoadSequence(LEFT, new string[]
                { "data/birdL1.png",
                  "data/birdL2.png"});

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
            if ((x > 6400 - width) || (x < 2000))
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
