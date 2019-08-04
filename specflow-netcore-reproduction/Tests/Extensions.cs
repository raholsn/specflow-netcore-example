using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Tests
{
    public static class Extensions
    {
        public static T GetStat<T>(this Table table, string att) 
        {
            return (T)Convert.ChangeType(table.Rows.Select(row => row[att]).First(), typeof(T));
        }
    }
}
