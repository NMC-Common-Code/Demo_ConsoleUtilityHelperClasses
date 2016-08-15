using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Demo_ConsoleUtilityHelperClasses
{
    /// <summary>
    /// console utility class
    /// </summary>
    public static class ConsoleUtil
    {

        private static int _windowWidth = 79;
        private static int _windowHeight = 40;

        private static int _windowLeft = 20;
        private static int _windowTop = 20;

        private static string _headerText = "- set header text -";
        private static string _footerText = "- set footer text - ";

        private static ConsoleColor _headerBackgroundColor = ConsoleColor.White;
        private static ConsoleColor _headerForegroundColor = ConsoleColor.Red;

        private static ConsoleColor _footerBackgroundColor = ConsoleColor.White;
        private static ConsoleColor _footerForegroundColor = ConsoleColor.Red;

        private static ConsoleColor _bodyBackgroundColor = ConsoleColor.Black;
        private static ConsoleColor _bodyForegroundColor = ConsoleColor.White;
        
        public static int WindowWidth
        {
            get { return _windowWidth; }
            set { _windowWidth = value; }
        }

        public static int WindowHeight
        {
            get { return _windowHeight; }
            set { _windowHeight = value; }
        }
        
        public static int WindowLeft
        {
            get { return _windowLeft; }
            set { _windowLeft = value; }
        }

        public static int WindowTop
        {
            get { return _windowTop; }
            set { _windowTop = value; }
        }

        public static string HeaderText
        {
            get { return _headerText; }
            set { _headerText = value; }
        }
        
        public static string FooterText
        {
            get { return _footerText; }
            set { _footerText = value; }
        }
        
        public static ConsoleColor HeaderBackgroundColor
        {
            get { return _headerBackgroundColor = ConsoleColor.White; }
            set { _headerBackgroundColor = value; }
        }

        public static ConsoleColor HeaderForegroundColor
        {
            get { return _headerForegroundColor = ConsoleColor.Red; }
            set { _headerForegroundColor = value; }
        }

        public static ConsoleColor FooterBackgroundColor
        {
            get { return _footerBackgroundColor = ConsoleColor.White; }
            set { _footerBackgroundColor = value; }
        }

        public static ConsoleColor FooterForegroundColor
        {
            get { return _footerForegroundColor = ConsoleColor.Red; }
            set { _footerForegroundColor = value; }
        }

        /// <summary>
        /// reset display to default size and colors including the header
        /// </summary>
        public static void DisplayReset()
        {
            Console.SetWindowSize(_windowWidth, _windowHeight);

            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(_windowWidth));
            Console.WriteLine(ConsoleUtil.Center(_headerText, _windowWidth));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(_windowWidth));

            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// wraps text using a list of strings
        /// Original code from Mike Ward's website
        /// http://mike-ward.net/2009/07/19/word-wrap-in-a-console-app-c/
        /// Adapted to include a left margin for console window support
        /// </summary>
        /// <param name="text">text to wrap</param>
        /// <param name="rightMargin">length of each line</param>
        /// <param name="leftMargin">left margin</param>
        /// <returns>list of lines as strings</returns>
        public static List<string> Wrap(string text, int rightMargin, int leftMargin)
        {
            int start = 0, end;
            var lines = new List<string>();

            string leftMarginSpaces = "";
            for (int i = 0; i < leftMargin; i++)
            {
                leftMarginSpaces += " ";
            }

            text = Regex.Replace(text, @"\s", " ").Trim();

            while ((end = start + rightMargin) < text.Length)
            {
                while (text[end] != ' ' && end > start)
                    end -= 1;

                if (end == start)
                    end = start + rightMargin;

                lines.Add(leftMarginSpaces + text.Substring(start, end - start));
                start = end + 1;
            }

            if (start < text.Length)
                lines.Add(leftMarginSpaces + text.Substring(start));

            return lines;
        }

        /// <summary>
        /// center text as a function of the window width with padding on both sides
        /// Note: the method currently assumes the text will fit on one line
        /// </summary>
        /// <param name="text">text to center</param>
        /// <param name="windowWidth">the width of the window in characters</param>
        /// <returns>string with spaces and centered text</returns>
        public static string Center(string text, int windowWidth)
        {
            int leftPadding = (windowWidth - text.Length) / 2 + text.Length;
            return text.PadLeft(leftPadding).PadRight(windowWidth);
        }

        /// <summary>
        /// generate a string of spaces of a given length
        /// </summary>
        /// <param name="stringLength">length of string</param>
        /// <returns>string of spaces</returns>
        public static string FillStringWithSpaces(int stringLength)
        {
            string rowOfSpaces = "";
            return rowOfSpaces.PadRight(stringLength);
        }

        /// <summary>
        /// convert camelcase to all upper case and spaces
        /// reference url - http://stackoverflow.com/questions/15458257/how-to-have-enum-values-with-spaces
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String ToLabelFormat(String s)
        {
            var newStr = Regex.Replace(s, "(?<=[A-Z])(?=[A-Z][a-z])", " ");
            newStr = Regex.Replace(newStr, "(?<=[^A-Z])(?=[A-Z])", " ");
            //newStr = Regex.Replace(newStr, "(?<=[A-Za-z])(?=[^A-Za-z])", " ");

            return newStr;
        }
    }
}
