using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    interface IVolumable
    {
        void SetVolumeUp();

        void SetVolumeDown();

        int Volume { get; set; }
    }
}
