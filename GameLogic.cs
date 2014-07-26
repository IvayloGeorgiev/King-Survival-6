namespace KingSurvivalGame
{
    using System;

    public class GameLogic
    {
        private const string InvalidCommand = "Invalid command.";
        private readonly IDisplay display;
        private Turn currentTurn;       

        public GameLogic()
        {
            this.currentTurn = new KingTurn(this);            
            this.display = new FigureToShapeDisplay();            
        }

        public Turn CurrentTurn
        {
            get { return this.currentTurn; }
            set { this.currentTurn = value; }
        }

        public void Run()
        {
            DisplayGeneralInfo();
            while (currentTurn.FiguresCanMove() && !currentTurn.KingWon)
            {
                string input = display.GetInputRequest();
                if (currentTurn.CheckCommandExists(input))
                {
                    bool commandFailed = !(currentTurn.ExecuteCommand(input));
                    DisplayGeneralInfo();
                    if (commandFailed)
                    {
                        display.ShowError("Cannot do this command right now.");
                    }
                }
                else
                {
                    display.ShowError(InvalidCommand);
                    display.ShowMessage(currentTurn.GetStartTurnMessage());
                }
            }
            if (currentTurn.KingWon)
            {
                display.ShowMessage(string.Format("King won on turn {0}", currentTurn.TurnCount));
            }
            else 
            {
                display.ShowMessage(CurrentTurn.GetEndGameMessage());
            }
        }

        private void DisplayGeneralInfo()
        {
            display.DrawFigures(currentTurn.GetFigures());
            display.ShowMessage(currentTurn.GetStartTurnMessage());
            display.ShowInfo(currentTurn.GetCommands());
        }
    }
}
