using System.IO;

namespace DamGame
{
    class Level
    {
        //StreamReader level =
        //    File.OpenText("levels.gnb");

        byte tileWidth, tileHeight;
        byte levelWidth, levelHeight;
        byte leftMargin, topMargin;
        string[][] levelDescription;
        int currentLevel;
        int maxX, minX;

        Image g1, g2, g3,
            corner,cornerRight,mountain,
            ladder,plantLeft,plantRight,
            platformLeft,platformRight,water,
            edgeRight1, edgeRight2, edgeLeft1, edgeLeft2,
            slimTree, treeLeafRight, treeLeafLeft,
            bigTreeRight,bigTreeLeft,treeBot,
            treeTop,candle,endScreen;

        public Level()
        {
            // Load map part
            //string levelLoaded = "";
            //string line = "";
            //do
            //{
            //    line = level.ReadLine();
            //    if ((line.StartsWith("\"")) && (line.EndsWith("\"")))
            //        levelLoaded = line;
            //}
            //while (line != null);
            //level.Close();
            //string[] levels;
            //levels = levelLoaded.Split(':');

            levelDescription = new string[3][];
            tileWidth = 64;
            tileHeight = 64;
            levelWidth = 110;
            levelHeight = 12;
            leftMargin = 0;
            topMargin = 0;

            minX = leftMargin;
            maxX = tileWidth * levelWidth + leftMargin;
            currentLevel = 0;

            //To use loaded levels from file
            //levelDescription[0] = levels[0];
            //levelDescription[1] = levelLoaded[1];
            //levelDescription[2] = levelLoaded[2];

            // To use specified levels that are not stored at a external file.
            levelDescription[0] = new string[12]
            {
                                                                                         
                "                                                                                                              ",
                "                                                                                                              ",
                "                         L                                             #                                      ",
                "       #       ¬¬        |      #              LL                                                             ",
                "           66666666666   B                 L   +*==                                                           ",
                "       47222222222222227228          #   --|   +*                               #               L      #     #",
                "      4575555555555555575558               |=  +*=       #           #                 #        |=            ",
                "     455755555555555555755558             -|  -+*               ¬¬¬      4228              ¬¬  -|        4228 ",
                "3   45557555555555555557555558             B   BB           6666666666  455558    66666666666   B       455558",
                "222222222222222222222222222222222ZX  %/2222222222222  PT  2222222222222222222222222222222222222222222222222222",
                "111111111111111111111111111111111wwwwww1111111111111wwwwww1111111111111111111111111111111111111111111111111111",
                "111111111111111111111111111111111wwwwww1111111111111wwwwww1111111111111111111111111111111111111111111111111111",
            
            };

            levelDescription[1] = new string[12]
            {

                "                                                                                                              ",
                "                                                                                                              ",
                "                         L                                             #                                      ",
                "                         |      #              LL                                                             ",
                "                         B                 L   +*==                                                           ",
                "       47222222222222227228          #   --|   +*                               #               L             ",
                "      4575555555555555575558               |=  +*=       #           #                 #        |=            ",
                "     455755555555555555755558             -|  -+*               ¬¬¬      4228              ¬¬  -|        4228 ",
                "3   45557555555555555557555558             B   BB           6  6666 66  455558    666   66666   B       455558",
                "222222222222222222222222222222222ZX  %/2222222222222  PT  22222222222222222222   22222222222222222222222222222",
                "111111111111111111111111111111111wwwwww1111111111111wwwwww11111111111111111111www11111111111111111111111111111",
                "111111111111111111111111111111111wwwwww1111111111111wwwwww11111111111111111111www11111111111111111111111111111",

            };

            levelDescription[2] = new string[12]
            {

                "                                                                                                              ",
                "                                                                                                              ",
                "                                                                                                              ",
                "       #       ¬¬                                                                                             ",
                "           66666666666                                                                                        ",
                "       47222222222222227228                                                                                   ",
                "      4575555555555555575558                                                                                  ",
                "     455755555555555555755558                                   ¬¬¬      4228              ¬¬            4228 ",
                "3   45557555555555555557555558             B   BB           6666666666  455558    66666666666           455558",
                "222222222222222222222222222222222ZX  %/2222222222222  PT  2222222222222222222222222222222222222222222222222222",
                "111111111111111111111111111111111wwwwwwwwwwwwwwwwwwwwwwwww1111111111111111111111111111111111111111111111111111",
                "111111111111111111111111111111111wwwwwwwwwwwwwwwwwwwwwwwww1111111111111111111111111111111111111111111111111111",

            };

            g1 = new Image("data\\tierraBajo.png");
            g2 = new Image("data\\tierraArribaverde.png");
            g3 = new Image("data\\valla.png");
            plantRight = new Image("data\\plantRight.png");
            corner = new Image("data\\esquina.png");
            edgeLeft1 = new Image("data\\edgeRight1.png");
            edgeLeft2 = new Image("data\\edgeRight2.png");
            edgeRight1 = new Image("data\\edgeLeft.png");
            edgeRight2 = new Image("data\\edgeLeft1.png");
            cornerRight = new Image("data\\cornerRight.png");
            platformLeft = new Image("data\\platformLeft.png");
            platformRight = new Image("data\\platformRight.png");
            water = new Image("data\\water.png");
            candle = new Image("data\\candle.png");
            treeTop = new Image("data\\treeTop.png");
            mountain = new Image("data\\tierraBajo.png");
            bigTreeLeft = new Image("data\\bigTreeLeft.png");
            bigTreeRight= new Image("data\\bigTreeRight.png");
            ladder = new Image("data\\ladderTile.png");
            plantLeft = new Image("data\\plantLeft.png");
            treeLeafRight= new Image("data\\treeLeftLeaf.png");
            treeLeafLeft = new Image("data\\treeRightLeaf.png");
            slimTree = new Image("data\\treeSlim.png");
            treeBot = new Image("data\\treeBottom.png");
            endScreen = new Image("data\\welcomeScreen.png");

        }

        public void SetLevel(int level)
        {
            currentLevel = level;
        }
  
        public int GetMaxX()
        {
            return maxX;
        }
  
        public int GetMinX()
        {
            return minX;
        }

        public void DrawOnHiddenScreen()
        {
            for (int row = 0; row < levelHeight; row++)
                for (int col = 0; col < levelWidth; col++)
                {
                    int xPos = leftMargin + col * tileWidth;
                    int yPos = topMargin + row * tileHeight;
                    switch (levelDescription[currentLevel][row][col])
                    {
                        case '1': Hardware.DrawHiddenImage(g1, xPos, yPos); break;
                        case '2': Hardware.DrawHiddenImage(g2, xPos, yPos); break;
                        case '3': Hardware.DrawHiddenImage(g3, xPos, yPos); break;
                        case '4': Hardware.DrawHiddenImage(corner, xPos, yPos); break;
                        case '5': Hardware.DrawHiddenImage(mountain, xPos, yPos); break;
                        case '6': Hardware.DrawHiddenImage(g3, xPos, yPos); break;
                        case '7': Hardware.DrawHiddenImage(ladder, xPos, yPos); break;
                        case '8': Hardware.DrawHiddenImage(cornerRight, xPos, yPos); break;
                        case 'T': Hardware.DrawHiddenImage(platformRight, xPos, yPos); break;
                        case 'P': Hardware.DrawHiddenImage(platformLeft, xPos, yPos); break;
                        case 'w': Hardware.DrawHiddenImage(water, xPos, yPos); break;
                        case '+': Hardware.DrawHiddenImage(bigTreeLeft, xPos, yPos); break;
                        case '*': Hardware.DrawHiddenImage(bigTreeRight, xPos, yPos); break;
                        case '¬': Hardware.DrawHiddenImage(plantLeft, xPos, yPos); break;
                        case 'Z': Hardware.DrawHiddenImage(edgeLeft1, xPos, yPos); break;
                        case 'X': Hardware.DrawHiddenImage(edgeLeft2, xPos, yPos); break;
                        case '%': Hardware.DrawHiddenImage(edgeRight2, xPos, yPos); break;
                        case '/': Hardware.DrawHiddenImage(edgeRight1, xPos, yPos); break;
                        case '-': Hardware.DrawHiddenImage(treeLeafLeft, xPos, yPos); break;
                        case '=': Hardware.DrawHiddenImage(treeLeafRight, xPos, yPos); break;
                        case '|': Hardware.DrawHiddenImage(slimTree, xPos, yPos); break;
                        case 'B': Hardware.DrawHiddenImage(treeBot, xPos, yPos); break;
                        case 'L': Hardware.DrawHiddenImage(treeTop, xPos, yPos); break;
                        case '#': Hardware.DrawHiddenImage(candle, xPos, yPos); break;
                    }
                }
        }

        public bool IsValidMove(int xMin, int yMin, int xMax, int yMax)
        {
            for (int row = 0; row < levelHeight; row++)
                for (int col = 0; col < levelWidth; col++)
                {
                    char tileType = levelDescription[currentLevel][row][col];

                    if ((tileType == '4')
                            || (tileType == '5') || (tileType == ' ')
                            || (tileType == '3') || (tileType == '6')
                            || (tileType == '7') || (tileType == '8')
                            || (tileType == '|') || (tileType == '+')
                            || (tileType == '-') || (tileType == '=')
                            || (tileType == '*') || (tileType == '¬')
                            || (tileType == 'B') || (tileType == 'L')
                            || (tileType == '#'))
                        continue;

                    int xPos = leftMargin + col * tileWidth;
                    int yPos = topMargin + row * tileHeight;
                    int xLimit = leftMargin + (col + 1) * tileWidth;
                    int yLimit = topMargin + (row + 1) * tileHeight;

                    if (Sprite.CheckCollisions(
                            xMin, yMin, xMax, yMax,
                            xPos, yPos, xLimit, yLimit)) 
                        return false;
                }
            return true;
        }
    }
}
