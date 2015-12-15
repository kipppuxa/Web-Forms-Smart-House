using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    class StereoSystem : Device, IVolumable, ISwitchable
    {
        public int Volume { get; set; }
        public StereoSystem(bool state, int volume)
            : base(state)
        {
            Volume = volume;
        }

        public void SetOn()
        {
            State = true;
        }

        public void SetOff()
        {
            State = false;
        }

        public void SetVolumeUp()
        {
            if (Volume < 3 )
            {
                Volume++;
            }
        }

        public void SetVolumeDown()
        {
            if (Volume > 0)
            {
                Volume--;
            }
        }
    }
}
