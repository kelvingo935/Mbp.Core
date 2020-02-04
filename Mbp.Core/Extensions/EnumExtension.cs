#region using

using System;
using System.ComponentModel;
using Mbp.Core.Attributes;

#endregion

// ReSharper disable once CheckNamespace
public static class EnumExtension
{
    #region Methods

    public static string GetDescription(this Enum enumValue)
    {
        var type = enumValue.GetType();
        var memberInfo = type.GetMember(enumValue.ToString());
        if (memberInfo.Length > 0)
        {
            var attributes = memberInfo[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }
        }

        return enumValue.ToString();
    }

    public static string GetDisplayName(this Enum enumValue)
    {
        var type = enumValue.GetType();
        var memberInfo = type.GetMember(enumValue.ToString());
        if (memberInfo.Length > 0)
        {
            var attributes = memberInfo[0]
                .GetCustomAttributes(typeof(DisplayNameAttribute), false);

            if (attributes.Length > 0)
            {
                return ((DisplayNameAttribute)attributes[0]).DisplayName;
            }
        }

        return enumValue.ToString();
    }

    public static string GetDisplayText(this Enum enumValue)
    {
        var type = enumValue.GetType();
        var memberInfo = type.GetMember(enumValue.ToString());
        if (memberInfo.Length > 0)
        {
            var attributes = memberInfo[0]
                .GetCustomAttributes(typeof(DisplayTextAttribute), false);

            if (attributes.Length > 0)
            {
                return ((DisplayTextAttribute)attributes[0]).DisplayText;
            }
        }

        return enumValue.ToString();
    }

    #endregion
}
