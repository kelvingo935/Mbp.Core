#region using

using System;

#endregion

namespace Mbp.Core.Attributes
{
    public class DisplayTextAttribute : Attribute
    {
        #region Fields, Properties and Indexers

        public string DisplayText { get; set; }

        #endregion

        #region Constructors

        public DisplayTextAttribute(string displayText)
        {
            DisplayText = displayText;
        }

        #endregion
    }
}
