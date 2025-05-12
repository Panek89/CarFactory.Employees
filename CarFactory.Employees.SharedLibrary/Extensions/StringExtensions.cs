using System.Text.RegularExpressions;

namespace CarFactory.Employees.SharedLibrary.Extensions;

public static class StringExtensions
{
    public static bool HasNonDigitChars(this string input)
    {
        return Regex.IsMatch(input, @"\D");
    }

    public static bool HasNonLettersChars(this string input)
    {
        return !Regex.IsMatch(input, @"^\p{L}+$");
    }
}
