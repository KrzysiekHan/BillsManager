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
    }
}