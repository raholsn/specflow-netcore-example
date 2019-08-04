using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public enum RaceEnum
    {
        Orc = 1,
        Elf = 2
    }

    static class RaceEnumExtensions
    {
        public static bool IsOrc(this RaceEnum raceEnum)
        {
            return (int)raceEnum == 1;
        }

        public static bool IsElf(this RaceEnum raceEnum)
        {
            return (int)raceEnum == 2;
        }
    }
}
