using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MusicStore
{
    public static class Extensions
    {
        public static string ToSafeUrlString(this string Text, bool Invariant = false) => Regex.Replace(string.Concat(Text.Where(p => char.IsLetterOrDigit(p) || char.IsWhiteSpace(p))), @"\s+", "-").ToLower(Invariant ? CultureInfo.InvariantCulture : CultureInfo.CurrentCulture);
    }
}