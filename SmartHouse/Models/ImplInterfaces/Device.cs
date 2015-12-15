using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    public abstract class Device
    {
        public bool State { get; set; }

        public Device(bool state)
        {
            State = state;
        }
    }
}
