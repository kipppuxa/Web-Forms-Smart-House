using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    class TV : Device, ISwitchable, IChannelable, IStereoVolumable
    {
        private StereoSystem StereoSystem;
        public int Channel { get; set; }

        public TV(bool state, int channel, StereoSystem sSystem)
            : base(state)
        {
            Channel = channel;
            StereoSystem = sSystem;
        }
        public void SetOn()
        {
            State = true;
        }

        public void SetOff()
        {
            State = false;
        }

        public void NextChannel()
        {
            if ((int)Channel < System.Enum.GetValues(typeof(ChannelNumber)).Length)
            {
                Channel++;
            }
        }

        public void PrevChannel()
        {
            if ((int)Channel > 0)
            {
                Channel--;
            }
        }

        public void StereoVolumeUp()
        {
            StereoSystem.SetVolumeUp();
        }

        public void StereoVolumeDown()
        {
            StereoSystem.SetVolumeDown();
        }

        public override string ToString()
        {
            string volume = StereoSystem.Volume.ToString();

            return volume;
        }
    }
}