using System;
using System.Collections.Generic;

namespace XmlAnalyser.Business
{
    internal class StringComparerAlpha : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.Ordinal);
        }
    }
}