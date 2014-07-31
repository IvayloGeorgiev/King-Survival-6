namespace KingSurvivalGame.BasicLogic
{
    using System;

    using KingSurvivalGame.Display;
    using KingSurvivalGame.Interfaces;

    public class KingSurvivalEngine
    {
        /// <summary>
        /// Constant holding the message to be displayed on the the display when an invalid command has been entered.
        /// </summary>
        private const string InvalidCommand = "Invalid command.";

        /// <summary>
        /// Field that holds the current implementation of a graphic display.
        /// </summary>
        private readonly IFigureDisplay display;

        /// <summary>
        /// Field that holds the current game turn.
        /// </summary>
        private Turn currentTurn;       

        public KingSurvivalEngine()
        {
            this.currentTurn = new KingTurn(this);            
            this.display = new FigureToDrawingDisplay();            
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
            this.DisplayGeneralInfo();
            while (this.currentTurn.FiguresCanMove() && !this.currentTurn.KingWon)
            {                
                string input = this.display.GetInputRequest();
                if (this.currentTurn.CheckCommandExists(input))
                {                    
                    bool commandSucceeded = this.currentTurn.ExecuteCommand(input);                    
                    if (!commandSucceeded)
                    {
                        this.display.ShowError("Cannot do this command right now.");
                    }
                    else
                    {
                        this.DisplayGeneralInfo();
                    }
                }
                else
                {
                    this.display.ShowError(InvalidCommand);
                    this.display.ShowMessage(this.currentTurn.GetStartTurnMessage());
                }
            }

            if (this.currentTurn.KingWon)
            {
                this.display.ShowError(string.Format("King won on turn {0}", this.currentTurn.TurnCount));
            }
            else 
            {
                this.display.ShowError(this.CurrentTurn.GetNoLiveFiguresMessage());
            }
        }

        /// <summary>
        /// Called to refresh the display after each succesfull move.
        /// </summary>
        private void DisplayGeneralInfo()
        {
            this.display.DrawFigures(this.currentTurn.GetFigures());
            this.display.ShowMessage(this.currentTurn.GetStartTurnMessage());
            this.display.ShowInfo(this.currentTurn.GetCommands());
        }
    }
}
