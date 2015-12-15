using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    interface IChannelable
    {
        void NextChannel();

        void PrevChannel();

        int Channel { get; set; }
    }
}
