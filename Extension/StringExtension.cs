using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee
{
    public static class StringExtension
    {

        public static string GetFirstCharString(this string text)
        {
            IEnumerable<char> firstChars = text.Where((ch, index) => ch != ' '
                       && (index == 0 || text[index - 1] == ' '));

            return string.Join("", firstChars);
        }
    }
}
