namespace DamGame
{
    class Enemy : Sprite
    {
        public Enemy(int newX, int newY)
        {
            LoadSequence(RIGHT, new string[] 
                { "data/ZombieRight1.png","data/ZombieRight2.png"
                ,"data/ZombieRight3.png" });
            LoadSequence(LEFT, new string[]
                { "data/ZombieLeft1.png","data/ZombieLeft2.png"
                ,"data/ZombieLeft3.png" });

            x = newX;
            y = newY;
            xSpeed = 1;
            ySpeed = 1;
            width = 44;
            height = 64;
            stepsTillNextFrame = 6;
        }

        public override void Move()//Edited with two if statements
        {
            if ((x > 1399 - width) || (x < 0))
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
