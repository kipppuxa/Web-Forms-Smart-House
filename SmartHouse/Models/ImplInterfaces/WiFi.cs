using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    class WiFi : Device, ISwitchable
    {
        public WiFi (bool state)
            : base(state)
        {
           
        }

        public void SetOn()
        {
            State = true;
        }

        public void SetOff()
        {
            State = false;
        }
    }
}
