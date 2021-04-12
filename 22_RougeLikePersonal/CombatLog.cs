using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal
{
    static class CombatLog
    {
        public static List<string> Log = new List<string>();

        public static void LogCombat(string toLog) 
        {
            Log.Insert(0, toLog);
        }
    }
}
