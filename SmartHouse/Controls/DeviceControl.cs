using Smart_House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartHouse.Controls
{
    public class DeviceControl : Panel
    {
        private int id;
        private IDictionary<int, Device> deviceCollection;

        private ImageButton setButtonOnOff;
        private ImageButton setButtonUp;
        private ImageButton setButtonDown;
        private ImageButton deleteButton;
        private ImageButton setButtonPlus;
        private ImageButton setButtonMinus;

        private string brightnessLevel;
        private string heatLevel;
        private int channel;
        private int? volume;

        private Image mainImage = new Image();
        private Image volumeImage = new Image();

        public DeviceControl(int id, IDictionary<int, Device> deviceCollection)
        {
            this.id = id;
            this.deviceCollection = deviceCollection;
            Initializer();
        }

        protected void Initializer()
        {
            CssClass = "device-div";

            if (deviceCollection[id] is ISwitchable)
            {
                setButtonOnOff = new ImageButton();

                if (deviceCollection[id].State == true)
                {
                    setButtonOnOff.ImageUrl = "~/Images/onOffUpDown/off.png";

                    if (deviceCollection[id] is IBrightable)
                    {
                        string s = CheckBrightnessLevel();

                        if (s == "Low")
                        {
                            mainImage.ImageUrl = "~/Images/lamp/lampOn.png";
                        }
                        else if (s == "Medium")
                        {
                            mainImage.ImageUrl = "~/Images/lamp/lampOnMed.png";
                        }
                        else
                        {
                            mainImage.ImageUrl = "~/Images/lamp/lampOnHigh.png";
                        }
                    }
                    else if (deviceCollection[id] is IHeatable)
                    {
                        string s = CheckHeatLevel();

                        if (s == "Low")
                        {
                            mainImage.ImageUrl = "~/Images/Heater/heatLow.png";
                        }
                        else if (s == "Medium")
                        {
                            mainImage.ImageUrl = "~/Images/Heater/heatMed.png";
                        }
                        else
                        {
                            mainImage.ImageUrl = "~/Images/Heater/heatHigh.png";
                        }
                    }
                    else if (deviceCollection[id] is IChannelable)
                    {
                        int i = CheckChannelNumber();

                        if (i == 1)
                        {
                            mainImage.ImageUrl = "~/Images/TV/tvBbc.png";
                        }
                        else if (i == 2)
                        {
                            mainImage.ImageUrl = "~/Images/TV/tvDiscovery.png";
                        }
                        else if (i == 3)
                        {
                            mainImage.ImageUrl = "~/Images/TV/tvMtv.png";
                        }
                        else
                        {
                            mainImage.ImageUrl = "~/Images/TV/tvNatgeo.png";
                        }
                    }

                    else
                    {
                        mainImage.ImageUrl = "~/Images/WiFi/wifiOn.png";
                    }

                    if (deviceCollection[id] is IStereoVolumable)
                    {
                        int i = CheckVolume();

                        if (i == 0)
                        {
                            volumeImage.ImageUrl = "~/Images/TV/VolumeNone.png";
                        }
                        else if (i == 1)
                        {
                            volumeImage.ImageUrl = "~/Images/TV/VolumeMin.png";
                        }
                        else if (i == 2)
                        {
                            volumeImage.ImageUrl = "~/Images/TV/VolumeMed.png";
                        }
                        else
                        {
                            volumeImage.ImageUrl = "~/Images/TV/VolumeMax.png";
                        }
                    }
                }
                else
                {
                    if (deviceCollection[id] is IBrightable)
                    {
                        mainImage.ImageUrl = "~/Images/lamp/lampOff.png";
                    }
                    else if (deviceCollection[id] is IHeatable)
                    {
                        mainImage.ImageUrl = "~/Images/Heater/heatOff.png";
                    }
                    else if (deviceCollection[id] is IChannelable && deviceCollection[id] is IStereoVolumable)
                    {
                        mainImage.ImageUrl = "~/Images/TV/tvOff.png";
                        volumeImage.ImageUrl = "~/Images/TV/VolumeNone.png";
                    }
                    else
                    {
                        mainImage.ImageUrl = "~/Images/WiFi/wifiOff.png";
                    }

                    setButtonOnOff.ImageUrl = "~/Images/onOffUpDown/on.png";
                }

                setButtonOnOff.Click += OnOffButtonClick;
                setButtonOnOff.ID = "a" + id;
                Controls.Add(mainImage);
                Controls.Add(volumeImage);
                Controls.Add(setButtonOnOff);
            }

            deleteButton = new ImageButton();
            deleteButton.ImageUrl = "~/Images/onOffUpDown/close.png";
            deleteButton.Click += DeleteButtonClick;
            Controls.Add(deleteButton);

            if (deviceCollection[id] is IStereoVolumable && deviceCollection[id].State == true)
            {
                AddPlusMinus();
            }

            if (deviceCollection[id] is IBrightable && deviceCollection[id].State == true)
            {
                AddUpDownArrows();
            }
            else if (deviceCollection[id] is IHeatable && deviceCollection[id].State == true)
            {
                AddUpDownArrows();
            }
            else if (deviceCollection[id] is IChannelable && deviceCollection[id].State == true)
            {
                AddUpDownArrows();
            }
        }

        protected void OnOffButtonClick(object sender, EventArgs e)
        {
            if (deviceCollection[id].State != true)
            {
                ((ISwitchable)deviceCollection[id]).SetOn();
                setButtonOnOff.ImageUrl = "~/Images/onOffUpDown/off.png";

                if (deviceCollection[id] is IBrightable)
                {
                    mainImage.ImageUrl = "~/Images/lamp/lampOn.png";

                    AddUpDownArrows();
                }
                else if (deviceCollection[id] is IHeatable)
                {
                    mainImage.ImageUrl = "~/Images/Heater/heatLow.png";

                    AddUpDownArrows();
                }
                else if (deviceCollection[id] is IChannelable || deviceCollection[id] is IStereoVolumable)
                {
                    mainImage.ImageUrl = "~/Images/TV/tvBbc.png";

                    AddPlusMinus();
                    AddUpDownArrows();
                }
                else
                {
                    mainImage.ImageUrl = "~/Images/WiFi/wifiOn.png";
                }
            }
            else
            {
                ((ISwitchable)deviceCollection[id]).SetOff();
                setButtonOnOff.ImageUrl = "~/Images/onOffUpDown/on.png";

                if (deviceCollection[id] is IBrightable)
                {
                    mainImage.ImageUrl = "~/Images/lamp/lampOff.png";
                }
                else if (deviceCollection[id] is IHeatable)
                {
                    mainImage.ImageUrl = "~/Images/Heater/heatOff.png";
                }
                else if (deviceCollection[id] is IChannelable)
                {
                    mainImage.ImageUrl = "~/Images/TV/tvOff.png";
                }
                else
                {
                    mainImage.ImageUrl = "~/Images/WiFi/wifiOff.png";
                }

                Controls.Remove(setButtonDown);
                Controls.Remove(setButtonUp);
                Controls.Remove(setButtonPlus);
                Controls.Remove(setButtonMinus);

            }
        }

        protected void UpArrowButtonClick(object sender, EventArgs e)
        {
            if (deviceCollection[id] is IBrightable)
            {
                ((IBrightable)deviceCollection[id]).NextBright();
                brightnessLevel = ((IBrightable)deviceCollection[id]).Brightness.ToString();

                if (brightnessLevel == "Medium")
                {
                    mainImage.ImageUrl = "~/Images/lamp/lampOnMed.png";
                }
                else if (brightnessLevel == "High")
                {
                    mainImage.ImageUrl = "~/Images/lamp/lampOnHigh.png";
                }
            }
            else if (deviceCollection[id] is IHeatable)
            {
                ((IHeatable)deviceCollection[id]).NextHeat();
                heatLevel = ((IHeatable)deviceCollection[id]).Heat.ToString();

                if (heatLevel == "Medium")
                {
                    mainImage.ImageUrl = "~/Images/Heater/heatMed.png";
                }
                else if (heatLevel == "High")
                {
                    mainImage.ImageUrl = "~/Images/Heater/heatHigh.png";
                }
            }
            else if (deviceCollection[id] is IChannelable)
            {
                ((IChannelable)deviceCollection[id]).NextChannel();
                channel = ((IChannelable)deviceCollection[id]).Channel;

                if (channel == 2)
                {
                    mainImage.ImageUrl = "~/Images/TV/tvDiscovery.png";
                }
                else if (channel == 3)
                {
                    mainImage.ImageUrl = "~/Images/TV/tvMtv.png";
                }
                else
                {
                    mainImage.ImageUrl = "~/Images/TV/tvNatgeo.png";
                }
            }
        }

        protected void DownArrowButtonClick(object sender, EventArgs e)
        {
            if (deviceCollection[id] is IBrightable)
            {
                ((IBrightable)deviceCollection[id]).PrevBright();
                brightnessLevel = ((IBrightable)deviceCollection[id]).Brightness.ToString();

                if (brightnessLevel == "Medium")
                {
                    mainImage.ImageUrl = "~/Images/lamp/lampOnMed.png";
                }
                else
                {
                    mainImage.ImageUrl = "~/Images/lamp/lampOn.png";
                }
            }
            else if (deviceCollection[id] is IHeatable)
            {
                ((IHeatable)deviceCollection[id]).PrevHeat();
                heatLevel = ((IHeatable)deviceCollection[id]).Heat.ToString();

                if (heatLevel == "Medium")
                {
                    mainImage.ImageUrl = "~/Images/Heater/heatMed.png";
                }
                else
                {
                    mainImage.ImageUrl = "~/Images/Heater/heatLow.png";
                }
            }
            else if (deviceCollection[id] is IChannelable)
            {
                ((IChannelable)deviceCollection[id]).PrevChannel();
                channel = ((IChannelable)deviceCollection[id]).Channel;

                if (channel == 1)
                {
                    mainImage.ImageUrl = "~/Images/TV/tvBbc.png";
                }
                else if (channel == 2)
                {
                    mainImage.ImageUrl = "~/Images/TV/tvDiscovery.png";
                }
                else if (channel == 3)
                {
                    mainImage.ImageUrl = "~/Images/TV/tvMtv.png";
                }
            }
        }

        protected void PlusButtonClick(object sender, EventArgs e)
        {
            if (deviceCollection[id] is IStereoVolumable)
            {
                ((IStereoVolumable)deviceCollection[id]).StereoVolumeUp();

                foreach (var item in deviceCollection)
                {
                    string s = item.Value.ToString();
                    volume = Convert.ToInt32(s);
                }

                if (volume == 1)
                {
                    volumeImage.ImageUrl = "~/Images/TV/VolumeMin.png";
                }
                else if (volume == 2)
                {
                    volumeImage.ImageUrl = "~/Images/TV/VolumeMed.png";
                }
                else if (volume == 3)
                {
                    volumeImage.ImageUrl = "~/Images/TV/VolumeMax.png";
                }
            }
        }

        protected void MinusButtonClick(object sender, EventArgs e)
        {
            if (deviceCollection[id] is IStereoVolumable)
            {
                ((IStereoVolumable)deviceCollection[id]).StereoVolumeDown();

                foreach (var item in deviceCollection)
                {
                    string s = item.Value.ToString();
                    volume = Convert.ToInt32(s);
                }

                if (volume == 0)
                {
                    volumeImage.ImageUrl = "~/Images/TV/VolumeNone.png";
                }
                else if (volume == 1)
                {
                    volumeImage.ImageUrl = "~/Images/TV/VolumeMin.png";
                }
                else if (volume == 2)
                {
                    volumeImage.ImageUrl = "~/Images/TV/VolumeMed.png";
                }
            }
        }

        protected void DeleteButtonClick(object sender, EventArgs e)
        {
            deviceCollection.Remove(id);
            Parent.Controls.Remove(this);
        }

        protected void AddUpDownArrows()
        {
            setButtonUp = new ImageButton();
            setButtonUp.ImageUrl = "~/Images/onOffUpDown/Up.png";
            setButtonUp.ID = "u" + id;
            setButtonUp.Click += UpArrowButtonClick;
            Controls.Add(setButtonUp);

            setButtonDown = new ImageButton();
            setButtonDown.ImageUrl = "~/Images/onOffUpDown/Down.png";
            setButtonDown.ID = "d" + id;
            setButtonDown.Click += DownArrowButtonClick;
            Controls.Add(setButtonDown);
        }

        protected void AddPlusMinus()
        {
            setButtonPlus = new ImageButton();
            setButtonPlus.ImageUrl = "~/Images/onOffUpDown/Plus.png";
            setButtonPlus.ID = "p" + id;
            setButtonPlus.Click += PlusButtonClick;
            Controls.Add(setButtonPlus);

            setButtonMinus = new ImageButton();
            setButtonMinus.ImageUrl = "~/Images/onOffUpDown/Minus.png";
            setButtonMinus.ID = "m" + id;
            setButtonMinus.Click += MinusButtonClick;
            Controls.Add(setButtonMinus);
        }

        protected string CheckBrightnessLevel()
        {
            brightnessLevel = ((IBrightable)deviceCollection[id]).Brightness.ToString();

            if (brightnessLevel == "Low")
            {
                return "Low";
            }
            else if (brightnessLevel == "Medium")
            {
                return "Medium";
            }
            else
            {
                return "High";
            }
        }

        protected string CheckHeatLevel()
        {
            heatLevel = ((IHeatable)deviceCollection[id]).Heat.ToString();

            if (heatLevel == "Low")
            {
                return "Low";
            }
            else if (heatLevel == "Medium")
            {
                return "Medium";
            }
            else
            {
                return "High";
            }
        }

        protected int CheckChannelNumber()
        {
            channel = ((IChannelable)deviceCollection[id]).Channel;

            if (channel == 1)
            {
                return 1;
            }
            else if (channel == 2)
            {
                return 2;
            }
            else if (channel == 3)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        protected int CheckVolume()
        {
            string s = ((IStereoVolumable)deviceCollection[id]).ToString();
            volume = Convert.ToInt32(s);

            if (volume == 0 || volume == null)
            {
                return 0;
            }
            else if (volume == 1)
            {
                return 1;
            }
            else if (volume == 2)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}