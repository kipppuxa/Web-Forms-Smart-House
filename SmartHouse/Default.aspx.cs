using Smart_House;
using SmartHouse.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHouse
{
    public partial class Default : System.Web.UI.Page
    {
        private int id;
        private IDictionary<int,Device> deviceCollection = new Dictionary<int,Device>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                deviceCollection = (Dictionary<int, Device>)Session["S"];
            }
            else
            {
                deviceCollection.Add(1, new TV(false, 1,new StereoSystem(false,0)));

                Session["S"] = deviceCollection;
                Session["NextId"] = 2;
            }

            InitializeDevicePanel();
        }

        protected void InitializeDevicePanel()
        {
            foreach (int key in deviceCollection.Keys)
            {
                ItemPlace.Controls.Add(new DeviceControl(key, deviceCollection));
            }
        }

        protected void addLampButton_Click(object sender, EventArgs e)
        {
            Device newDevice;
            newDevice = new Lamp(false, BrightnessLevel.Low);

            id = (int)Session["NextId"];
            deviceCollection.Add(id, newDevice);
            ItemPlace.Controls.Add(new DeviceControl(id,deviceCollection));

            id++;
            Session["NextId"] = id;
        }

        protected void addTVButton_Click(object sender, EventArgs e)
        {
            Device newDevice;
            newDevice = new TV(false, 1,new StereoSystem(false,0));

            id = (int)Session["NextId"];
            deviceCollection.Add(id, newDevice);
            ItemPlace.Controls.Add(new DeviceControl(id, deviceCollection));

            id++;
            Session["NextId"] = id;
        }

        protected void addHeaterButton_Click(object sender, EventArgs e)
        {
            Device newDevice;
            newDevice = new Heater(false, HeatLevel.Low);

            id = (int)Session["NextId"];
            deviceCollection.Add(id, newDevice);
            ItemPlace.Controls.Add(new DeviceControl(id, deviceCollection));

            id++;
            Session["NextId"] = id;
        }

        protected void addWiFiButton_Click(object sender, EventArgs e)
        {
            Device newDevice;
            newDevice = new WiFi(false);

            id = (int)Session["NextId"];
            deviceCollection.Add(id, newDevice);
            ItemPlace.Controls.Add(new DeviceControl(id, deviceCollection));

            id++;
            Session["NextId"] = id;
        }
    }
}