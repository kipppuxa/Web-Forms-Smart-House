using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    class Heater : Device, IHeatable, ISwitchable
    {
        public HeatLevel Heat { get; set; }
        public Heater(bool state, HeatLevel heat)
            : base(state)
        {
            Heat = heat;
        }

        public void SetOn()
        {
            State = true;
        }

        public void SetOff()
        {
            State = false;
        }

        public void NextHeat()
        {
            if ((int)Heat < System.Enum.GetValues(typeof(HeatLevel)).Length - 1)
            {
                Heat++;
            }
        }

        public void PrevHeat()
        {
            if ((int)Heat > 0)
            {
                Heat--;
            }
        }
    }
}
