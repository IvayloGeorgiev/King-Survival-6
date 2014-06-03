using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvivalGame
{
    class Game : BasicGame
    {
        protected static char[,] field = 
        {
            { 'U', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'U', 'R' },
            { ' ', ' ', ' ', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', ' ', ' ', ' ' },
            { '0', ' ', '|', ' ', 'A', ' ', ' ', ' ', 'B', ' ', ' ', ' ', 'C', ' ', ' ', ' ', 'D', ' ', ' ', ' ', '|', ' ', '0' },
            { '1', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '1' },
            { '2', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '2' },
            { '3', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '3' },
            { '4', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '4' },
            { '5', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '5' },
            { '6', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '6' },
            { '7', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'K', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '7' },
            { ' ', ' ', '|', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '|', ' ', ' ' },
            { 'D', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'D', 'R' },
        };

        protected static int[,] posPaws = 
        {
            { 2, 4 }, { 2, 8 }, { 2, 12 }, { 2, 16 }
        };

        protected static int[] posKing = { 9, 10 };

        protected static bool[,] pMoves = 
        {
            { true, true }, { true, true }, { true, true }, { true, true }
        };

        protected static bool[] kMoves = { true, true, true, true };

        static int[] CheckNextPownPosition(int[] coordinates, char direction, char pawn)
        {
            int horizontalMoveDirection = direction == 'R' ? 2 : -2;
            int[] newCoordinates = { coordinates[0] + 1, coordinates[1] + horizontalMoveDirection };

            bool isTargetPositionEmpty = field[newCoordinates[0], newCoordinates[1]] == ' ';
            if (IsInsideBoard(newCoordinates) && isTargetPositionEmpty)//TODO:change method name proverka
            {
                field[newCoordinates[0], newCoordinates[1]] = field[coordinates[0], coordinates[1]];
                field[coordinates[0], coordinates[1]] = ' ';
                counter++;

                switch (pawn)
                {
                    case 'A': pMoves[0, 0] = true; pMoves[0, 1] = true; break;//TODO: pMoves name should be changes
                    case 'B': pMoves[1, 0] = true; pMoves[1, 1] = true; break;
                    case 'C': pMoves[2, 0] = true; pMoves[2, 1] = true; break;
                    case 'D': pMoves[3, 0] = true; pMoves[3, 1] = true; break;
                    default: Console.WriteLine("ERROR!"); break;
                }

                return newCoordinates;
            }
            else
            {
                bool allAreFalse = true;
                int moveDirection = direction == 'L' ? 0 : 1;
                switch (pawn)
                {
                    case 'A': pMoves[0, moveDirection] = false; break;
                    case 'B': pMoves[1, moveDirection] = false; break;
                    case 'C': pMoves[2, moveDirection] = false; break;
                    case 'D': pMoves[3, moveDirection] = false; break;
                    default: Console.WriteLine("ERROR!"); break;
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (pMoves[i, j] == true) allAreFalse = false;
                    }
                }

                if (allAreFalse)
                {
                    gameIsFinished = true;
                    Console.WriteLine("King wins!");
                    gameIsFinished = true;
                    return null;
                }
                Console.WriteLine("You can't go in this direction! ");
                return null;
            }
        }
            
       //static int[] CheckNextPownPosition(int[] coordinates, char direction, char pawn)
       //{
       //    int[] moveDownLeft = { 1, -2 };
       //    int[] moveDownRight = { 1, 2 };
       //    int[] newCoordinates = new int[2];
       //    if (direction == 'L')
       //    {
       //        newCoordinates[0] = coordinates[0] + moveDownLeft[0];
       //        newCoordinates[1] = coordinates[1] + moveDownLeft[1];
       //        bool isEmpty = field[newCoordinates[0], newCoordinates[1]] == ' ';
       //
       //        if (proverka(newCoordinates) && isEmpty)//TODO:change method name proverka
       //        {
       //            field[newCoordinates[0], newCoordinates[1]] = field[coordinates[0], coordinates[1]];
       //            field[coordinates[0], coordinates[1]] = ' ';
       //            counter++;
       //            switch (pawn)
       //            {
       //                case 'A': 
       //                    pMoves[0, 0] = true; 
       //                    pMoves[0, 1] = true;
       //                    break;
       //                case 'B':
       //                    pMoves[1, 0] = true;
       //                    pMoves[1, 1] = true;
       //                    break;
       //                case 'C':
       //                    pMoves[2, 0] = true;
       //                    pMoves[2, 1] = true;
       //                    break;
       //                case 'D':
       //                    pMoves[3, 0] = true;
       //                    pMoves[3, 1] = true;
       //                    break;
       //                default:
       //                    Console.WriteLine("ERROR!");
       //                    break;
       //            }
       //
       //            return newCoordinates;
       //        }
       //        else
       //        {
       //            bool allAreFalse = true;
       //            switch (pawn)
       //            {
       //                case 'A': pMoves[0, 0] = false; break;
       //                case 'B': pMoves[1, 0] = false; break;
       //                case 'C': pMoves[2, 0] = false; break;
       //                case 'D': pMoves[3, 0] = false; break;
       //                default: Console.WriteLine("ERROR!"); break;
       //            }
       //            for (int i = 0; i < 4; i++)
       //            {
       //                for (int j = 0; j < 2; j++)
       //                {
       //                    if (pMoves[i, j] == true)
       //                    {
       //                        allAreFalse = false;
       //                    }
       //                }
       //            }
       //            if (allAreFalse)
       //            {
       //                gameIsFinished = true;
       //                Console.WriteLine("King wins!");
       //                gameIsFinished = true;
       //                return null;
       //            }
       //            Console.WriteLine("You can't go in this direction! ");
       //            return null;
       //        }
       //    }
       //    else
       //    {
       //        newCoordinates[0] = coordinates[0] + moveDownRight[0];
       //        newCoordinates[1] = coordinates[1] + moveDownRight[1];
       //        if (proverka(newCoordinates) && field[newCoordinates[0], newCoordinates[1]] == ' ')
       //        {
       //            char sign = field[coordinates[0], coordinates[1]];
       //            field[coordinates[0], coordinates[1]] = ' ';
       //            field[newCoordinates[0], newCoordinates[1]] = sign;
       //            counter++;
       //            switch (pawn)
       //            {
       //                case 'A':
       //                    pMoves[0, 0] = true;
       //                    pMoves[0, 1] = true;
       //                    break;
       //                case 'B':
       //                    pMoves[1, 0] = true;
       //                    pMoves[1, 1] = true;
       //                    break;
       //                case 'C':
       //                    pMoves[2, 0] = true;
       //                    pMoves[2, 1] = true;
       //                    break;
       //                case 'D':
       //                    pMoves[3, 0] = true;
       //                    pMoves[3, 1] = true;
       //                    break;
       //                default:
       //                    Console.WriteLine("ERROR!");
       //                    break;
       //            }
       //            return newCoordinates;
       //        }
       //        else
       //        {
       //            bool allAreFalse = true;
       //            switch (pawn)
       //            {
       //                case 'A':
       //                    pMoves[0, 1] = false;
       //                    break;
       //                case 'B':
       //                    pMoves[1, 1] = false;
       //                    break;
       //                case 'C':
       //                    pMoves[2, 1] = false;
       //                    break;
       //                case 'D':
       //                    pMoves[3, 1] = false;
       //                    break;
       //                default:
       //                    Console.WriteLine("ERROR!");
       //                    break;
       //            }
       //              
       //            for (int i = 0; i < 4; i++)
       //            {
       //                for (int j = 0; j < 2; j++)
       //                {
       //                    if (pMoves[i, j] == true)
       //                    {
       //                        allAreFalse = false;
       //                    }
       //                }
       //            }
       //
       //            if (allAreFalse)
       //            {
       //                gameIsFinished = true;
       //                Console.WriteLine("King wins!");
       //                gameIsFinished = true;
       //                return null;
       //            }
       //            Console.WriteLine("You can't go in this direction! ");
       //            return null;
       //        }
       //    }
       //}

        //TODO - change the method, it should not both check and return the position.
        static int[] CheckNextKingPosition(int[] currentCoordinates, char firstDirection, char secondDirection)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] displasmentUpLeft = { -1, -2 };
            int[] displasmentUpRight = { -1, 2 };
            char sign = 'K'; //TODO: change all of these to constants.

            int[] newCoords = new int[2];
            string command = new string(new char[] {firstDirection, secondDirection}); //TODO: Change method to require a full string as input instead of two chars.

            switch (command)
            {
                case "UL":
                    newCoords[0] = currentCoordinates[0] + displasmentUpLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpLeft[1];
                    kMoves[0] = false; //kMoves is checked only if we cant move to the new position so assigning it to false here is safe
                    break;
                case "UR":
                    newCoords[0] = currentCoordinates[0] + displasmentUpRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpRight[1];
                    kMoves[1] = false;
                    break;
                case "DL":
                    newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
                    kMoves[0] = false; //kMoves is checked only if we cant move to the new position so assigning it to false here is safe
                    break;
                case "DR":
                    newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                    kMoves[0] = false; //kMoves is checked only if we cant move to the new position so assigning it to false here is safe
                    break;                
            }

            bool inBoard = IsInsideBoard(newCoords);
            if (inBoard && (field[newCoords[0], newCoords[1]] == ' '))
            {
                field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                field[newCoords[0], newCoords[1]] = sign;
                counter++;

                for (int i = 0; i < 4; i++)
                {
                    kMoves[i] = true;
                }

                CheckForKingExit(newCoords[0]);
                return newCoords;
            }
            else
            {                
                bool allAreFalse = true;

                for (int i = 0; i < 4; i++)
                {
                    if (kMoves[i] == true)
                    {
                        allAreFalse = false;
                    }
                }

                if (allAreFalse)
                {
                    gameIsFinished = true;
                    Console.WriteLine("King loses!");
                    return null; //TODO: Avoid null returns, throw an exception instead (relies on handling on the caller side).
                }

                Console.WriteLine("You can't go in this direction! ");
                return null;
            }           
        }

        protected static bool gameIsFinished = false;

        /// <summary>
        /// Checks if the king has reached the opposite end of the game board.
        /// </summary>
        /// <param name="currentKingXAxe">The row of the current king's position.</param>
        /// <returns>A boolean value. True if the king has reached the end, false if he hasn't.</returns>
        static bool CheckForKingExit(int currentKingXAxe)
        {
            bool kingExits = false;

            if (currentKingXAxe == 2)
            {
                //Console.WriteLine("End!");
                //Console.WriteLine("King wins in {0} moves!", counter / 2);
                gameIsFinished = true;
                kingExits = true;
            }

            return kingExits;
        }

        /// <summary>
        /// Draws the game board.
        /// </summary>
        protected static void DrawBoard()
        {
            Console.WriteLine();
            
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        protected static bool proverkaIProcess(string checkedInput)
        {
            bool commandNameIsOK = IsValidCommand(checkedInput);
            if (commandNameIsOK)
            {
                char startLetter = checkedInput[0];
                switch (startLetter)
                {
                    case 'A':

                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[0, 0];

                            oldCoordinates[1] = posPaws[0, 1];

                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'A');
                            if (coords != null)
                            {
                                posPaws[0, 0] = coords[0];
                                posPaws[0, 1] = coords[1];
                            }
                        }
                        else 
                        {
                            //=='D'
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[0, 0];

                            oldCoordinates[1] = posPaws[0, 1];
                            int[] coords = new int[2];

                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'A');
                            if (coords != null)
                            {
                                posPaws[0, 0] = coords[0];

                                posPaws[0, 1] = coords[1];
                            }
                        }
                        return true;
                      
                    case 'B':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[1, 0];
                            oldCoordinates[1] = posPaws[1, 1];

                            int[] coords = new int[2];

                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'B');
                            if (coords != null)
                            {
                                posPaws[1, 0] = coords[0];

                                posPaws[1, 1] = coords[1];
                            }
                        }
                        else 
                        {
                            //=='D'
                            int[] oldCoordinates = new int[2];

                            oldCoordinates[0] = posPaws[1, 0];

                            oldCoordinates[1] = posPaws[1, 1];

                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'B');
                            if (coords != null)
                            {
                                posPaws[1, 0] = coords[0];

                                posPaws[1, 1] = coords[1];
                            }
                        }
                        return true;

                    case 'C':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[2, 0];

                            oldCoordinates[1] = posPaws[2, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'C');
                            if (coords != null)
                            {
                                posPaws[2, 0] = coords[0];
                                posPaws[2, 1] = coords[1];
                            }
                        }
                        else 
                        {
                            //=='D'
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[2, 0];
                            oldCoordinates[1] = posPaws[2, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'C');
                            if (coords != null)
                            {
                                posPaws[1, 0] = coords[0];
                                posPaws[1, 1] = coords[1];
                            }
                        }
                        return true;
                          
                    case 'D':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[3, 0];
                            oldCoordinates[1] = posPaws[3, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'D');
                            if (coords != null)
                            {
                                posPaws[3, 0] = coords[0];
                                posPaws[3, 1] = coords[1];
                            }
                        }
                        else 
                        {
                            //=='D'
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[3, 0];
                            oldCoordinates[1] = posPaws[3, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'D');
                            if (coords != null)
                            {
                                posPaws[3, 0] = coords[0];
                                posPaws[3, 1] = coords[1];
                            }
                        }
                        return true;

                    case 'K':
                        if (checkedInput[1] == 'U')
                        {
                            if (checkedInput[2] == 'L')
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = posKing[0];
                                oldCoordinates[1] = posKing[1];
                                int[] coords = new int[2];
                                coords = CheckNextKingPosition(oldCoordinates, 'U', 'L');
                                if (coords != null)
                                {
                                    posKing[0] = coords[0];
                                    posKing[1] = coords[1];
                                }
                            }
                            else
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = posKing[0];
                                oldCoordinates[1] = posKing[1];
                                int[] coords = new int[2];
                                coords = CheckNextKingPosition(oldCoordinates, 'U', 'R');
                                if (coords != null)
                                {
                                    posKing[0] = coords[0];
                                    posKing[1] = coords[1];
                                }
                            }
                            return true;
                        }
                        else
                        {
                            //=KD_
                            if (checkedInput[2] == 'L')
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = posKing[0];
                                oldCoordinates[1] = posKing[1];
                                int[] coords = new int[2];
                                coords = CheckNextKingPosition(oldCoordinates, 'D', 'L');
                                if (coords != null)
                                {
                                    posKing[0] = coords[0];
                                    posKing[1] = coords[1];
                                }
                            }
                            else
                            {
                                //==KDD
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = posKing[0];
                                oldCoordinates[1] = posKing[1];
                                int[] coords = new int[2];
                                coords = CheckNextKingPosition(oldCoordinates, 'D', 'R');
                                if (coords != null)
                                {
                                    posKing[0] = coords[0];
                                    posKing[1] = coords[1];
                                }
                            }
                            return true;
                        }
                    default:
                        Console.WriteLine("Sorry, there are some errors, but I can't tell you anything! You broke my program!");
                        return false;
                }
            }
            else
            {
                return false;//message is from other
            }
        }
    }
}
