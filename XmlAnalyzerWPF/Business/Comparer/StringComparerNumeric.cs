using System.Collections.Generic;
using static System.Int32;

namespace XmlAnalyzerWPF.Business.Comparer
{
    class StringComparerNumeric:IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int aint;
            int bint;
            if (TryParse(x, out aint) && TryParse(y, out bint))
                return aint.CompareTo(bint);

            return 0;
        }
    }
}
