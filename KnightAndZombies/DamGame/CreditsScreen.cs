namespace DamGame
{
    class CreditsScreen
    {
        private Font font18;
        private bool finished;

        public CreditsScreen()
        {
            font18 = new Font("data/Joystix.ttf", 18);
        }

        public void Run()
        {
            finished = false;

            Image introBackground = new Image("data/credits.png");
            Hardware.ClearScreen();
            Hardware.DrawHiddenImage(introBackground, 0, 0);
            Hardware.WriteHiddenText("Spriter - Pedro Antonio Pérez Paterna and some google sources",
                360, 720,
                0xEE, 0xEE, 0xEE,
                font18);
            Hardware.WriteHiddenText("Programmed by - Pedro Antonio Pérez Paterna and Nacho's skeleton",
                265, 740,
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
