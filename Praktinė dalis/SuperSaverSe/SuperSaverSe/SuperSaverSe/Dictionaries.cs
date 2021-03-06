namespace SuperSaverSe
{
    using System.Collections.Generic;
    public class Dictionaries
    {
        public static Dictionary<char, char> PageCabinsSe = new Dictionary<char, char>
        {
            ['E'] = 'Y',
            ['F'] = 'F',
            ['B'] = 'C',
            ['P'] = 'S'
        };

        public static Dictionary<string, char> ToGuiCabinsSe = new Dictionary<string, char>
        {
            ["Y"] = 'E',
            ["F"] = 'F',
            ["C"] = 'B',
            ["S"] = 'P'
        };
    }
}
