using Rocket.API.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSignRestriction
{
    public partial class BTSignRestriction
    {
        public override TranslationList DefaultTranslations => new TranslationList
        {
            {
                "UnableToSetText", "[color=#FF0000]{{BTSignRestriction}} [/color] [color=#F3F3F3]You are unable to set text on this sign.[/color]"
            },
            {
                "StaffNotiy", "[color=#FF0000]{{BTSignRestriction}} [/color][color=#3E65FF]{0}[/color] [color=#F3F3F3]Attempted to change Sign Text to:[/color] [color=#3E65FF]{1}[/color]"
            }

        };
    }
}