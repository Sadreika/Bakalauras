﻿namespace Currency_crawler
{
    public static class Regexes
    {
        public static string JavaScriptCacheCode = @"/currency/converter/cache(.*?)\u002ejs";
        public static string CurrencyJson = @"var\s*cache\s*=\s*(.*?}}});";
    }
}
