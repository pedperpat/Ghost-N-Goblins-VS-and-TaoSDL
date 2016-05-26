namespace DamGame
{
    class Player : Sprite
    {
        protected Game myGame;
        protected bool jumping, falling;
        protected int jumpXspeed;
        protected int jumpFrame;
        protected int[] jumpSteps =
        {
            -24, -24, -20, -20, -18, -16, -14, -10, -6, -6, -6, -5, -5, -4, -1, 0,
            0, 1, 4, 5, 5, 6, 6, 6, 10, 14, 16, 18, 20, 20, 24, 24
        };

        public Player(Game g)
        {
            LoadSequence(RIGHT,
                new string[] { "data/ArthurRight1.png", "data/ArthurRight2.png",
                "data/ArthurRight3.png","data/ArthurRight4.png","data/ArthurRight5.png" });
            LoadSequence(LEFT,
                new string[] { "data/ArthurLeft1.png","data/ArthurLeft2.png",
                "data/ArthurLeft3.png","data/ArthurLeft4.png","data/ArthurLeft5.png" });
            LoadSequence(UPLEFT,
                new string[] { "data/jumpLeft.png","data/jumpLeft2.png" });
            LoadSequence(UPRIGHT,
                new string[] { "data/jumpRight.png", "data/jumpRight2.png" });
            LoadSequence(UP,
               new string[] { "data/Ladder1.png", "data/Ladder2.png" });
            //LoadSequence(SHOOTLEFT,
            //   new string[] { "data\\SpearRight.png" });
            //LoadSequence(SHOOTRIGHT,
            //   new string[] { "data\\SpearRight.png" });
            ChangeDirection(LEFT);

            x = 50;
            y = 400;
            xSpeed = 4;
            ySpeed = 4;
            width = 42;
            height = 64;

            stepsTillNextFrame = 2;

            jumpXspeed = 0;
            jumping = false;
            jumpFrame = 0;
            falling = false;
            myGame = g;
        }

        public void MoveRight()
        {
            if (myGame.IsValidMove(x + xSpeed, y, x + width + xSpeed, y + height))
            {
                x += xSpeed;
                ChangeDirection(RIGHT);
                Hardware.ScrollHorizontally(-4);
                NextFrame();
            }
        }

        public void MoveLeft()
        {
            if (myGame.IsValidMove(x - xSpeed, y, x + width - xSpeed, y + height))
            {
                x -= xSpeed;
                ChangeDirection(LEFT);
                Hardware.ScrollHorizontally(4);
                NextFrame();
            }
        }

        public void MoveUp()
        {
            y -= ySpeed;
            Jump();
            // Ladder test
            //if (x > 50 && x < 100)
            //    ChangeDirection(UP);
            //else
            //{
            //    y -= ySpeed;
            //    Jump();
            //}
        }

        public void MoveDown()
        {
            // The player will not move down freely any longer
            // y += ySpeed;
            // TO DO: Check if there is a stair or way down
        }


        // Starts the jump sequence
        public void Jump()
        {
            if (jumping || falling)
                return;
            jumping = true;
            jumpXspeed = 0;
        }


        // Starts the jump sequence to the right
        public void JumpRight()
        {
            Jump();
            jumpXspeed = xSpeed;
            ChangeDirection(UPRIGHT);
        }


        // Starts the jump sequence to the left
        public void JumpLeft()
        {
            Jump();
            jumpXspeed = -xSpeed;
            ChangeDirection(UPLEFT);
        }


        // Sometimes the player must be animated, eg. jumping
        public override void Move()
        {
            // If the player is not jumping, it might need to fall down
            if (!jumping)
            {
                
                if (myGame.IsValidMove(
                    x, y + ySpeed, x + width, y + height + ySpeed))
                {
                    y += ySpeed;
                }
            }
            else
            // If jumping, it must go on with the sequence
            {
                currentFrame = 0; // static frame for the jump at this moment

                // Let's calculate the next positions
                short nextX = (short)(x + jumpXspeed);
                short nextY = (short)(y + jumpSteps[jumpFrame]);

                // If the player can still move, let's do it
                if (myGame.IsValidMove(
                    nextX, nextY + height - ySpeed,
                    nextX + width, nextY + height))
                {
                    x = nextX;
                    y = nextY;
                    NextFrame();
                }
                // If it cannot move, then it must fall
                else
                {
                    jumping = false;
                    jumpFrame = 0;
                }

                // And let's prepare the next frame, maybe with a different speed
                jumpFrame++;
                if (jumpFrame >= jumpSteps.Length)
                {
                    jumping = false;
                    jumpFrame = 0;
                }
            }
        }

        public void CheckSituation(bool platform, bool stairs, bool endStairs)
        {
            if ((!platform) && (!stairs) && (!endStairs))
            {
                ySpeed = 4;
                y += ySpeed;
            }

            if ((platform) && !((stairs) && (endStairs)))
            {
                ySpeed = 0;
                y = y;
            }

            if ((stairs) || (endStairs))
            {
                if (ySpeed != 10)
                {
                    ySpeed--;
                    if (ySpeed != 9)
                    {
                        y = y;
                    }
                }
            }

            if (y + height > 768)
            {
                y = 768 - height;
            }
        }
    }
}