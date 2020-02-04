// ReSharper disable once CheckNamespace
public static class StringHelper
{
    #region Methods

    public static string GenerateRandomString(int length,
        bool numeric = false,
        bool lowercase = false,
        bool uppercase = false,
        bool space = false,
        bool underscore = false,
        bool hypen = false,
        bool period = false)
    {
        return "".GenerateRandomString(length,
            numeric,
            lowercase,
            uppercase,
            space,
            underscore,
            hypen,
            period);
    }

    #endregion
}
