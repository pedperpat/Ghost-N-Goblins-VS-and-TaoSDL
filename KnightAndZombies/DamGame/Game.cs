// 06/05/2016 Fixed bug of demons score.

using System;
using System.Collections.Generic; //For queue of shoots

namespace DamGame
{
    class Game
    {
        //private List<Shoot>shoot;
        private Font font18;
        private Player player;
        private Enemy[] enemies;
        private EnemyBat[] bats;
        private EnemyDemon[] demons;
        private EnemyOgre[] ogres;
        private EnemyBird[] birds;
        private EnemyBoss[] bosses;
        private EnemyRedFly[] redFlys;
        private Level currentLevel;
        private Shoot shoot;
        private bool finished;
        private int numEnemies;
        private int numOgres;
        private int numBats;
        private int numDemons;
        private int numBirds;
        private int numBosses;
        private int numRedFlys;
        private int numObjects;
        private int lifeCount = 3;
        private int score = 0;
        private int moved = 0;
        private int x;
        private int level;
        private int bossLives = 5;
        private int demonsLives = 2;
        private int redFlysLives = 3;
        private int ogreLives = 2;
        private PickObject[] objects;

        public Game()
        {
            font18 = new Font("data/Joystix.ttf", 18);
            player = new Player(this);

            level = 1;

            Random rnd = new Random();
            numEnemies = 2;
            numObjects = 2;
            numBats = 7;
            numDemons = 2;
            numOgres = 4;
            numBirds = 20;
            numRedFlys = 7;
            numBosses = 1;
            objects = new PickObject[numObjects];
            enemies = new Enemy[numEnemies];
            bats = new EnemyBat[numBats];
            demons = new EnemyDemon[numDemons];
            ogres = new EnemyOgre[numOgres];
            birds = new EnemyBird[numBirds];
            bosses = new EnemyBoss[numBosses];
            redFlys = new EnemyRedFly[numRedFlys];
            shoot = new Shoot();
            //shoot = new List<Shoot>();
            
            // Set speed and positions to each enemy
            for (int i = 0; i < numEnemies; i++)
            {
                enemies[i] = new Enemy(rnd.Next(500, 1400), rnd.Next(514,515));
                enemies[i].SetSpeed(rnd.Next(1, 5), 0);
            }

            for (int i = 0; i < numBats; i++)
            {
                bats[i] = new EnemyBat(rnd.Next(500, 1400), rnd.Next(30, 140));
                bats[i].SetSpeed(rnd.Next(1, 5), 0);
            }

            for (int i = 0; i < numOgres; i++)
            {
                ogres[i] = new EnemyOgre(rnd.Next(4000, 6400), rnd.Next(514, 515));
                ogres[i].SetSpeed(rnd.Next(1, 5), 0);
            }

            for (int i = 0; i < numDemons; i++)
            {
                demons[i] = new EnemyDemon(rnd.Next(2625, 3265), rnd.Next(514, 515));
                demons[i].SetSpeed(rnd.Next(1, 8), 0);
            }

            for (int i = 0; i < numBirds; i++)
            {
                birds[i] = new EnemyBird(rnd.Next(2000, 6400), rnd.Next(30, 180));
                birds[i].SetSpeed(rnd.Next(1, 8), 0);
            }

            for (int i = 0; i < numBosses; i++)
            {
                bosses[i] = new EnemyBoss(rnd.Next(6793, 6795), rnd.Next(334, 337));
            }

            for (int i = 0; i < numRedFlys; i++)
            {
                redFlys[i] = new EnemyRedFly(rnd.Next(6450, 6900), rnd.Next(30, 210));
                redFlys[i].SetSpeed(rnd.Next(6, 10), 0);
            }


            // Draw pickable objects at the background
            for (int j = 0; j < numObjects; j++)
            {
                objects[j] = new PickObject(rnd.Next(100, 501), rnd.Next(544, 547));
            }

            currentLevel = new Level();
            finished = false;
        }

        // Update screen
        public void DrawElements()
        {
            Hardware.ClearScreen();

            currentLevel.DrawOnHiddenScreen();
            Hardware.WriteHiddenText("Score: " +score,
                (short)(40+player.GetX()), 10,
                0xCC, 0xCC, 0xCC,
                font18);
            
           Hardware.WriteHiddenText("Lifes: " + lifeCount,
                (short)(400+player.GetX()), 10,
                0xFF, 0x00, 0x00,
                font18);

            player.DrawOnHiddenScreen();
            shoot.DrawOnHiddenScreen(); // Only for standard one by one shot method.

            //for (int i = 0; i < shoot.Count; i++) // Method for various shoots using lists.
            //{
            //    shoot[i].DrawOnHiddenScreen();
            //}

            for (int i = 0; i < numEnemies; i++)
                enemies[i].DrawOnHiddenScreen();

            for (int i = 0; i < numBats; i++)
                bats[i].DrawOnHiddenScreen();

            for (int i = 0; i < numDemons; i++)
                demons[i].DrawOnHiddenScreen();

            for (int i = 0; i < numOgres; i++)
                ogres[i].DrawOnHiddenScreen();

            for (int i = 0; i < numBirds; i++)
                birds[i].DrawOnHiddenScreen();

            for (int i = 0; i < numRedFlys; i++)
                redFlys[i].DrawOnHiddenScreen();

            for (int i = 0; i < numBosses; i++)
                bosses[i].DrawOnHiddenScreen();

            for (int i = 0; i < numObjects; i++)
                objects[i].DrawOnHiddenScreen();

            Hardware.ShowHiddenScreen();
        }

        // Check input by the user
        public void CheckKeys()
        {
            if (Hardware.KeyPressed(Hardware.KEY_UP))
            {
                if (Hardware.KeyPressed(Hardware.KEY_RIGHT))
                    player.JumpRight();
                else
                if (Hardware.KeyPressed(Hardware.KEY_LEFT))
                    player.JumpLeft();
                else
                    player.Jump();
            }

            else if (Hardware.KeyPressed(Hardware.KEY_RIGHT))
                player.MoveRight();

            else if (Hardware.KeyPressed(Hardware.KEY_LEFT))
                player.MoveLeft();

            //if (Hardware.KeyPressed(Hardware.KEY_DOWN))
            //    player.MoveDown();

            if (Hardware.KeyPressed(Hardware.KEY_F) && !(shoot.IsVisible()))
            {
                if (player.GetCurrentDirection() == Sprite.RIGHT)
                    shoot.Appear(player.GetX() +20, player.GetY() + 20, 20);
                //shoot.Enqueue(player.GetX() + 20, player.GetY() + 20, 20);
                else
                    shoot.Appear(player.GetX() - 60, player.GetY() + 20, -20);
                //shoot.Enqueue(player.GetX() + 20, player.GetY() + 20, 20);
                //player.LoadImage("data/ArthurTrowRight.png");
            }

            // Shoot each time key F is pressed
            //if (Hardware.KeyPressed(Hardware.KEY_F))
            //{
            //     // Make the spear appears
            //        shoot.Add(new Shoot());
            //        shoot[shoot.Count - 1].Appear(player.GetX(),player.GetY(),player.GetSpeedX());
            //}

            if (Hardware.KeyPressed(Hardware.KEY_ESC))
                finished = true;

            // Hacks, move directly to the boss
            //if (Hardware.KeyPressed(Hardware.KEY_H))
            //{
            //player.SetX(6300);
            //player.SetY(400);
            //Hardware.ScrollTo(6300,0);
            //}   
        }


        // Move enemies, animate background, etc 
        public void MoveElements()
        {
            player.Move();
            shoot.Move(); // Old method for move 1 single shoot at a time.

            //for (int i = 0; i < shoot.Count; i++)
            //{
            //    if (shoot[i].IsVisible())
            //    {
            //        shoot[i].Move();
            //    }
            //}

            for (int i = 0; i < numEnemies; i++)
                enemies[i].Move();
            for (int i = 0; i < numBats; i++)
                bats[i].Move();
            for (int i = 0; i < numOgres; i++)
                ogres[i].Move();
            for (int i = 0; i < numDemons; i++)
                demons[i].Move();
            for (int i = 0; i < numBirds; i++)
                birds[i].Move();
            for (int i = 0; i < numRedFlys; i++)
                redFlys[i].Move();
        }


        // Check collisions and apply game logic
        public void CheckCollisions()
        {
            // Check if there's a ladder collision 
            //player.CheckSituation(currentLevel.IsValidMove(player.GetX(), player.GetY())[0],
            //                    currentLevel.IsValidMove(player.GetX(), player.GetY())[1],
            //                    currentLevel.IsValidMove(player.GetX(), player.GetY())[2]);

            //if (player.GetX() + player.GetWidth() >= currentLevel.GetMaxX() &&
            //        level < 3)
            //{
            //    level++;
            //    player.SetX(currentLevel.GetMinX() + 5);
            //    currentLevel.SetLevel(level);
            //}

            //for (int i = 0; i < enemies.Length; i++)
            //{
            //    for (int j = 0; j < shoot.Count; j++)
            //    {
            //        if (shoot[j].CollisionsWith(enemies[i]))
            //        {
            //            enemies[i].Hide();
            //        }

            //        if (player.CollisionsWith(shoot[j]))
            //        {
            //            shoot[j].Hide();
            //            score += 100;
            //        }

            //        if (!shoot[j].IsVisible())
            //            shoot.Remove(shoot[j]);
            //    }
            //}
            for (int i = 0; i < numEnemies; i++)
            {
                if (enemies[i].CollisionsWith(player))
                {
                    lifeCount--;
                    player.Restart();
                    Hardware.ResetScroll();
                    if (lifeCount < 0)
                        finished = true;
                }

                 // Old method to detect collision with enemies
                if (shoot.CollisionsWith(enemies[i]))
                {
                    enemies[i].Hide();
                    shoot.Hide();
                    score += 100;
                }
            }

            for (int i = 0; i < numDemons; i++)
            {
                if (demons[i].CollisionsWith(player))
                {
                    lifeCount--;
                    player.Restart();
                    Hardware.ResetScroll();
                    if (lifeCount < 0)
                        finished = true;
                }
                if (shoot.CollisionsWith(demons[i]))
                {
                    shoot.Hide();
                    if(demonsLives == 0)
                        demons[i].Hide();
                }
            }

            for (int i = 0; i < numOgres; i++)
            {
                if (ogres[i].CollisionsWith(player))
                {
                    lifeCount--;
                    player.Restart();
                    Hardware.ResetScroll();
                    if (lifeCount < 0)
                        finished = true;
                }
                if (shoot.CollisionsWith(ogres[i]))
                {
                    ogreLives--;
                    shoot.Hide();
                    score += 400;
                    if(ogreLives == 0)
                    {
                        ogres[i].Hide();
                        ogreLives = 2;
                    }
                }
            }

            for (int i = 0; i < numBats; i++)
            {
                if (bats[i].CollisionsWith(player))
                {
                    lifeCount--;
                    player.Restart();
                    Hardware.ResetScroll();
                    if (lifeCount < 0)
                        finished = true;
                }
                if (shoot.CollisionsWith(bats[i]))
                {
                    bats[i].Hide();
                    shoot.Hide();
                    score += 200;
                }
             }

            for (int i = 0; i < numBirds; i++)
            {
                if (birds[i].CollisionsWith(player))
                {
                    lifeCount--;
                    player.Restart();
                    Hardware.ResetScroll();
                    if (lifeCount < 0)
                        finished = true;
                }
                if (shoot.CollisionsWith(birds[i]))
                {
                    birds[i].Hide();
                    shoot.Hide();
                    score += 200;
                }
            }

            for (int i = 0; i < numRedFlys; i++)
            {
                if (redFlys[i].CollisionsWith(player))
                {
                    lifeCount--;
                    player.Restart();
                    Hardware.ResetScroll();
                    if (lifeCount < 0)
                        finished = true;
                }
                if (shoot.CollisionsWith(redFlys[i]))
                {
                    redFlysLives--;
                    shoot.Hide();
                    score += 500;
                    if(redFlysLives == 0)
                        redFlys[i].Hide();

                }
            }

            for (int i = 0; i < numBosses; i++)
            {
                if (bosses[i].CollisionsWith(player))
                {
                    lifeCount--;
                    player.Restart();
                    Hardware.ResetScroll();
                    if (lifeCount < 0)
                        finished = true;
                }
                if (shoot.CollisionsWith(bosses[i]))
                {
                    bossLives--;
                    shoot.Hide();
                    score += 1000;
                    if(bossLives == 0)
                        bosses[i].Hide();

                }
            }

            for (int i = 0; i < numObjects; i++)
                if (objects[i].CollisionsWith(player))
                {
                    score += 100;
                    objects[i].Hide();
                }
        }

        public void PauseTillNextFrame()
        {
            // Pause till next frame (20 ms = 50 fps)
            Hardware.Pause(20);
        }

        public void Run()
        {
            // Game Loop
            while (!finished)
            {
                DrawElements();
                CheckKeys();
                MoveElements();
                //MoveScroll(); //Auto scrolling the map without playing the game.
                CheckCollisions();
                PauseTillNextFrame();
            }
        }
        
        public void MoveScroll()
        {
                int moved = player.GetX() - x / 2;
                Hardware.ScrollHorizontally((short)-moved);
                x = player.GetX();
        }

        public bool IsValidMove(int xMin, int yMin, int xMax, int yMax)
        {
            return currentLevel.IsValidMove(xMin, yMin, xMax, yMax);
        }

        public Level GetLevel()
        {
            return currentLevel;
        }
    }
}