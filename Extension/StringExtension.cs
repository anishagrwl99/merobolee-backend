using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MeroBolee
{
    public static class StringExtension
    {

        public static string GetFirstCharString(this string text)
        {
            IEnumerable<char> firstChars = text.Where((ch, index) => ch != ' '
                       && (index == 0 || text[index - 1] == ' '));

            return string.Join("", firstChars).StripeIllegalCharacter();
        }

        public static string StripeIllegalCharacter(this string text)
        {
            Regex illegalInFileName = new Regex(@"[^a-zA-Z0-9]"); //only allow A to Z (upper/lower) and 0-9
            return illegalInFileName.Replace(text, "");
        }
    }
}
