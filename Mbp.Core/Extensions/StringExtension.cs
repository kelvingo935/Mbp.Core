#region using

using System;

#endregion

// ReSharper disable once CheckNamespace
public static class StringExtension
{
    #region Static Fields and Properties

    private static readonly Random _Seed = new Random();

    #endregion

    #region Methods

    public static string GenerateRandomString(this string stringValue,
        int length,
        bool numeric = false,
        bool lowercase = false,
        bool uppercase = false,
        bool space = false,
        bool underscore = false,
        bool hypen = false,
        bool period = false)
    {
        var ret = "";
        var validCharacters = "";

        if (lowercase)
        {
            validCharacters += "abcdefghijklmnopqrstuvwxyz";
        }

        if (uppercase)
        {
            validCharacters += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }

        if (numeric)
        {
            validCharacters += "0123456789";
        }

        if (space)
        {
            validCharacters += " ";
        }

        if (underscore)
        {
            validCharacters += "_";
        }

        if (hypen)
        {
            validCharacters += "-";
        }

        if (period)
        {
            validCharacters += ".";
        }

        if (string.IsNullOrEmpty(validCharacters))
        {
            validCharacters += "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        }

        var rand = new Random(_Seed.Next());

        for (var i = 0; i < length; i++)
        {
            ret += validCharacters[rand.Next(0,
                validCharacters.Length - 1)];
        }

        return ret;
    }

    public static string Pad(this string stringValue,
        int length,
        char paddingChar = ' ',
        bool paddingLeft = true)
    {
        var ret = stringValue;

        if (string.IsNullOrEmpty(ret))
        {
            ret = "";
        }

        if (ret.Length > length)
        {
            ret = paddingLeft
                ? ret.Substring(0,
                    length)
                : ret.Substring(ret.Length - (length + 1),
                    length);
        }
        else if (ret.Length < length)
        {
            ret = paddingLeft
                ? ret.PadLeft(length,
                    paddingChar)
                : ret.PadRight(length,
                    paddingChar);
        }

        return ret;
    }

    #endregion
}
