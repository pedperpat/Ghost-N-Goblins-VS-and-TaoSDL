using System;

namespace DamGame
{
    class EnemyRedFly : Enemy
    {
        public EnemyRedFly(int newX, int newY) : base(newX, newY)
        {
            LoadSequence(RIGHT, new string[]
               { "data/flyEvilRight1.png"});
            LoadSequence(LEFT, new string[]
                { "data/flyEvilLeft1.png"});

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
            if ((x > 6900 - width) || (x < 6450))
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
