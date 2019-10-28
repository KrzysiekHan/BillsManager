using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUI.Common
{
    public static class CommonFunctions
    {
        public static int NullableIntToInt(int? nulllable_value)
        {
            int idn = nulllable_value ?? default(int);
            return idn;
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }
    }
}