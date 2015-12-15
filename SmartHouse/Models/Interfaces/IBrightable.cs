using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    interface IBrightable
    {
        void NextBright();

        void PrevBright();

        BrightnessLevel Brightness { get; set; }
        
    }
}
