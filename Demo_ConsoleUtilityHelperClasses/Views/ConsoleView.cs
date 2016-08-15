using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ConsoleUtilityHelperClasses
{
    public class ConsoleView
    {
        #region FIELDS

        //
        // window size
        //
        private const int WINDOW_WIDTH = ConsoleViewSettings.WINDOW_WIDTH;
        private const int WINDOW_HEIGHT = ConsoleViewSettings.WINDOW_HEIGHT;

        //
        // window location
        //
        private const int WINDOW_TOP = ConsoleViewSettings.WINDOW_TOP;
        private const int WINDOW_LEFT = ConsoleViewSettings.WINDOW_LEFT;

        //
        // horizontal and vertical margins in console window for display
        //
        private const int DISPLAY_HORIZONTAL_MARGIN = ConsoleViewSettings.DISPLAY_HORIZONTAL_MARGIN;
        private const int DISPALY_VERITCAL_MARGIN = ConsoleViewSettings.DISPALY_VERITCAL_MARGIN;



        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// constructor to create the console view objects
        /// </summary>
        public ConsoleView()
        {
            InitializeConsoleWindow();

            ConsoleUtil.DisplayReset();


        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the console window with default settings
        /// </summary>
        public void InitializeConsoleWindow()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            Console.SetWindowPosition(WINDOW_LEFT, WINDOW_TOP);

            ConsoleUtil.WindowWidth = WINDOW_WIDTH;
            ConsoleUtil.WindowHeight = WINDOW_HEIGHT;

            ConsoleUtil.HeaderText = "The Console Utility Demo";
        }

        ///// <summary>
        ///// reset display to default size and colors including the header
        ///// </summary>
        //public void DisplayReset()
        //{
        //    Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

        //    Console.Clear();
        //    Console.ResetColor();

        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.BackgroundColor = ConsoleColor.White;

        //    Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
        //    Console.WriteLine(ConsoleUtil.Center("The Deadly Dinner Party Game", WINDOW_WIDTH));
        //    Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

        //    Console.ResetColor();
        //    Console.WriteLine();
        //}

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            Console.WriteLine(ConsoleUtil.Center("Press any key to continue.", WINDOW_WIDTH));
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            DisplayMessage("Thank you for playing our game. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }


        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("Welcome to", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("The Deadly Dinner Party Game", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();

            DisplayContinuePrompt();
        }


        /// <summary>
        /// display a message in the message area
        /// </summary>
        /// <param name="message">string to display</param>
        public void DisplayMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            // message is not an empty line, display text
            if (message != "")
            {
                //
                // create a list of strings to hold the wrapped text message
                //
                List<string> messageLines;

                //
                // call utility method to wrap text and loop through list of strings to display
                //
                messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);
                foreach (var messageLine in messageLines)
                {
                    Console.WriteLine(messageLine);
                }
            }
            // display an empty line
            else
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// display a message in the message area without a new line for the prompt
        /// </summary>
        /// <param name="message">string to display</param>
        public void DisplayPromptMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            //
            // create a list of strings to hold the wrapped text message
            //
            List<string> messageLines;

            //
            // call utility method to wrap text and loop through list of strings to display
            //
            messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);

            for (int lineNumber = 0; lineNumber < messageLines.Count() - 1; lineNumber++)
            {
                Console.WriteLine(messageLines[lineNumber]);
            }

            Console.Write(messageLines[messageLines.Count() - 1]);
        }

        // TODO code - display menu
        /// <summary>
        /// provides a menu with options to display the information of the current objects in the game
        /// </summary>
        public void DisplayAllObjectInformation()
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set a string variable with a length equal to the horizontal margin and filled with spaces
                //
                string leftTab = ConsoleUtil.FillStringWithSpaces(DISPLAY_HORIZONTAL_MARGIN);

                //
                // set up display area
                //
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                Console.WriteLine(
                    leftTab + "1. Player Information" + Environment.NewLine +
                    leftTab + "2. Hall Information" + Environment.NewLine +
                    leftTab + "3. Guest List Information" + Environment.NewLine +
                    leftTab + "4. Staff List Information" + Environment.NewLine +
                    leftTab + "5. Treasure Types" + Environment.NewLine +
                    leftTab + "6. Player's Treasure" + Environment.NewLine +
                    leftTab + "7. Player's Weapons" + Environment.NewLine +
                    leftTab + "E. Exit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        //DisplayPlayerInformation();
                        break;
                    case '2':
                        //DisplayHallInformation();
                        break;
                    case '3':
                        //DisplayGuestListInformation();
                        break;
                    case '4':
                        //DisplayStaffListInformation();
                        break;
                    case '5':
                        //DisplayTreasureTypes();
                        break;
                    case '6':
                        //DisplayPlayersTreasure();
                        break;
                    case '7':
                        //DisplayPlayersWeapons();
                        break;
                    case 'E':
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to exit.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;
        }

        // TODO code - display a list of items with numbers
        /// <summary>
        /// display the available actions choices
        /// </summary>
        public void DisplayActionChoices()
        {
            //DisplayMessage("You have the following actions available to you.");
            //Console.WriteLine();

            //foreach (Player.ActionChoice choice in Enum.GetValues(typeof(Player.ActionChoice)))
            //{
            //    string actionChoiceText;

            //    // skip the first enum value that is the default value of "none"
            //    if (choice != Player.ActionChoice.None)
            //    {
            //        actionChoiceText = "(" + ((int)choice) + ") " +
            //            ConsoleUtil.ToLabelFormat(choice.ToString());
            //        DisplayMessage(actionChoiceText);
            //    }
            //}
        }


        // TODO code - get an actions choice
        /// <summary>
        /// get player action choice
        /// </summary>
        /// <returns>player action choice enum</returns>
        //public Player.ActionChoice GetPlayerAction()
        //{
        //    int playerActionChoiceIndex;
        //    string playerResponse;
        //    bool validPlayerResponse = false;
        //    Player.ActionChoice playerActionChoice = Player.ActionChoice.None;

        //    while (!validPlayerResponse)
        //    {
        //        DisplayReset();
        //        Console.WriteLine();

        //        DisplayActionChoices();

        //        Console.WriteLine();
        //        DisplayPromptMessage("Enter the number for the action you would like to take: ");
        //        playerResponse = Console.ReadLine();

        //        // validate user's response
        //        if (
        //            (Int32.TryParse(playerResponse, out playerActionChoiceIndex)) &&
        //            (playerActionChoiceIndex != 0) &&
        //            (playerActionChoiceIndex <= _myPlayer.ActionCount - 1)
        //            )
        //        {
        //            playerActionChoice = (Player.ActionChoice)playerActionChoiceIndex;

        //            Console.WriteLine();
        //            DisplayMessage("You have chosen the following action: " +
        //                ConsoleUtil.ToLabelFormat(playerActionChoice.ToString()));
        //            validPlayerResponse = true;

        //            DisplayContinuePrompt();
        //        }
        //        else
        //        {
        //            Console.WriteLine();

        //            DisplayMessage("It appears that you have not provided a valid action." +
        //                "Please use the number before each action to indicate your choice.");

        //            DisplayContinuePrompt();
        //        }

        //    }

        //    return playerActionChoice;

        //}

        #endregion
    }
}
