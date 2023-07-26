using Rocket.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSignRestriction.Helpers.BaseHelpers
{
    public class DebugManager
    {
        public static void SendDebugMessage(string message)
        {
            if (BTSignRestriction.Instance.Configuration.Instance.DebugMode)
            {
                Logger.Log("DEBUG >> " + message);
            }
        }
    }
}