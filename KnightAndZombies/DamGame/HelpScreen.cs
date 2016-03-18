using System;

namespace DamGame
{
    class HelpScreen
    {
        private Font font18;
        private bool finished;

        public HelpScreen()
        {
            font18 = new Font("data/Joystix.ttf", 18);
        }

        public void Run()
        {
            finished = false;

            Image introBackground = new Image("data/help.png");
            Hardware.ClearScreen();
            Hardware.DrawHiddenImage(introBackground, 0, 0);
            Hardware.WriteHiddenText("You play pressing the following buttons:",
                180, 80,
                0xEE, 0xEE, 0xEE,
                font18);
            Hardware.WriteHiddenText("Right arrow to move RIGHT >",
                400, 150,
                0xB0, 0xB0, 0xB0,
                font18);
            Hardware.WriteHiddenText("Left arrow to move LEFT <",
                400, 230,
                0xB0, 0xB0, 0xB0,
                font18);
            Hardware.WriteHiddenText("Press right arrow + up arrow to JUMP RIGHT",
                250, 300,
                0xB0, 0xB0, 0xB0,
                font18);
            Hardware.WriteHiddenText("Press left arrow + up arrow to JUMP LEFT",
                250, 390,
                0xB0, 0xB0, 0xB0,
                font18);
            Hardware.WriteHiddenText("Press 'F' key to launch a sword",
                370, 500,
                0xB0, 0xB0, 0xB0,
                font18);
            Hardware.WriteHiddenText("Press up arrow to climb stairs",
                380, 640,
                0xB0, 0xB0, 0xB0,
                font18); 
            Hardware.ShowHiddenScreen();

            do
            {
                Hardware.Pause(40); // Not to use a 100% CPU for nothing
                if (Hardware.KeyPressed(Hardware.KEY_ESC))
                {
                    finished = true;
                    do { } while (Hardware.KeyPressed(Hardware.KEY_ESC));
                }
            }
            while (!finished);
        }
    }
}
