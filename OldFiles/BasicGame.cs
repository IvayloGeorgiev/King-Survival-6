using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvivalGame
{
    class BasicGame
    {
        protected static int[,] edges = 
        {
            { 2, 4 }, { 2, 18 }, { 9, 4 }, { 9, 18 }           
        };

        protected static int counter = 0;

        protected static string[] validKingInputs = { "KUL", "KUR", "KDL", "KDR" };

        protected static string[] validAPawnInputs = { "ADL", "ADR" };

        protected static string[] validBPawnInputs = { "BDL", "BDR" };

        protected static string[] validCPawnInputs = { "CDL", "CDR" };

        protected static string[] validDPawnInputs = { "DDL", "DDR" };

        protected static bool IsInsideBoard(int[] positionCoodinates)        // Is the position valid
        {
            const int topEdge = 2;
            const int bottomEdge = 9;
            const int leftEdge = 4;
            const int rightEdge = 18; //TODO: Move constants to parrent class.

            int positionRow = positionCoodinates[0];                    // change name positionRow
            bool isRowInBoard = ((positionRow >= topEdge) && (positionRow <= bottomEdge)); // change
            int positionCol = positionCoodinates[1];                    // change name positionCol
            bool isColInBoard = (positionCol >= leftEdge) && (positionCol <= rightEdge);   //change 
            bool isInBoard = isRowInBoard && isColInBoard;              // new bool isInBoard
            return isInBoard;
        }

        protected static bool IsValidCommand(string checkedString)       // Is the command valid
        {
            string[] validCommands = new string[4];
            bool isKingTurn = (counter % 2 == 0);

            if (isKingTurn)		// At the odd turns the player moves the King
            {
                validCommands = validKingInputs;                
            }
            else
            {
                char startLetter = checkedString[0];
                //int[] equal = new int[2];
                //bool hasAnEqual = false;
                switch (startLetter)
                {
                    case 'A':
                        validCommands = validAPawnInputs;
                        break;
                    //for (int i = 0; i < validAPawnInputs.Length; i++)
                    //{
                    //    string reference = validAPawnInputs[i];
                    //    int result = checkedString.CompareTo(reference);
                    //    if (result != 0)
                    //    {
                    //        equal[i] = 0;
                    //    }
                    //    else
                    //    {
                    //        equal[i] = 1;
                    //    }
                    //}
                    //for (int i = 0; i < 2; i++)
                    //{
                    //    if (equal[i] == 1)
                    //    {
                    //        hasAnEqual = true;
                    //    }
                    //}
                    //if (!hasAnEqual)
                    //{
                    //    Console.WriteLine("Invalid command name!");
                    //}
                    //return hasAnEqual;

                    case 'B':
                        validCommands = validBPawnInputs;
                        break;
                    //for (int i = 0; i < validBPawnInputs.Length; i++)
                    //{
                    //    string reference = validBPawnInputs[i];
                    //    int result = checkedString.CompareTo(reference);
                    //    if (result != 0)
                    //    {
                    //        equal[i] = 0;
                    //    }
                    //    else
                    //    {
                    //        equal[i] = 1;
                    //    }
                    //}
                    //for (int i = 0; i < 2; i++)
                    //{
                    //    if (equal[i] == 1)
                    //    {
                    //        hasAnEqual = true;
                    //    }
                    //}
                    //if (!hasAnEqual)
                    //{
                    //    Console.WriteLine("Invalid command name!");
                    //}
                    //return hasAnEqual;
                    case 'C':
                        validCommands = validCPawnInputs;
                        break;
                    //for (int i = 0; i < validCPawnInputs.Length; i++)
                    //{
                    //    string reference = validCPawnInputs[i];
                    //    int result = checkedString.CompareTo(reference);
                    //    if (result != 0)
                    //    {
                    //        equal[i] = 0;
                    //    }
                    //    else
                    //    {
                    //        equal[i] = 1;
                    //    }
                    //}
                    //for (int i = 0; i < 2; i++)
                    //{
                    //    if (equal[i] == 1)
                    //    {
                    //        hasAnEqual = true;
                    //    }
                    //}
                    //if (!hasAnEqual)
                    //{
                    //    Console.WriteLine("Invalid command name!");
                    //}
                    //return hasAnEqual;

                    case 'D':
                        validCommands = validDPawnInputs;
                        break;
                    //for (int i = 0; i < validDPawnInputs.Length; i++)
                    //{
                    //    string reference = validDPawnInputs[i];
                    //    int result = checkedString.CompareTo(reference);
                    //    if (result != 0)
                    //    {
                    //        equal[i] = 0;
                    //    }
                    //    else
                    //    {
                    //        equal[i] = 1;
                    //    }
                    //}
                    //for (int i = 0; i < 2; i++)
                    //{
                    //    if (equal[i] == 1)
                    //    {
                    //        hasAnEqual = true;
                    //    }
                    //}
                    //if (!hasAnEqual)
                    //{
                    //    Console.WriteLine("Invalid command name!");
                    //}
                    //return hasAnEqual;

                    default:
                        //Console.WriteLine("Invalid command name!");     ? print 
                        return false;
                        break;
                }
            }
            //return true;
            bool isValidCommand = CheckCommand(checkedString, validCommands);
            return isValidCommand;
        }

        private static bool CheckCommand(string checkedString, string[] validCommands)
        {
            bool isValidCommand = false;            // rename hasAnEqual to isValidCommand
            for (int i = 0; i < validCommands.Length; i++)    // extract method valid command
            {
                //string validCommand = validKingInputs[i]; 
                if (checkedString == validCommands[i])
                {
                    isValidCommand = true;
                }
                //int result = checkedString.CompareTo(validCommand);
                //if (result != 0)
                //{
                //    equal[i] = 0;
                //}
                //else
                //{
                //    equal[i] = 1;
                //}
            }
            //for (int i = 0; i < 4; i++)
            //{
            //    if (equal[i] == 1)
            //    {
            //        hasAnEqual = true;
            //    }
            //}
            //if (!hasAnEqual)
            //{
            //    Console.WriteLine("Invalid command name!");   // print message?
            //}
            return isValidCommand;
        }
    }
}
