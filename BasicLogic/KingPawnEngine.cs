namespace KingSurvivalGame.BasicLogic
{
    using System;

    using KingSurvivalGame.Interfaces;
    using KingSurvivalGame.Display;

    public class KingPawnEngine
    {
        /// <summary>
        /// Constant holding the message to be displayed on the the display when an invalid command has been entered.
        /// </summary>
        private const string InvalidCommand = "Invalid command.";
        /// <summary>
        /// Field that holds the current implementation of a graphic display.
        /// </summary>
        private readonly IDisplay display;
        /// <summary>
        /// Field that holds the current game turn.
        /// </summary>
        private Turn currentTurn;       

        public KingPawnEngine()
        {
            this.currentTurn = new KingTurn(this);            
            this.display = new FigureToShapeDisplay();            
        }

        /// <summary>
        /// Gets or sets the value of the current turn execution logic.
        /// </summary>        
        public Turn CurrentTurn
        {
            get 
            { 
                return this.currentTurn; 
            }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Current turn should not be null.");
                }                                
                this.currentTurn = value; 
            }
        }

        /// <summary>
        /// The basic game loop. Every iteration requests an input from the display, checks if its a valid and currently executable (i.e. there are no figures blocking the move and the move is within the bounds of the board) and carries the command out.
        /// </summary>
        public void Run()
        {
            DisplayGeneralInfo();
            while (currentTurn.FiguresCanMove() && !currentTurn.KingWon)
            {
                string input = display.GetInputRequest();
                if (currentTurn.CheckCommandExists(input))
                {
                    bool commandSucceeded = currentTurn.ExecuteCommand(input);
                    DisplayGeneralInfo();
                    if (!commandSucceeded)
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
                display.ShowError(string.Format("King won on turn {0}", currentTurn.TurnCount));
            }
            else 
            {
                display.ShowError(CurrentTurn.GetNoLiveFiguresMessage());
            }
        }

        /// <summary>
        /// Called to refresh the display after each succesfull move.
        /// </summary>
        private void DisplayGeneralInfo()
        {
            display.DrawFigures(currentTurn.GetFigures());
            display.ShowMessage(currentTurn.GetStartTurnMessage());
            display.ShowInfo(currentTurn.GetCommands());
        }
    }
}
