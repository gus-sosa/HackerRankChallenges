using System;
using System.Linq;

internal class Solution
{
    private const string YES = "YES";
    private const string NO = "NO";
    private const char NO_MORE_CHARS = '0';
    private const char OPEN_PARENTHESIS = '(';
    private const char CLOSED_PARENTHESIS = ')';
    private const char COLON = ':';
    private static readonly char[] ImportantChars = new char[] { OPEN_PARENTHESIS, CLOSED_PARENTHESIS, COLON };
    private static readonly char[] Parenthesis = new[] { OPEN_PARENTHESIS, CLOSED_PARENTHESIS };

    private static string smileyText = string.Empty;

    private static void Main(string[] args)
    {
        smileyText = Console.ReadLine();
        Console.WriteLine(IsBalancedParenthesisAndSmileyText() ? YES : NO);
    }

    private static bool IsBalancedParenthesisAndSmileyText()
    {
        return BalancedAndSmiley(0, 0);
    }

    private static bool BalancedAndSmiley(int currentIndex, int numOpenParenthesis)
    {
        if (numOpenParenthesis < 0)
            return false;
        if (currentIndex == smileyText.Length)
            return numOpenParenthesis == 0;
        if (currentIndex > smileyText.Length)
            return false;

        var currentChar = smileyText[currentIndex];
        if (IsNotImportantChar(currentChar))
            return BalancedAndSmiley(currentIndex + 1, numOpenParenthesis);

        return ProcessImportantChar(currentIndex, numOpenParenthesis);
    }

    private static bool IsNotImportantChar(char currentChar)
    {
        return !ImportantChars.Contains(currentChar);
    }

    private static bool ProcessImportantChar(int currentIndex, int numOpenParenthesis)
    {
        var currentChar = smileyText[currentIndex];
        var caseResult = false;
        switch (currentChar)
        {
            case COLON:
                caseResult = ProcessColon(currentIndex, numOpenParenthesis);
                break;
            case OPEN_PARENTHESIS:
                caseResult = BalancedAndSmiley(currentIndex + 1, numOpenParenthesis + 1);
                break;
            case CLOSED_PARENTHESIS:
                caseResult = ProcessClosedParenthesis(currentIndex, numOpenParenthesis);
                break;
            default:
                throw new InvalidOperationException($"Character {currentChar} is not included in the switch statement");
        }

        return caseResult;
    }

    private static bool ProcessClosedParenthesis(int currentIndex, int numOpenParenthesis)
    {
        if (numOpenParenthesis < 1)
            return false;
        return BalancedAndSmiley(currentIndex + 1, numOpenParenthesis - 1);
    }

    private static bool ProcessColon(int currentIndex, int numOpenParenthesis)
    {
        var nextCharacter = currentIndex + 1 < smileyText.Length ? smileyText[currentIndex + 1] : NO_MORE_CHARS;
        if (nextCharacter == NO_MORE_CHARS)
            return BalancedAndSmiley(currentIndex + 1, numOpenParenthesis);

        var nextCharIsParenthesis = Parenthesis.Contains(nextCharacter);
        if (nextCharIsParenthesis)
        {
            if (IsFace(currentIndex, numOpenParenthesis))
                return true;
            if (nextCharacter == OPEN_PARENTHESIS)
                return BalancedAndSmiley(currentIndex + 2, numOpenParenthesis + 1);
            return BalancedAndSmiley(currentIndex + 2, numOpenParenthesis - 1);
        }
        return BalancedAndSmiley(currentIndex + 1, numOpenParenthesis);
    }

    private static bool IsFace(int currentIndex, int numOpenParenthesis)
    {
        if (BalancedAndSmiley(currentIndex + 2, numOpenParenthesis))
            return true;
        return false;
    }
}