﻿namespace StarPeru
{
    public class Regexes
    {
        public static string Bounds = @"table-responsive(.*?)</div>\s*</div>\s*</div>";

        public static string Sectors = @"<tr>\s*<td>(.*?)</td>\s*<tr>";

        public static string SectorOriginAndDestination = @"([A-Z]{3})\s*&gt;\s*([A-Z]{3})";

        public static string SectorInfo = @"familia_([a-z]+)_(?:[^=]+=){4}\u0022([0-9.]+)\|.\|([0-9]+)\|([0-9]+-[0-9]+-[0-9]+)\s*([0-9]+:[0-9]+:[0-9]+)\|([0-9]+-[0-9]+-[0-9]+)\s*([0-9]+:[0-9]+:[0-9]+)(?:[^>]+>){2}\s*([a-z]+)";
    }
}
