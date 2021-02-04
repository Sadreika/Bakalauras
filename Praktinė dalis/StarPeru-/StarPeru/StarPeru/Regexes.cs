using System.Linq;
using System.Text.RegularExpressions;

namespace StarPeru
{
    public class Regexes
    {
        public static RegexOptions RegexOptionsCompiled = RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase;

        public static Regex Bounds = new Regex(@"table-responsive(.*?)</div>\s*</div>\s*</div>", RegexOptionsCompiled);

        public static Regex Sectors = new Regex(@"<tr>\s*<td>(.*?)</td>\s*<tr>", RegexOptionsCompiled);

        public static Regex SectorOriginAndDestination = new Regex(@"[A-Z]{3}\s*&gt;\s*[A-Z]{3}", RegexOptionsCompiled);

        public static Regex SectorInfo = new Regex(@"[0-9.]+\|.\|[0-9]+\|[0-9]+-[0-9]+-[0-9]+\s*[0-9]+:[0-9]+:[0-9]+\|[0-9]+-[0-9]+-[0-9]+\s*[0-9]+:[0-9]+:[0-9]+", RegexOptionsCompiled);

        public static string[] RegexToStringArray(string content, Regex regexes)
        {
            return regexes.Matches(content).Cast<Match>()
            .Select(m => m.Value)
            .ToArray();
        }

        public static string RegexToString(string content, Regex regexes)
        {
            return regexes.Match(content).ToString();
        }
    }
}
