using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    public class Lamp : Device, ISwitchable, IBrightable
    {
        public BrightnessLevel Brightness { get; set; }
        public Lamp(bool state, BrightnessLevel brightness)
            : base(state)
        {
            Brightness = brightness;
        }

        public void SetOn()
        {
            State = true;
        }

        public void SetOff()
        {
            State = false;
        }
        public void NextBright()
        {
            if ((int)Brightness < System.Enum.GetValues(typeof(BrightnessLevel)).Length -1)
            {
                Brightness++;
            }
        }

        public void PrevBright()
        {
            if ((int)Brightness > 0)
            {
                Brightness--;
            }
        }
    }
}
