using System;

namespace DamGame
{
    class EnemyBoss : Enemy
    {
        public EnemyBoss(int newX, int newY) : base(newX, newY)
        {
            LoadImage("data/bossLvl1.png");

            x = newX;
            y = newY;
            xSpeed = 1;
            ySpeed = 1;
            width = 112;
            height = 112;
            stepsTillNextFrame = 6;
        }
       /* public override void Move()//Edited with two if statements
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
        */
    }
}
