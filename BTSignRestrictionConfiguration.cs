using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BTSignRestriction
{
    public class BTSignRectrictionConfiguration : IRocketPluginConfiguration
    {
        public string SignRestrictionBypass { get; set; }
        public bool allowEditOwnSgn { get; set; }
        public bool NotifyStaffOnTextChange { get; set; }
        public string StaffPermission { get; set; }
        public bool DebugMode { get; set; }
        public void LoadDefaults()
        {
            SignRestrictionBypass = "BTSignRestriction.Bypass";
            allowEditOwnSgn = false;
            NotifyStaffOnTextChange = true;
            StaffPermission = "BTSignRestriction.Staff";
            DebugMode = false;
        }
    }
}
