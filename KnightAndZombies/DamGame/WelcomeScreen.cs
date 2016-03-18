namespace DamGame
{
    class WelcomeScreen
    {
        public enum options { Play, Help, Credits, Quit };
        private options optionChosen;

        public void Run()
        {
            Font font18 = new Font("data/Joystix.ttf", 18);
            Image player = new Image("data/welcomeScreen.png");

            bool validOptionChosen = false;

            do
            {
                Hardware.ClearScreen();
                Hardware.WriteHiddenText("P to Play,C to credits,H to help, Q to Quit",
                    40, 10,
                    0xCC, 0xCC, 0xCC,
                    font18);
                Hardware.DrawHiddenImage(player, 0, 30);
                Hardware.ShowHiddenScreen();
            
                if (Hardware.KeyPressed(Hardware.KEY_P))
                {
                    validOptionChosen = true;
                    optionChosen = options.Play;
                }
                if (Hardware.KeyPressed(Hardware.KEY_Q))
                {
                    validOptionChosen = true;
                    optionChosen = options.Quit;
                }
                if (Hardware.KeyPressed(Hardware.KEY_C))
                {
                    validOptionChosen = true;
                    optionChosen = options.Credits;
                }
                if (Hardware.KeyPressed(Hardware.KEY_H))
                {
                    validOptionChosen = true;
                    optionChosen = options.Help;
                }
                Hardware.Pause(50);
            }
            while (!validOptionChosen);
        }

        public options GetOptionChosen()
        {
            return optionChosen;
        }
    }
}
